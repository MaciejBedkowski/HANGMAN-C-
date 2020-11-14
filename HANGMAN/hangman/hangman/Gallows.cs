using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman
{
    class Gallows
    {
        public static void ReadGallows(int i)
        {
            switch (i)
            {
                case 0:
                    Console.WriteLine(@"
                      +---+
                      |   |
                          |
                          |
                          |
                          |
                    =========");
                    break;

                case 1:
                    Console.WriteLine(@"
                      +---+
                      |   |
                      O   |
                      |   |
                          |
                          |
                    =========");
                    break;

                case 2:
                    Console.WriteLine(@"
                      +---+
                      |   |
                      O   |
                     /|   |
                          |
                          |
                    =========");
                    break;

                case 3:
                    Console.WriteLine(@"
                      +---+
                      |   |
                      O   |
                     /|\  |
                          |
                          |
                    =========");
                    break;

                case 4:
                    Console.WriteLine(@"
                      +---+
                      |   |
                      O   |
                     /|\  |
                     /    |
                          |
                    =========");
                    break;

                case 5:
                    Console.WriteLine(@"
                      +---+
                      |   |
                      O   |
                     /|\  |
                     / \  |
                          |
                    =========");
                    break;

            }
        }
    }
}
