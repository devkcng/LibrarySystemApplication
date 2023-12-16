using System.Collections.Generic;
using System.IO;
using UsersClassLibrary;

namespace Dataloader
{
    public class dataLoaderBorrrower : dataLoader<List<Borrower>>
    {
        private readonly pathToEntity _path = new pathToEntity();

        public override void Loader(List<Borrower> listBorrower)
        {
            using (var reader = new StreamReader(_path.PathBorrower))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        var values = line.Split(',');
                        if (values[0] != "BorrowerID")
                        {
                            listBorrower.Add(new Borrower(values[0], values[1], values[2], values[3], values[4]));
                        }
                    }
                }
            }
        }

        public void LoaderBorrowerKey(List<Key> listKey)
        {
            var list = new List<string>();
            using (var reader = new StreamReader(_path.PathBorrowerKey))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null) list.Add(line);
                }
            }
            foreach (var key in list)
            {
                if (key != "")
                {
                    var values = key.Split(',');

                    if (values[0] != "Username")
                        listKey.Add(new Key(values[0], values[1], values[2]));
                }
            }
        }
    }
}