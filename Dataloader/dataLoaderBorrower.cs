﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersClassLibrary;
namespace Dataloader
{
    public class dataLoaderBorrrower : dataLoader<List<Borrower>>
    {
        public dataLoaderBorrrower() { }
        public override void Loader(List<Borrower> listBorrower)
        {

            using (var reader = new StreamReader(@"D:\code\c#\Git\LibrarySystemApplication\DATABASE\Borrower.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values[0] != "ISBN")
                    {

                        listBorrower.Add(new UsersClassLibrary.Borrower(values[0], values[1], values[2], values[3]));
                    }
                }
            }
        }
        public void LoaderBorrowerKey(List<string> listKey)
        {
            using (var reader = new StreamReader(@"D:\code\c#\Git\LibrarySystemApplication\DATABASE\BorrowerKey.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (line.Split(',')[0] != "username")
                    {
                        listKey.Add(line);
                    }
                }
            }
        }
  
    }
}
