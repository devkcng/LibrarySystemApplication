using System;
using System.Collections.Generic;
using System.IO;
using BookClassLibrary;

namespace Dataloader
{
    public class dataLoaderTransactionsReturn : dataLoader<List<string>>
    {
        private readonly pathToEntity _path = new pathToEntity();

        public override void Loader(List<string> bookReturned, string borrowerID)
        {
            using (var reader = new StreamReader(_path.PathTransactionsReturn))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values[0] != "ISBN")
                        if (values[1] == borrowerID)
                            bookReturned.Add(string.Format("{0},{1}", values[0], values[2]));
                }
            }
        }

        public void Append(Book item, string borrowerID)
        {
            var lines = new List<string>();

            var newFileName = _path.PathTransactionsReturn;
            var clientDetails = item.ISBN + "," + borrowerID + "," + DateTime.Now.ToString("dd/MM/yyyy");
            if (File.Exists(newFileName))
            {
                using (var reader = new StreamReader(newFileName))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        var a = line.Split(',');
                        line = string.Format("{0},{1},{2}", a[0], a[1], a[2]);
                        if (line != ",,")
                            lines.Add(line);
                    }
                }

                using (var writer = new StreamWriter(newFileName, false))
                {
                    foreach (var line in lines)
                        writer.WriteLine(line);
                    writer.WriteLine(clientDetails);
                }
            }
        }
    }
}