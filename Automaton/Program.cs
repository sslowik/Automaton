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
            HelloSpeaker speak = new HelloSpeaker();
            ////speak.SayHello(ELanguage.PL);
            
            ELanguage[] languages = (ELanguage[])Enum.GetValues(typeof(ELanguage));

            foreach (var lang in languages)
            {
                speak.SayHello(lang);
            }

            // ex 3 - zabawa z plikami
            // generuję po 5 losowych plików z rozszerzeniem .txt, .zip, .xml: 

            FileGenerator filon = new FileGenerator();
            var theFile = filon.GenerateRandomFileName(@"D:\C\", "txt");

            filon.WriteFile(theFile); 

           

        }
    }
}
