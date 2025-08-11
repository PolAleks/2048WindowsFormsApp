using System;
using System.IO;
using System.Text;

namespace _2048.Common
{
    public class FileProvider
    {
        private static string _path = Environment.CurrentDirectory;
        public static bool Exists(string file) => File.Exists(Path.Combine(_path, file));

        public static string Load(string file)
        {
            if (Exists(file))
            {
                return File.ReadAllText(Path.Combine(_path, file), Encoding.UTF8);
            }
            return null;
        }

        public static void Save(string file, string content) => File.WriteAllText(Path.Combine(_path, file), content, Encoding.UTF8);
    }
}
