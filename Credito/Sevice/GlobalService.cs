using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credito.Sevice
{
    public class GlobalService
    {
        public static GlobalService Instance { get; } = new GlobalService();
        private GlobalService() { }

        private readonly string basePath = Directory.GetCurrentDirectory().Replace(@"\bin\Debug\net8.0", "");
        public string? ReadLine(string path) {
            using StreamReader file = new StreamReader(@$"{basePath}{path}");
            return file.ReadLine();
        }
        public string? ReadAll(string path)
        {
            using StreamReader file = new StreamReader(@$"{basePath}{path}");
            return file.ReadToEnd();
        }
        public bool WriteLine(string path, string line) {
            try
            {
                using StreamWriter file = new StreamWriter(@$"{basePath}{path}",true);
                file.Write($"\n{line}");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
