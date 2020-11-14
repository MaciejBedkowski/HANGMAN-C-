using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman
{
    class MenuGame
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
            Console.WriteLine("**  1 - Press to start game             **");
            Console.WriteLine("**  2 - Show game instruction           **");
            Console.WriteLine("**  3 - Show score                      **");
            Console.WriteLine("**  4 - exit game                       **");
            Console.WriteLine("******************************************");
        }
    }
}
