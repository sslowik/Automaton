using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaton.feature_ex_3
{
    public class FileGenerator
    {
        public string GenerateRandomFileName(string filePath, string fileExtension)
        {
            if (!System.IO.Directory.Exists(filePath))
            {
                System.IO.Directory.CreateDirectory(filePath);
            }

            string randomFile = (filePath + string.Concat(Path.GetRandomFileName().Replace(".","") + "." + fileExtension));
            return randomFile;
        }

        public void WriteFile(string randomFile)
        {
            if (!System.IO.File.Exists(randomFile))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(randomFile))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", randomFile);
                return;
            }
        }


        public static string GenerateFileName(string extension = "")
        {
            return string.Concat(Path.GetRandomFileName().Replace(".", ""),
                (!string.IsNullOrEmpty(extension)) ? (extension.StartsWith(".") ? extension : string.Concat(".", extension)) : "");
        }

        
        //        for (var i = 0; i< 5; i++)
        //            {

        //                using (FileStream fs = File.Create(filePath))
        //                {
        //                    FileGenerator.(fs, "Some text");
        //                }

        //            }

        //        private static void AddText(FileStream fs, string value)
        //        {
        //            byte[] info = new UTF8Encoding(true).GetBytes(value);
        //            fs.Write(info, 0, info.Length);
        //        }
    }
}
