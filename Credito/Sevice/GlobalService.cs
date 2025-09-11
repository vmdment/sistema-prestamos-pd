using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credito.Sevice
{
    public class GlobalService
    {
        public string? ReadLine(string path) {
            using StreamReader file = new StreamReader(path);
            return file.ReadLine();
        }
        public string? ReadAll(string path)
        {
            using StreamReader file = new StreamReader(@$"{Directory.GetCurrentDirectory().Replace(@"\bin\Debug\net8.0", "")}{path}");
            return file.ReadToEnd();
        }
        public bool WriteLine(string path, string line) {
            try
            {
                using StreamWriter file = new StreamWriter(path);
                file.WriteLine(line);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
