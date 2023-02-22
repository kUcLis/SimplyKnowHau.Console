using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyKnowHau_Console
{
    public class StartingMenu
    {
        const ConsoleColor BG = ConsoleColor.Black;
        const ConsoleColor BG_ACTIVE = ConsoleColor.DarkYellow;
        const ConsoleColor FG = ConsoleColor.DarkYellow;
        const ConsoleColor FG_ACTIVE = ConsoleColor.White;

        
        private static int activePosition = 1;

        private static string? welcomeMessage = "Welcome user! Give me your name:";



        public static string? userName = string.Empty;

        // Start aplikacji, sprawdzenie Usera, Wyświetlenie menu
        public static void Starts(Dictionary<ConsoleKey,string> dictionary)
        {
            Login();
            DisplayStart(dictionary);
            SelectMenuOption(dictionary);
            ChoosenOption(dictionary);
        }

        

        public static void Login()
        {
            Logo.DisplayLogo();
            if (userName == string.Empty)
            {

                
                Console.SetCursorPosition((Console.WindowWidth - welcomeMessage.Length) / 2, Console.CursorTop);
                Console.WriteLine(welcomeMessage);

                do
                {
                    Console.SetCursorPosition((Console.WindowWidth - welcomeMessage.Length) / 2, Console.CursorTop);
                    userName = Console.ReadLine();
                    if (userName == string.Empty)
                    {
                        Console.SetCursorPosition((Console.WindowWidth - welcomeMessage.Length) / 2, Console.CursorTop);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("First, give me your name!");
                        Console.ForegroundColor = FG;
                    }
                    else if (userName == "Tutaj metoda z klasy czy cos zwrocila")
                    {
                        // metoda z klasy user szukająca użytkownika
                        break;
                    }
                    else // tutaj jesli nowy uzytkownik
                    {
                        Console.WriteLine($"Hi {userName}! Remember that username, you were added to our database!");
                        break; // Dodać metodą dodająca użytkownika, Password for fun? 
                    }
                } while (true);
            }


        }

        public static void DisplayStart(Dictionary<ConsoleKey,string> dictionary)
        {
            Console.CursorVisible = false;

            Logo.DisplayLogo();

            Console.SetCursorPosition((Console.WindowWidth - welcomeMessage.Length) / 2, Console.CursorTop);
            Console.WriteLine($"Hi {userName}! What you want to do?");
            Console.WriteLine();

            for (int i = 1; i <= dictionary.Count; i++)
            {
                if (activePosition == i)
                {
                    Console.BackgroundColor = BG_ACTIVE;
                    Console.ForegroundColor = FG_ACTIVE;
                    if (i == dictionary.Count)
                    {
                        Console.SetCursorPosition((Console.WindowWidth - welcomeMessage.Length) / 2, Console.CursorTop);
                        Console.Write($" ESC. ");
                    }
                    else
                    {
                        Console.SetCursorPosition((Console.WindowWidth - welcomeMessage.Length) / 2, Console.CursorTop);
                        Console.Write($" {i}. ");
                    }
                    //Console.SetCursorPosition((Console.WindowWidth - _stMenuOptions.ElementAt(1).Value.Length) / 2, Console.CursorTop);
                    Console.WriteLine("{0,-30}", dictionary.ElementAt(i - 1).Value);
                    Console.BackgroundColor = BG;
                    Console.ForegroundColor = FG;
                }
                else
                {
                    if (i == dictionary.Count)
                    {
                        Console.SetCursorPosition((Console.WindowWidth - welcomeMessage.Length) / 2, Console.CursorTop);
                        Console.Write(" ESC.");
                    }
                    else
                    {
                        Console.SetCursorPosition((Console.WindowWidth - welcomeMessage.Length) / 2, Console.CursorTop);
                        Console.Write($" {i}. ");
                    }
                    //Console.SetCursorPosition((Console.WindowWidth - _stMenuOptions.ElementAt(1).Value.Length) / 2, Console.CursorTop);
                    Console.WriteLine(dictionary.ElementAt(i - 1).Value);
                }
            }


        }

        public static void SelectMenuOption(Dictionary<ConsoleKey, string> dictionary)
        {
            do
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    activePosition = (activePosition > 1) ? --activePosition : dictionary.Count;
                    DisplayStart(dictionary);
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    activePosition = (activePosition % dictionary.Count) + 1;
                    DisplayStart(dictionary);
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    activePosition = dictionary.Count;
                    break;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else
                {
                    if (key.Key == ConsoleKey.D1) activePosition = 1;
                    if (key.Key == ConsoleKey.D2) activePosition = 2;
                    if (key.Key == ConsoleKey.D3) activePosition = 3;
                    if (key.Key == ConsoleKey.D4) activePosition = 4;
                    if (key.Key == ConsoleKey.D5) activePosition = 5;
                    if (key.Key == ConsoleKey.D6) activePosition = 6;
                    if (key.Key == ConsoleKey.D7) activePosition = 7;
                    if (key.Key == ConsoleKey.D8) activePosition = 8;
                    break;
                }
            } while (true);
        }

        public static void ChoosenOption(Dictionary<ConsoleKey, string> dictionary)
        {

            if (dictionary == Dictionaries.stMenuOptions)
            {
                switch (activePosition)
                {
                    case 1:

                        Starts(Dictionaries.AnimalMenuOptions);
                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:


                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:

                        break;
                    default:
                        Exit(dictionary);
                        break;
                }
            }
            if (dictionary == Dictionaries.AnimalMenuOptions)
            {
                switch (activePosition)
                {
                    case 1:

                        //Starts();
                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:


                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:

                        break;
                    default:
                        Exit(dictionary);
                        break;
                }
            }

        }

        public static void Exit(Dictionary<ConsoleKey, string> dictionary)
        {
            Logo.DisplayLogo();

            if (dictionary == Dictionaries.stMenuOptions)
            {
                Console.SetCursorPosition((Console.WindowWidth - welcomeMessage.Length) / 2, Console.CursorTop);
                Console.WriteLine("You really want to quit? (Y/N)");

                do
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.N)
                    {
                        Starts(dictionary);
                        break;
                    }
                    else if (key.Key == ConsoleKey.Y)
                    {
                        Logo.DisplayLogo();
                        Console.SetCursorPosition((Console.WindowWidth - welcomeMessage.Length) / 2, Console.CursorTop);
                        Console.WriteLine($"Bye {userName}");
                        Console.ReadLine();
                        break;
                    }
                } while (true);
            }
            else
            {
                Starts(Dictionaries.stMenuOptions);
            }

        }






    }
   
}
