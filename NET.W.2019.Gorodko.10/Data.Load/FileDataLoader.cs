using System;
using System.IO;
using Data.Load.Abstract;

namespace Data.Load
{
    public class FileDataLoader : IDataLoader
    {
        private readonly string path;

        public FileDataLoader(string path)
        {
            this.path = path ?? throw new ArgumentNullException(nameof(path));
        }

        public string Load()
        {
            string data;
            using (var reader = new StreamReader(this.path))
            {
                data = reader.ReadToEnd();
            }

            return data;
        }
    }
}
