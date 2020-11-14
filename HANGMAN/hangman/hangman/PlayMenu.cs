using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman
{
    class PlayMenu
    {
        public static void Menu()
        {
            Console.WriteLine(@" _                                             
| |                                            
| |__   __ _ _ __   __ _ _ __ ___   __ _ _ __  
| '_ \ / _` | '_ \ / _` | '_ ` _ \ / _` | '_ \ 
| | | | (_| | | | | (_| | | | | | | (_| | | | |
|_| |_|\__,_|_| |_|\__, |_| |_| |_|\__,_|_| |_|
                    __/ |                      
                   |___/  ");
            Console.WriteLine("******************************************");
            Console.WriteLine("**  1 - Press to enter a letter         **");
            Console.WriteLine("**  2 - Press to guess the password     **");
            Console.WriteLine("**  3 - Take a hints                    **");
            Console.WriteLine("**  4 - Exit game                       **");
            Console.WriteLine("******************************************");
        }
    }
}
