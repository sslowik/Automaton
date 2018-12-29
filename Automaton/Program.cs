using System;
using System.Linq;
using Automaton.feature_ex_2;

namespace Automaton
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloSpeaker speak = new HelloSpeaker();
            ////speak.SayHello(ELanguage.PL);
            //Console.ReadKey();

            ELanguage[] languages = (ELanguage[])Enum.GetValues(typeof(ELanguage));

            foreach (ELanguage lang in languages)
            {
                speak.SayHello(lang);
            }
                Console.ReadKey(); 
        }
    }
}
