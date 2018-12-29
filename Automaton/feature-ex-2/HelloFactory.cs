using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaton.feature_ex_2
{
    public class HelloFactory
    {
        public virtual ISayHello CreateSpeaker(ELanguage language)
        {
            ISayHello speaker = null;
            switch (language)
            {
                case ELanguage.PL:
                    speaker = new HelloPl();
                    break;
                case ELanguage.ENG:
                    speaker = new HelloEng();
                    break;
                case ELanguage.GER:
                    speaker = new HelloGer();
                    break;
                default:
                    break;
            }
            return speaker;
        }

    }
}