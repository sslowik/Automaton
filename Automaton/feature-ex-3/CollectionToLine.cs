using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaton.feature_ex_3
{
    public static class CollectionToLine
    {
        // metoda tworząca z kolekcji string oddzielony spacją

        public static string ToLine<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentException("Source is null");
            return string.Join(",", source.Select(s => s.ToString()));
        }

    }
}
