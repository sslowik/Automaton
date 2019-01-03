using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using Automaton.feature_ex_2;
using Automaton.feature_ex_3;
using Automaton.feature_ex_4;

namespace Automaton
{
    class Program
    {
        static void Main(string[] args)
        {

            // ex 2 - playing with Interfaces

            Console.WriteLine("ex 2 - playing with Interfaces \n");

            HelloSpeaker speak = new HelloSpeaker();

            ELanguage[] languages = (ELanguage[]) Enum.GetValues(typeof(ELanguage));

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

            //clearing temp directory
            {
                DirectoryInfo diDelete = new DirectoryInfo(filesPath);
                var filesDelete = diDelete.GetFiles();
                filesDelete.AsParallel().Where(f => f.Extension == ".zip").ForAll(f => f.Delete());
            }

            FileProcessor fileProcessor = new FileProcessor();

            for (var i = 0; i < 5; i++)
            {
                fileProcessor.WriteFile(fileProcessor.GenerateRandomFileName(filesPath, "txt"));

                fileProcessor.WriteFile(fileProcessor.GenerateRandomFileName(filesPath, "zip"));

                fileProcessor.WriteFile(fileProcessor.GenerateRandomFileName(filesPath, "xml"));
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
                if (File.Exists(
                    string.Format("{0}test_nr_{1}.zip", filesPath, Array.IndexOf(filesZip.ToArray(), f) + 1)))
                {
                    File.Delete(
                        string.Format("{0}test_nr_{1}.zip", filesPath, Array.IndexOf(filesZip.ToArray(), f) + 1));
                    File.Move(f.FullName,
                        string.Format("{0}test_nr_{1}.zip", filesPath, Array.IndexOf(filesZip.ToArray(), f) + 1));
                }
                else
                {
                    File.Move(f.FullName,
                        string.Format("{0}test_nr_{1}.zip", filesPath, Array.IndexOf(filesZip.ToArray(), f) + 1));
                }
            });

            //Console.WriteLine("\n Inserting to .txt files random integers separated with space \n");

            var filesTxt = files.AsParallel().Where(f => f.Extension == ".txt");

            foreach (var file1 in filesTxt)
            {
                FileProcessor.WriteRandomsToFile(file1, 10, 1, 100);
            }



            // Ex. 4. Playing with processes

            Console.WriteLine("/n Ex. 4.Playing with processes /n");

            // 4.1. Process.Start("ipconfig", "/all");

            var startInfo = new ProcessStartInfo();
            startInfo.FileName = "ipconfig.exe";
            startInfo.Arguments = null;

            var thisProcessOutput = ProcessOutputGenerator.ProcessToStringBuilder(startInfo);

            Console.WriteLine(thisProcessOutput);
            Console.ReadKey();

            //4.3. parse output to show IPv4

            string patternIP = @"\d\d?\d?\.\d\d?\d?\.\d\d?\d?\.\d\d?\d?";
            string patternIPv4 = @"IPv4 Address(.*)\d\d?\d?\.\d\d?\d?\.\d\d?\d?\.\d\d?\d?";

            Regex regEx = new Regex(patternIP);
            Match matchIP = regEx.Match(thisProcessOutput);

            while (matchIP.Success)
            {
                Console.WriteLine("IP Address found at {0} with " +
                                  "value of {1}",
                    matchIP.Index,
                    matchIP.Value);

                matchIP = matchIP.NextMatch();
            }

            Console.WriteLine();

            Regex regExIPv4 = new Regex(patternIPv4);
            Match matchIPv4 = regExIPv4.Match(thisProcessOutput);

            while (matchIPv4.Success)
            {
                Console.WriteLine("IPv4 Address found at {0} with " +
                                  "value of {1}",
                    matchIPv4.Index,
                    matchIPv4.Value);

                matchIPv4 = matchIPv4.NextMatch();
            }
            
            Console.ReadKey();
        }
        // 4.4. Start Windows Media Player with music file longer than 10 sec

        // 4.5. Finish the process after 10 sec.
    }
}
