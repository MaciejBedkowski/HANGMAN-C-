using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman
{
    class Instruction
    {
        public static void ReadInstruction()
        {
            Console.WriteLine(@" _                                             
| |                                            
| |__   __ _ _ __   __ _ _ __ ___   __ _ _ __  
| '_ \ / _` | '_ \ / _` | '_ ` _ \ / _` | '_ \ 
| | | | (_| | | | | (_| | | | | | | (_| | | | |
|_| |_|\__,_|_| |_|\__, |_| |_| |_|\__,_|_| |_|
                    __/ |                      
                   |___/  ");
            Console.WriteLine(@"
Hangman is a simple game in which we have to guess the hidden passwords,
before our character hangs on the gallows.
We have 5 lives at the start. 
Life is subtracted each time the letter we enter is not in the password.
When we try to guess the password without having all the letters,
we have to take into account some ris.
If we fail to guess, we lose as many as 2 of our lives.
However, if we manage to guess, we get a bonus in the form of reducing our guessing time.
Initially our gallows has the form:
                      +---+
                      |   |
                          |
                          |
                          |
                          |
                    =========
With each wrong answer our gallows slowly hangs our character.
The final form of the gallows looks like this:
                      +---+
                      |   |
                      O   |
                     /|\  |
                     / \  |
                          |
                    =========

If your password is bothering you and you find it too hard,
you can always get a hint. However, taking a HINTS is associated with
worse scores and an increase in our playing time.
The 10 best places that reached the fastest time 
to guess the password are recorded in the results.
            ");
        }
    }
}
