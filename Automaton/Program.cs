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
            HelloSpeaker speak = new HelloSpeaker();
            ////speak.SayHello(ELanguage.PL);
            
            ELanguage[] languages = (ELanguage[])Enum.GetValues(typeof(ELanguage));

            foreach (ELanguage lang in languages)
            {
                speak.SayHello(lang);
            }

            FileGenerator filon = new FileGenerator();
            filon.WriteRandomFilePath();  
            Console.ReadKey();
        }
    }
}
