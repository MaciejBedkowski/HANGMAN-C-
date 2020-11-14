using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman
{
    class HihgScore
    {
        public static void ReadScore(List<string> a, List<string> b)
        {
            Console.WriteLine("HIGH SCORE:");
            for(int i =0; i<a.Count();i++)
            {
                Console.WriteLine(@"{0}. {1} - {2} seconds", i+1, a[i], b[i]);
            }
        }
    }
}
