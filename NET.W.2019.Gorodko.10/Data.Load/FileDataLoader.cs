using System;
using System.IO;
using Data.Load.Abstract;

namespace Data.Load
{
    /// <summary>
    /// Provides loading string from file.
    /// </summary>
    public class FileDataLoader : IDataLoader
    {
        /// <summary>
        /// File path.
        /// </summary>
        private readonly string path;

        /// <summary>
        /// Initials new loader with file path.
        /// </summary>
        /// <param name="path"> File path.</param>
        public FileDataLoader(string path)
        {
            this.path = path ?? throw new ArgumentNullException(nameof(path));
        }

        /// <summary>
        /// Loads string from file.
        /// </summary>
        /// <returns>String wuth data.</returns>
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
