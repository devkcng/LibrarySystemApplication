using System.Collections.Generic;
using System.IO;

namespace Dataloader
{
    public class dataLoaderTransactions: dataLoader<List<Transaction>>
    {   
        private readonly pathToEntity _path = new pathToEntity();
        public void LoaderBorrow(List<Transaction> transactions)
        {   
            var list = new List<string>();
            using (var reader = new StreamReader(_path.PathTransactionsBorrow))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null) list.Add(line);
                }
            }
            foreach (var transaction in list)
            {
                if (transaction != "")
                {
                    var values = transaction.Split(',');
                    if (values[0] != "ISBN") transactions.Add(new Transaction(values[0], values[1], values[2]));
                }
            }
            if (transactions.Count == 0) transactions.Add(new Transaction("", "", ""));
        }
        public void LoaderReturn(List<Transaction> transactions)
        {
            var list = new List<string>();
            using (var reader = new StreamReader(_path.PathTransactionsReturn))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null) list.Add(line);
                }
            }
            foreach (var transaction in list)
            {
                if (transaction != "")
                {
                    var values = transaction.Split(',');
                    if (values[0] != "ISBN") transactions.Add(new Transaction(values[0], values[1], values[2]));
                }
            }

            if (transactions.Count == 0) transactions.Add(new Transaction("", "", ""));
        }
    }
}