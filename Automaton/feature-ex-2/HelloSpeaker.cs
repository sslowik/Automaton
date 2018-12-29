using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaton.feature_ex_2
{
    public class HelloSpeaker
    {
        ISayHello speaker = null; 
        public void SayHello(ELanguage language)
        {
            HelloFactory factory = new HelloFactory();
            this.speaker = factory.CreateSpeaker(language);
            this.speaker.SayHello(); 
        }
    }
}
