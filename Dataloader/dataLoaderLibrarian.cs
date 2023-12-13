using System.Collections.Generic;
using System.IO;
using UsersClassLibrary;

namespace Dataloader
{
    public class dataLoaderLibrarian : dataLoader<List<Librarian>>
    {
        private readonly pathToEntity _path = new pathToEntity();

        public override void Loader(List<Librarian> listLibrarian)
        {
            using (var reader = new StreamReader(_path.PathLibrarian))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values[0] != "ISBN")
                        listLibrarian.Add(new Librarian(values[0], values[1], values[2], values[3]));
                }
            }
        }

        public void LoaderLibrarianKey(List<string> listKey)
        {
            using (var reader = new StreamReader(_path.PathLibrarianKey))
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