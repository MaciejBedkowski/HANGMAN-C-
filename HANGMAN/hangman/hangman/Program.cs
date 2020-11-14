using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playGame = true;
            bool endGame = false;
            int choiceGameNumber;
            string path = "countries_and_capitals.txt";
            string pathScore = "score.txt";
            List<string> cityState = new List<string>();
            List<string> highScore = new List<string>();
            List<string> highScorePlayer = new List<string>();
            List<string> highScoreTime = new List<string>();
            Random randomPasswordNumber = new Random();
            List<string> gamePassword = new List<string>();
            string passwordCity = "";
            string passwordState = "";
            string hidePassword = "";
            int miss = 0;
            int life = 5;
            string givenLetters = "";
            List<string> passLetters = new List<string>();
            string[] alphabet = { "A","B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "W", "X", "Y", "Z" };
            bool hints = false;
            string decision;
            int decisionNumber;
            string takeALetter;
            string listLetters = "";
            string tmpPassword = "";
            int time = 0;
            string nickName = "";
            bool change = false;

            while (playGame)
            {
                Console.Clear();
                MenuGame.Menu();
                highScorePlayer.Clear(); //reset 
                highScoreTime.Clear(); //reset
                highScore.Clear(); //reset
                change = false; // reset

                using (StreamReader sr = File.OpenText(pathScore))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        highScore.Add(s);
                    }
                }

                foreach (string word in highScore)
                {
                    highScorePlayer.Add(word.Split('|')[0]);
                    highScoreTime.Add(word.Split('|')[1]);
                }

                string choiceGame = Console.ReadLine();

                try
                {
                    choiceGameNumber = int.Parse(choiceGame);
                }
                catch
                {
                    Console.WriteLine("Enter value is not corect");
                    continue;
                }

                if (choiceGameNumber > 4 && choiceGameNumber < 1)
                {
                    Console.WriteLine("Enter value is not corect");
                    continue;
                }

                switch (choiceGameNumber)
                {
                    case 1:
                        
                        gamePassword.Clear(); //reset password
                        hidePassword = ""; //reset hide password
                        endGame = false; // reset game stats
                        hints = false; // reset hints
                        miss = 0; // reset miss
                        life = 5; // reset life total
                        passLetters.Clear(); // reset given letters
                        listLetters = ""; // reset given letters
                        time = 0; // reset time

                        Stopwatch stopwatch = new Stopwatch(); //Start stopwatch
                        stopwatch.Start();

                        using (StreamReader sr = File.OpenText(path))
                        {
                            string s = "";
                            while ((s = sr.ReadLine()) != null)
                            {
                                cityState.Add(s);
                            }
                        }


                        int passwordNumber = randomPasswordNumber.Next(cityState.Count);

                        gamePassword.Add(cityState[passwordNumber].Split('|')[0]);
                        gamePassword.Add(cityState[passwordNumber].Split('|')[1]);
                        
                        passwordCity = gamePassword[1].Substring(1);
                        passwordState = gamePassword[0];
                        passwordCity = passwordCity.ToUpper();

                        for(int i = 0; i < passwordCity.Length; i++)
                        {
                            if(passwordCity[i] == ' ')
                            {
                                hidePassword += " ";
                            }
                            hidePassword += '-';
                        }
                        while (!endGame)
                        {
                            Console.Clear();
                            PlayMenu.Menu();
                            
                            Console.WriteLine(@"You have :{0} Lifes   The given letters:{1}", life, listLetters);
                            Console.WriteLine(@"Password: {0}",hidePassword);
                            Gallows.ReadGallows(miss);

                            Console.WriteLine("Enter You're decision");
                            decision = Console.ReadLine();
                            try
                            {
                                decisionNumber = int.Parse(decision);
                            }
                            catch
                            {
                                Console.WriteLine("Enter value is not corect");
                                continue;
                            }

                            if (decisionNumber > 4 && decisionNumber < 1)
                            {
                                Console.WriteLine("Enter value is not corect");
                                continue;
                            }
                            switch (decisionNumber)
                            {
                                case 1:
                                    Console.WriteLine("Enter a letter");
                                    takeALetter = Console.ReadLine();
                                    takeALetter = takeALetter.ToUpper();
                                    
                                    if (alphabet.Contains(takeALetter))
                                    {
                                        if(passLetters.Contains(takeALetter))
                                        {
                                            Console.WriteLine("You entered this letter");
                                            Console.WriteLine("Press any key");
                                            Console.ReadKey();
                                            continue;
                                        }
                                        else
                                        {
                                            if(passwordCity.Contains(takeALetter))
                                            {
                                                string tmp ="";
                                                for(int i = 0; i <passwordCity.Length; i++)
                                                {
                                                    if(takeALetter[0] == passwordCity[i])
                                                    {
                                                        tmp += passwordCity[i];
                                                    }
                                                    else
                                                    {
                                                        tmp += hidePassword[i];
                                                    }
                                                }
                                                hidePassword = tmp;
                                                passLetters.Add(takeALetter);
                                                listLetters += takeALetter + ",";
                                                tmp = "";
                                                if(hidePassword == passwordCity)
                                                {
                                                    Console.WriteLine("YOU WIN THE GAME!!!");
                                                    time = (int)(stopwatch.ElapsedMilliseconds / 1000);
                                                    if(hints)
                                                    {
                                                        time += 100;
                                                    }
                                                    time -= life * 10;
                                                    Console.WriteLine("Youre time is:{0} seconds", time);
                                                    Console.WriteLine("You entered {0} letters", passLetters.Count());
                                                    //////////////////////////////////////////////
                                                    for(int i = 0; i< highScoreTime.Count();i++)
                                                    {
                                                       if(time < int.Parse(highScoreTime[i]))
                                                        {
                                                            Console.WriteLine("Your score is good enough if the game is played in the hall of fame!");
                                                            Console.Write("Enter You're nickname:");
                                                            nickName = Console.ReadLine();
                                                            highScoreTime.Insert(i, time.ToString());
                                                            highScorePlayer.Insert(i, nickName);
                                                            change = true;
                                                            break;
                                                        }
                                                    }
                                                    if(highScoreTime.Count()<10 && !change)
                                                    {
                                                        Console.WriteLine("Your score is good enough if the game is played in the hall of fame!");
                                                        Console.Write("Enter You're nickname:");
                                                        nickName = Console.ReadLine();
                                                        highScoreTime.Add(time.ToString());
                                                        highScorePlayer.Add(nickName);
                                                    }
                                                using (System.IO.StreamWriter file =
                                                new System.IO.StreamWriter(pathScore))
                                                    {
                                                        if (highScorePlayer.Count > 10)
                                                        {
                                                            for (int j = 0; j < 10; j++)
                                                            {
                                                                file.WriteLine(highScorePlayer[j] + "| " + highScoreTime[j]);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            for (int j = 0; j < highScorePlayer.Count(); j++)
                                                            {
                                                                file.WriteLine(highScorePlayer[j] + "| " + highScoreTime[j]);
                                                            }
                                                        }

                                                    }
                                                    //////////////////////////////////////////////
                                                    endGame = true;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("You miss, this letter is not contains in password");
                                                passLetters.Add(takeALetter);
                                                listLetters += takeALetter + ",";
                                                life--;
                                                miss++;
                                                if(life<1)
                                                {
                                                    Console.WriteLine("YOU LOST!");
                                                    
                                                    endGame = true;
                                                }
                                                Console.WriteLine("Press any key");
                                                Console.ReadKey();
                                            }
                                        }
                                    }
                                    break;

                                case 2:
                                    Console.WriteLine("Guess the password");
                                    tmpPassword = Console.ReadLine();
                                    if(tmpPassword.ToUpper() == passwordCity)
                                    {
                                        Console.WriteLine("YOU WIN THE GAME!!!");
                                        stopwatch.Stop();
                                        time = (int)(stopwatch.ElapsedMilliseconds / 1000);
                                        if (hints)
                                        {
                                            time += 100;
                                        }
                                        time -= life * 10;
                                        Console.WriteLine("Youre time is:{0} seconds", time);
                                        Console.WriteLine("You entered {0} letters", passLetters.Count());
                                        //////////////////////////////////////////////
                                        for (int i = 0; i < highScoreTime.Count(); i++)
                                        {
                                            if (time < int.Parse(highScoreTime[i]))
                                            {
                                                Console.WriteLine("Your score is good enough if the game is played in the hall of fame!");
                                                Console.Write("Enter You're nickname:");
                                                nickName = Console.ReadLine();
                                                highScoreTime.Insert(i, time.ToString());
                                                highScorePlayer.Insert(i, nickName);
                                                change = true;
                                                break;
                                            }
                                        }
                                        if (highScoreTime.Count() < 10 && !change)
                                        {
                                            Console.WriteLine("Your score is good enough if the game is played in the hall of fame!");
                                            Console.Write("Enter You're nickname:");
                                            nickName = Console.ReadLine();
                                            highScoreTime.Add(time.ToString());
                                            highScorePlayer.Add(nickName);
                                        }
                                        using (System.IO.StreamWriter file =
                                        new System.IO.StreamWriter(pathScore))
                                        {
                                            if (highScorePlayer.Count > 10)
                                            {
                                                for (int j = 0; j < 10; j++)
                                                {
                                                    file.WriteLine(highScorePlayer[j] + "| " + highScoreTime[j]);
                                                }
                                            }
                                            else
                                            {
                                                for (int j = 0; j < highScorePlayer.Count(); j++)
                                                {
                                                    file.WriteLine(highScorePlayer[j] + "| " + highScoreTime[j]);
                                                }
                                            }

                                        }
                                        //////////////////////////////////////////////


                                        endGame = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You miss, You're password is not correct!");
                                        miss += 2;
                                        life -= 2;
                                        if (life < 1)
                                        {
                                            Console.WriteLine("YOU LOST!");

                                            endGame = true;
                                        }
                                        Console.WriteLine("Press any key");
                                        Console.ReadKey();
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("The hints! The state os city is:{0}", passwordState);
                                    hints = true;
                                    Console.WriteLine("Press any key");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        

                        Console.ReadKey();

                        break;
                    case 2:
                        Console.Clear();
                        Instruction.ReadInstruction();
                        Console.WriteLine("Press any key");
                        Console.ReadKey();
                        break;
                    case 3:
                        HihgScore.ReadScore(highScorePlayer, highScoreTime);
                        Console.WriteLine("Press any key");
                        Console.ReadKey();
                        break;
                    case 4:
                        playGame = false;
                        break;
                }

            }
            
        }
    }
}
