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
                    //for (byte i = 0; i < 100; i++)
                    //{
                    //    fs.WriteByte(i);
                    //}
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

        public static void DopiszDoPliku(FileInfo gdzieZapisac, string coZapisac)
        {
            var plik = new FileStream(gdzieZapisac.FullName, FileMode.Open, FileAccess.Write);
            var zapisuj = new StreamWriter(plik);
            zapisuj.Write(coZapisac);
            zapisuj.Close();
            plik.Close();
        }

        public static void DopiszLosoweDoPliku(FileInfo gdzieZapisac, int ileLiczb, int minLiczba, int maxLiczba)
        {
            Random randek = new Random();

            string[] sLiczbyLosowe = new string[ileLiczb];

            for (int i = 0; i < ileLiczb; i++)
            {
                sLiczbyLosowe[i] = randek.Next(minLiczba, maxLiczba).ToString();
            }

            var plik = new FileStream(gdzieZapisac.FullName, FileMode.Append, FileAccess.Write);
            var zapisuj = new StreamWriter(plik);
            zapisuj.WriteLine(string.Join(",", sLiczbyLosowe));
            zapisuj.Close();
            plik.Close();
        }



        ////public static void DopiszDoPliku(FileInfo gdzieZapisac, string coZapisac)
        ////{

        ////    var plik = new FileStream(Path.GetFullPath(gdzieZapisac.ToString()), FileMode.Open, FileAccess.Write);
        ////    var zapisuj = new StreamWriter(plik);
        ////    // zapisuj.Write(tekst);
        ////    zapisuj.Write(coZapisac);
        ////    zapisuj.Close();
        ////    plik.Close();
        ////}


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
