using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATMpractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Weclome to the practice ATM! Please choose one:");
            Console.WriteLine("1 - Create a credit card");
            Console.WriteLine("2 - Loggin in");
            Console.WriteLine("3 - Exit");

            string userChoose = Console.ReadLine();

            if (userChoose == "1")
            {
                Registartion();
            }
            else if (userChoose == "2")
            {
                LogginIn();
            }
            else if (userChoose == "3")
            {
                Exit();
            }
        }

        static void Registartion()
        {
            string pathData = @""; //Please enter a path of file "dataBase.txt" in @"";

            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();

            Console.Write("Please enter your surname: ");
            string userSurname = Console.ReadLine();

            string userData = $"{userName},{userSurname}\n";
            File.AppendAllText(pathData, userData);

            Console.Write("Write an password: ");
            string password = Console.ReadLine();
            File.AppendAllText(pathData, $"{password}");

            Console.WriteLine("Succes! Your credit card was created.");

            Random rnd = new Random();
            for (int i = 0; i < 16; i++)
            {
                int rndNumber = rnd.Next(0, 9);
                Console.Write(rndNumber);
            }
            Console.Write(" ");
            Console.ReadKey();
            BalanceAndGame();
        }

        static void BalanceAndGame()
        {
            string pathMoneyData = @""; //Please enter a path of file "moneyData.txt" in @""
            Console.Clear();

            float userBalance = float.Parse(File.ReadLines(pathMoneyData).Last());

            Console.WriteLine($"Your balance is {userBalance}$. Do you wanna play? 1 - yes, 2 - no");
            string yesOrNo = Console.ReadLine();

            if (yesOrNo == "1")
            {
                Console.WriteLine("Choose game");
                while (true)
                {
                    Console.WriteLine("Nice! Choose x");
                    Console.WriteLine("1 - 1.5x");
                    Console.WriteLine("2 - 2x");
                    Console.WriteLine("3 - 5x");
                    Console.WriteLine("4 - Exit");

                    string x = Console.ReadLine();
                    if (x == "1")
                    {
                        Console.WriteLine("Please enter money value");
                        int dep1 = Convert.ToInt32(Console.ReadLine());

                        Random rnd = new Random();
                        int isCorrect = rnd.Next(0, 3);

                        Console.WriteLine("Guess the number from 0 to 2");
                        int check1 = Convert.ToInt32(Console.ReadLine());

                        if (check1 == isCorrect)
                        {
                            Console.WriteLine("Horray! You win!");
                            userBalance = userBalance + dep1 * 1.5f;
                            File.AppendAllText(pathMoneyData, $"{userBalance}\n");
                            Console.WriteLine($"Your balance is {userBalance}");
                            Console.ReadKey();
                        }
                        else
                        {
                            userBalance = userBalance - dep1;
                            Console.WriteLine($"You lose the number was {isCorrect}");
                            File.AppendAllText(pathMoneyData, $"{userBalance}\n");
                            Console.WriteLine($"Your balance is {userBalance}");
                            Console.ReadKey();
                        }
                        Console.WriteLine($"Your balance is {userBalance}");
                    }

                    if (x == "2")
                    {
                        Console.WriteLine("Please enter money value");
                        int dep2 = Convert.ToInt32(Console.ReadLine());

                        Random rnd = new Random();
                        int isCorrect2 = rnd.Next(0, 6);

                        Console.WriteLine("Guess the number from 0 to 5");
                        int check2 = Convert.ToInt32(Console.ReadLine());

                        if (check2 == isCorrect2)
                        {
                            Console.WriteLine("Horray! You win!");
                            userBalance = userBalance + dep2 * 2;
                            File.AppendAllText(pathMoneyData, $"{userBalance}\n");
                            Console.WriteLine($"Your balance is {userBalance}");
                            Console.ReadKey();
                        }
                        else
                        {
                            userBalance = userBalance - dep2;
                            Console.WriteLine($"You lose the number was {isCorrect2}");
                            File.AppendAllText(pathMoneyData, $"{userBalance}\n");
                            Console.WriteLine($"Your balance is {userBalance}");
                            Console.ReadKey();
                        }
                        Console.WriteLine($"Your balance is {userBalance}");
                    }

                    if (x == "3")
                    {
                        Console.WriteLine("Please enter money value");
                        int dep3 = Convert.ToInt32(Console.ReadLine());

                        Random rnd = new Random();
                        int isCorrect3 = rnd.Next(0, 11);

                        Console.WriteLine("Guess the number from 0 to 11");
                        int check3 = Convert.ToInt32(Console.ReadLine());

                        if (check3 == isCorrect3)
                        {
                            Console.WriteLine("Horray! You win!");
                            userBalance = userBalance + userBalance * 5;
                            File.AppendAllText(pathMoneyData, $"{userBalance}\n");
                            Console.WriteLine($"Your balance is {userBalance}");
                            Console.ReadKey();
                        }
                        else
                        {
                            userBalance = userBalance - dep3;
                            Console.WriteLine($"You lose the number was {isCorrect3}");
                            File.AppendAllText(pathMoneyData, $"{userBalance}\n");
                            Console.WriteLine($"Your balance is {userBalance}");
                            Console.ReadKey();
                        }
                    }
                    Console.WriteLine($"Your balance is {userBalance}");
                    File.AppendAllText(pathMoneyData, $"{userBalance}\n");

                    if (x == "4")
                    {
                        break;
                    }

                    Console.WriteLine("Press any key to clear");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else if (yesOrNo == "2")
            {
                Console.WriteLine("I don't have anything to do for you, so I'll see you later.");
                Console.ReadKey();
            }
        }

        static void LogginIn()
        {
            string pathCheckNameAndSurname = @""; //Please enter a path of file "dataBase.txt" in @""

            FileInfo fileInfo = new FileInfo(pathCheckNameAndSurname);

            if (fileInfo.Exists && fileInfo.Length == 0)
            {
                Console.WriteLine("You are not registred");
                Registartion();
            }
            else
            {
                Console.WriteLine("Please enter your name and surname like this: Name,Surname");
                string checkNameAndSurname = Console.ReadLine();
                string correctNameAndSurname = File.ReadAllLines(pathCheckNameAndSurname).First();

                Console.WriteLine("Please enter a password");
                string checkPass = Console.ReadLine();
                string correctPass = File.ReadAllLines(pathCheckNameAndSurname).Last();


                if (checkNameAndSurname == correctNameAndSurname && checkPass == correctPass)
                {
                    Console.WriteLine("Authorization complited");
                    BalanceAndGame();
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Name or Surname is not correct");
                    Console.ReadKey();
                }
            }
        }

        static void Exit()
        {
            Environment.Exit(0);
            Console.ReadKey();
        }
    }
}