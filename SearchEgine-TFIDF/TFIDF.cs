using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dataloader;

namespace BookClassLibrary
{
    public class TFIDF
    {
        private readonly pathToEntity _path = new pathToEntity();

        public List<Book> TF_IDF(string query, List<Book> listBook,List<string> Summary)
        {
            // Specify the folder containing text documents
            var folderPath = _path.PathSummary;

            // Read all text documents from the specified folder
            var documents = ReadDocumentsFromFolder(folderPath);

            // Tokenize and preprocess documents
            var tokenizedDocuments = documents.Select(doc => TokenizeAndPreprocess(doc)).ToList();

            // Build the TF-IDF matrix
            var documentFrequencies = CalculateDocumentFrequencies(tokenizedDocuments);
            var tfidfMatrix = CalculateTFIDF(tokenizedDocuments, documentFrequencies);
            //Save string of ISBN
            var results = new string[documents.Count()];


            // Search the query
            var searchResults = Search(query, tokenizedDocuments, tfidfMatrix, documentFrequencies);

            // Display the top 100 search results (or fewer if there are fewer results)
            var resultsSummary = new string[documents.Count()];
            var resultCount = Math.Min(searchResults.Count, documents.Count());
            for (var i = 0; i < resultCount; i++)
            {
                var (documentIndex, score) = searchResults[i];
                // Display the score and the original name of the document
                var found = documents[documentIndex].IndexOf("ISBN: ");
                results[i] = documents[documentIndex].Substring(found + 6, 10);
                resultsSummary[i] = documents[documentIndex].Substring((documents[documentIndex].IndexOf("Summary:") + 10));
            }

            var sortedListBook = new List<Book>();
            for (var i = 0; i < results.Length; i++)
                foreach (var book in listBook)
                    if (results[i].Contains(book.ISBN))
                    {
                        sortedListBook.Add(book);
                        Summary.Add(resultsSummary[i]);
                        break;
                    }
            
            for (int i= listBook.Count()-1;i>=0;i--)
            {
                bool check = false;
                if (listBook.Count() != sortedListBook.Count())
                {
                    foreach (Book sbook in sortedListBook)
                    {
                        if (sbook.ISBN == listBook[i].ISBN)
                        {
                            check = true;
                            break;
                        }
                    }
                    if (check == false) sortedListBook.Add(listBook[i]);
                }
                else break;
                
            }
            return sortedListBook;
        }

        private static void DisplaySearchResultSnippet(string document, string query)
        {
            // Display a snippet of the document where the query terms were found
            var queryTerms = TokenizeAndPreprocess(query);
            var documentLines = document.Split('\n');

            foreach (var line in documentLines)
                if (queryTerms.Any(term => line.ToLower().Contains(term)))
                {
                    // Highlight the query terms in the snippet
                    foreach (var term in queryTerms)
                    {
                        var highlightedLine =
                            line.Replace(term, $"\u001b[33m{term}\u001b[0m"); // ANSI escape code for yellow text
                        Console.WriteLine(highlightedLine);
                    }

                    return; // Display only the first matching line
                }

            // If no matching line is found, display the first few lines of the document
            Console.WriteLine(string.Join("\n", documentLines.Take(3)));
        }

        private static void DisplayDocumentConcept(string document)
        {
            // You can customize this method based on the structure/content of your documents
            Console.WriteLine("Document Concept:");
            Console.WriteLine(document);
            Console.WriteLine();
        }

        private static string GetDocumentName(string document)
        {
            // You might need to customize this method based on your document structure
            // For example, if your documents have a specific format or metadata, extract the relevant information.

            // For now, let's assume the document content itself contains the name or identifier.
            // You can replace this logic with your actual document naming/identifying mechanism.
            //var lines = document.Split('\n');
            //if (lines.Length > 0) return lines[0].Trim(); // Assuming the first line contains the document name.

            //// If the document has no content or structure, return a default name.
            //return "Unnamed Document";
            const string prefix = "ISBN: ";
            return document.StartsWith(prefix) ? document.Substring(prefix.Length).Trim() : "Unnamed Document";
        }

        // Read all text documents from a folder
        private static List<string> ReadDocumentsFromFolder(string folderPath)
        {
            var documents = new List<string>();

            // Check if the folder exists
            if (Directory.Exists(folderPath))
            {
                // Read all text files from the folder
                var files = Directory.GetFiles(folderPath, "*.txt");
                foreach (var file in files)
                {
                    // Read the content of each file and add it to the list of documents
                    var content = File.ReadAllText(file);
                    documents.Add(content);
                    //Console.WriteLine($"Original Document Name: {file}, Processed Document Name: {GetDocumentName(content)}");
                }
            }
            else
            {
                Console.WriteLine("Folder not found. Please provide a valid folder path.");
            }

            return documents;
        }

