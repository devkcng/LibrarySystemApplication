using System.Collections.Generic;
using System.IO;

namespace Dataloader
{
    public class dataLoaderTransactions: dataLoader<List<Transaction>>
    {   
        private readonly pathToEntity _path = new pathToEntity();
        public void LoaderBorrow(List<Transaction> transactions)
        {
            using (var reader = new StreamReader(_path.PathTransactionsBorrow))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        var values = line.Split(',');
                        if (values[0] != "ISBN") transactions.Add(new Transaction(values[0], values[1], values[2]));
                    }
                }
            }
        }
        public void LoaderReturn(List<Transaction> transactions)
        {
            using (var reader = new StreamReader(_path.PathTransactionsReturn))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        var values = line.Split(',');
                        if (values[0] != "ISBN") transactions.Add(new Transaction(values[0], values[1], values[2]));
                    }
                }
            }
        }
    }
}