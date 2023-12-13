using BookClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataloader
{
    public class dataLoaderTransactionsReturn : dataLoader<List<string>>
    {
        public override void Loader(List<string> bookReturned, string borrowerID)
        {
            using (var reader = new StreamReader(@"D:\code\c#\Git\LibrarySystemApplication\DATABASE\transactionsReturn.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values[0] != "ISBN")
                    {
                        if (values[1] == borrowerID)
                        {
                            bookReturned.Add(string.Format("{0},{1}", values[0], values[2]));
                        }
                    }
                }
            }
        }
        public void Append(Book item, string borrowerID)
        {
            List<String> lines = new List<String>();

            string newFileName = @"D:\code\c#\Git\LibrarySystemApplication\DATABASE\transactionsReturn.csv";
            string clientDetails = item.ID + "," + borrowerID + "," + DateTime.Now.ToString("dd/MM/yyyy");
            if (File.Exists(newFileName))
            {
                using (StreamReader reader = new StreamReader(newFileName))
                {
                    String line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        var a = line.Split(',');
                        line = string.Format("{0},{1},{2}", a[0], a[1], a[2]);
                        if (line != ",,")
                            lines.Add(line);
                    }
                }

                using (StreamWriter writer = new StreamWriter(newFileName, false))
                {
                    foreach (String line in lines)
                        writer.WriteLine(line);
                    writer.WriteLine(clientDetails);
                }

            }
        }
    }
}
