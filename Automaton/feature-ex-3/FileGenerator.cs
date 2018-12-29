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
        public void WriteRandomFilePath()
        {

            string filePath = string.Format(@"d:\temp\{0}.txt", Path.GetRandomFileName());
            Console.WriteLine(filePath);

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
