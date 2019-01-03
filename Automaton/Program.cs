using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
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

            // 4.1. Process.Start("ipconfig", "/all");

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/k ipconfig/all";
            //startInfo.UseShellExecute = false;
            //startInfo.RedirectStandardOutput = true;
            //startInfo.RedirectStandardError = true;

            // 4.2. display the result in console

            Process process = Process.Start(startInfo);
            process.WaitForExit();

            // 4.3. Parse output - display all IPv4 addresses 

            //var output = new StringBuilder();
            //process.OutputDataReceived += new DataReceivedEventHandler((sender, eventArgs) => output.AppendLine(
            //    $"OUT: {eventArgs.Data}"));
            //process.ErrorDataReceived += new DataReceivedEventHandler((sender, eventArgs) => output.AppendLine(
            //    $"ERR: {eventArgs.Data}"));




            // 4.4. Start Windows Media Player with music file longer than 10 sec

            // 4.5. Finish the process after 10 sec.

            //

            //Process process = new Process();

            //// redirect the output
            //process.StartInfo.RedirectStandardOutput = true;
            //process.StartInfo.RedirectStandardError = true;
            //process.StartInfo.FileName = "ipconfig";
            //process.StartInfo.Arguments = "/all";


            //process.Out
            //// direct start
            //process.StartInfo.UseShellExecute = false;

            //process.S
            //process.Start("ipconfig", "/all");
            //// start our event pumps
            //process.BeginOutputReadLine();
            //process.BeginErrorReadLine();

            //// until we are done
            //process.WaitForExit();

            //// do whatever you need with the content of sb.ToString();

            //Console.ReadKey();
        }


    }
}
