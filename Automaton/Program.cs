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

            // ex 2 - playing with Interfaces

            Console.WriteLine("ex 2 - playing with Interfaces \n");

            HelloSpeaker speak = new HelloSpeaker();

            ELanguage[] languages = (ELanguage[])Enum.GetValues(typeof(ELanguage));

            foreach (var lang in languages)
            {
                speak.SayHello(lang);
            }

            Console.WriteLine();

            //introduce using lambda function
            
            languages.AsParallel().ForAll(f => speak.SayHello(f));

            // Ex 3. - Playing with files

            Console.WriteLine("\n Ex. 3. - Playing with files \n");

            // 3.1. generate random files with different extensions .txt .zip. xml using FileGenerator class
            //specify folder for output files: 

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

            // remove .xml files 

            DirectoryInfo di = new DirectoryInfo(filesPath);
            var files = di.GetFiles();
            files.AsParallel().Where(f => f.Extension == ".xml").ForAll(f => f.Delete());

            // change names of txt file to 'test_nr_x' where x are next int

            var filesZip = files.AsParallel().Where(f => f.Extension == ".zip");

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

            Console.WriteLine("\n Inserting to .txt files random integers separated with space \n");

            var filesTxt = files.AsParallel().Where(f => f.Extension == ".txt");

            foreach (var file1 in filesTxt)
            {
                FileProcessor.WriteRandomsToFile(file1, 10, 1, 100); 
            }

            // Ex. 4. Playing with processes

            Console.ReadKey();
        }

        
    }
}
