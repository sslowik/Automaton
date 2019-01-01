using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Automaton.feature_ex_2;
using Automaton.feature_ex_3;

namespace Automaton
{
    class Program
    {
        static void Main(string[] args)
        {

            // ex 2 - zabawa z interfejsami

            Console.WriteLine("ex 2 - zabawa z interfejsami \n");

            HelloSpeaker speak = new HelloSpeaker();
            ////speak.SayHello(ELanguage.PL);

            ELanguage[] languages = (ELanguage[])Enum.GetValues(typeof(ELanguage));

            foreach (var lang in languages)
            {
                speak.SayHello(lang);
            }

            Console.WriteLine();

            //to samo z lambdą:
            
            languages.AsParallel().ForAll(f => speak.SayHello(f)); 
            
            // ex 3 - zabawa z plikami
            // generuję po 5 losowych plików z rozszerzeniem .txt, .zip, .xml korzystajać z utworzonej klasy FileGenerator, i zapisuję w podanej lokalizacji:  

            Console.WriteLine("\n ex 3 - zabawa z plikami \n");

            //lokalizacja do zapisu plików: 

            string filesPath = @"D:\Random\";

            FileProcessor filon = new FileProcessor();

            for (var i = 0; i < 5; i++)
            {
                filon.WriteFile(filon.GenerateRandomFileName(filesPath, "txt"));

                filon.WriteFile(filon.GenerateRandomFileName(filesPath, "zip"));

                filon.WriteFile(filon.GenerateRandomFileName(filesPath, "xml"));
            }

            var fileList = Directory.GetFiles(filesPath);

            for (var i = 0; i < fileList.Length; i++)
            {
                Console.WriteLine("File No " + (i + 1) + ": " + fileList[i]);
            }

            //- usuwam wszystkie pliki xml 

            DirectoryInfo di = new DirectoryInfo(filesPath);
            var files = di.GetFiles();
            files.AsParallel().Where(f => f.Extension == ".xml").ForAll(f => f.Delete());

            // zmieniam nazwę każdego pliku zip na: test_nr - gdzie nr to kolejna liczba naturalna

            var filesZip = files.AsParallel().Where(f => f.Extension == ".zip");

            //używam foreach zmieniająca nazwę, nie udało mi się napisac poprawnej lambdy z counterem :(

            //var counter = 1; 
            //foreach (var f in filesZip)
            //    try
            //    {
            //    File.Move(f.FullName, string.Format("{0}test_nr_{1}.zip", filesPath, counter));
            //    counter++; 
            //    }
            //    catch
            //    {
            //        Console.WriteLine("File already exists");
            //    }

            // a może tak zatrybi lambdą: 

            filesZip.AsParallel().ForAll(f =>
            {
                if (File.Exists(string.Format("{0}test_nr_{1}.zip", filesPath, Array.IndexOf(filesZip.ToArray(), f) + 1)))
                {
                    File.Delete(string.Format("{0}test_nr_{1}.zip", filesPath, Array.IndexOf(filesZip.ToArray(), f) + 1));
                    File.Move(f.FullName, string.Format("{0}test_nr_{1}.zip", filesPath, Array.IndexOf(filesZip.ToArray(), f) + 1));
                } else
                { 
                    File.Move(f.FullName, string.Format("{0}test_nr_{1}.zip", filesPath, Array.IndexOf(filesZip.ToArray(), f) + 1));
                }
            }); 

            //ano zatrybiło :P. Przy okazji dodałem if usuwający plik jeśli juz istnieje z taką nazwą 

            Console.WriteLine("\n wklejanie losowych liczb do pliku \n");
            
            //do każdego pliku txt wklej kolekcję losowych liczb z zakresu 1 - 100 oddzielonych spacją, skorzystaj z klasy Random

            var filesTxt = files.AsParallel().Where(f => f.Extension == ".txt");


            foreach (var file1 in filesTxt)
            {
                FileProcessor.DopiszLosoweDoPliku(file1, 10, 1, 100); 
            }

            Console.ReadKey();
        }

        
    }
}
