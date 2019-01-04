using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Automaton.feature_ex_5
{
    public static class ExtendThis
    {
        public static string RemoveWhiteSpaces(this String str)
        {
            return str.Replace(" ", ""); 
        }

        public static bool StringEmpty(this String str)
        {
            return (str == null) || (str != null && str.Length == 0);
        }

        public static string ReplaceTabsWithWhitespaces(this String str)
        {
            return Regex.Replace(Regex.Replace(str, "\v", @"\s"), "\t", @"\s");
        }
    }
}
