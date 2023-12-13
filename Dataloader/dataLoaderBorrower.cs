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
                    var values = line.Split(',');
                    if (values[0] != "ISBN") listBorrower.Add(new Borrower(values[0], values[1], values[2], values[3]));
                }
            }
        }

        public void LoaderBorrowerKey(List<string> listKey)
        {
            using (var reader = new StreamReader(_path.PathBorrowerKey))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (line.Split(',')[0] != "username") listKey.Add(line);
                }
            }
        }
    }
}