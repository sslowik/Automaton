using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaton.feature_ex_3
{
    public class FileProcessor
    {
        public string GenerateRandomFileName(string filePath, string fileExtension)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            string randomFile = (filePath + string.Concat(Path.GetRandomFileName().Replace(".","") + "." + fileExtension));
            return randomFile;
        }

        public void WriteFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                using (FileStream fs = File.Create(fileName))
                {
                    fs.WriteByte(95);
                }
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", fileName);
                return;
            }
        }

        public static string GenerateFileName(string extension = "")
        {
            return string.Concat(Path.GetRandomFileName().Replace(".", ""),
                (!string.IsNullOrEmpty(extension)) ? (extension.StartsWith(".") ? extension : string.Concat(".", extension)) : "");
        }

        public static void DopiszDoPliku(FileInfo whereWrite, string whatWrite)
        {
            var fileStream = new FileStream(whereWrite.FullName, FileMode.Open, FileAccess.Write);
            var streamWriter = new StreamWriter(fileStream);
            streamWriter.Write(whatWrite);
            streamWriter.Close();
            fileStream.Close();
        }

        public static void WriteRandomsToFile(FileInfo whereWrite, int howManyIntegers, int minInteger, int maxInteger)
        {
            Random random = new Random();

            string[] sRandomIntegers = new string[howManyIntegers];

            for (int i = 0; i < howManyIntegers; i++)
            {
                sRandomIntegers[i] = random.Next(minInteger, maxInteger).ToString();
            }

            var fileStream = new FileStream(whereWrite.FullName, FileMode.Append, FileAccess.Write);
            var streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine(string.Join(",", sRandomIntegers));
            streamWriter.Close();
            fileStream.Close();
        }
    }
}
