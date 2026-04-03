using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LocalShare
{
    internal class FileWriter
    {
        public static void Write(string path, string content, bool replace)
        {
            string file = Path.Exists(path) ? GetFileContent(path) : "";
            using (StreamWriter sw = new StreamWriter(path))
            {
                if (replace)
                {
                    file = content;
                }
                else
                {
                    file += content+"\n";
                }
                sw.Write(file);
            }
        }
        public static String GetFileContent(string filepath)
        {
            return File.ReadAllText(filepath);
        }
    }

}
