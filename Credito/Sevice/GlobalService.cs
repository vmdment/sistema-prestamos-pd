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
        public string? ReadLine(string path)
        {
            using StreamReader file = new StreamReader(@$"{basePath}{path}");
            string? line = file.ReadLine();
            file.Dispose();
            return line;
        }
        public string? ReadAll(string path)
        {
            using StreamReader file = new StreamReader(@$"{basePath}{path}");
            string text = file.ReadToEnd();
            file.Dispose();
            return text.Length == 0 ? null : text;
        }
        public bool WriteLine(string path, string line, bool append = true) {
            try
            {
                string? data = ReadLine(path);
                using StreamWriter file = new StreamWriter(@$"{basePath}{path}", append);
                if(data != null)
                    file.Write($"\n{line}");
                else
                    file.Write($"{line}");
                file.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Reset(string path)
        {
            try
            {
                string? data = ReadLine(path);
                using StreamWriter file = new StreamWriter(@$"{basePath}{path}", false);
                    file.Write("");
                file.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
