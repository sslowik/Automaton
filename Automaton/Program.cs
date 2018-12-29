using System;
using Automaton.feature_ex_2;

namespace Automaton
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloSpeaker speak = new HelloSpeaker();
            speak.SayHello(ELanguage.GER);
            Console.ReadKey(); 
        }
    }
}