        // Tokenize and preprocess a document
        private static List<string> TokenizeAndPreprocess(string document)
        {
            // Use more advanced tokenization and preprocessing techniques
            // For example, remove stop words and apply stemming

            // Split the document into words
            var words = document.ToLower()
                .Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            // Remove common English stop words
            var stopWords = new List<string>
                { "this", "is", "the", "and", "a", "an", "in", "to", "of", "for", "it", "on" };
            words = words.Where(word => !stopWords.Contains(word)).ToList();

            // Apply stemming (you may need a more advanced library for this)
            // This is a basic example and may not cover all cases
            words = words.Select(word => word.EndsWith("s") ? word.Substring(0, word.Length - 1) : word).ToList();

            return words;
        }

        // Calculate document frequencies for each term
        private static Dictionary<string, int> CalculateDocumentFrequencies(List<List<string>> documents)
        {
            var documentFrequencies = new Dictionary<string, int>();

            foreach (var document in documents)
            foreach (var term in document.Distinct())
                if (documentFrequencies.ContainsKey(term))
                    documentFrequencies[term]++;
                else
                    documentFrequencies[term] = 1;

            return documentFrequencies;
        }

        // Calculate TF-IDF matrix
        private static Dictionary<string, Dictionary<string, double>> CalculateTFIDF(List<List<string>> documents,
            Dictionary<string, int> documentFrequencies)
        {
            var tfidfMatrix = new Dictionary<string, Dictionary<string, double>>();

            foreach (var document in documents)
            {
                var tfidfVector = new Dictionary<string, double>();

                foreach (var term in document.Distinct())
                {
                    var tf = document.Count(t => t == term) / (double)document.Count;
                    var idf = Math.Log(documents.Count / (double)documentFrequencies[term] + 1);
                    var tfidf = tf * idf;

                    tfidfVector[term] = tfidf;
                }

                // Add the document key to the tfidfMatrix
                tfidfMatrix[string.Join(" ", document)] = tfidfVector;

                // Ensure that all terms in the document are included in the tfidfMatrix
                foreach (var term in document)
                    if (!tfidfMatrix.ContainsKey(term))
                        // If the term is not present in the matrix, add it with an empty vector
                        tfidfMatrix[term] = new Dictionary<string, double>();
            }

            return tfidfMatrix;
        }

        // Search for a query in the TF-IDF matrix
        private static List<(int, double)> Search(string query, List<List<string>> documents,
            Dictionary<string, Dictionary<string, double>> tfidfMatrix, Dictionary<string, int> documentFrequencies)
        {
            var queryTerms = TokenizeAndPreprocess(query);

            var queryVector = new Dictionary<string, double>();

            foreach (var term in queryTerms.Distinct())
            {
                var termFrequency = queryTerms.Count(t => t == term);
                var documentFrequency = documentFrequencies.ContainsKey(term) ? documentFrequencies[term] : 0;

                var tf = termFrequency / (double)queryTerms.Count;
                var idf = Math.Log(documents.Count / (double)(documentFrequency + 1));
                var tfidf = tf * idf;

                queryVector[term] = tfidf;
            }

            var searchResults = new List<(int, double)>();

            for (var i = 0; i < documents.Count; i++)
            {
                var documentKey = string.Join(" ", documents[i]);

                // Check if the documentKey is present in the tfidfMatrix before accessing it
                if (tfidfMatrix.ContainsKey(documentKey))
                {
                    var similarity = CosineSimilarity(queryVector, tfidfMatrix[documentKey]);
                    searchResults.Add((i, similarity));
                }
                else
                {
                    // Handle the case where the documentKey is not present in tfidfMatrix
                    Console.WriteLine($"Warning: Document {i + 1} is not present in the TF-IDF matrix.");
                }
            }

            // Order the results by similarity (descending order)
            searchResults = searchResults.OrderByDescending(result => result.Item2).ToList();

            return searchResults;
        }


        // Calculate cosine similarity between two vectors
        private static double CosineSimilarity(Dictionary<string, double> vector1, Dictionary<string, double> vector2)
        {
            var dotProduct = vector1.Keys.Intersect(vector2.Keys).Sum(key => vector1[key] * vector2[key]);
            var magnitude1 = Math.Sqrt(vector1.Values.Select(value => value * value).Sum());
            var magnitude2 = Math.Sqrt(vector2.Values.Select(value => value * value).Sum());

            if (magnitude1 == 0 || magnitude2 == 0)
                return 0;

            return dotProduct / (magnitude1 * magnitude2);
        }
    }
}