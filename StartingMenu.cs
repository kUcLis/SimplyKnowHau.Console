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

        private static readonly Dictionary<ConsoleKey, string> _stMenuOptions = new()
        {
            {ConsoleKey.D1, "Your Animals"},
            {ConsoleKey.D2, "Make an apointment"},
            {ConsoleKey.D3, "History of apointments"},
            {ConsoleKey.D4, "?"},
            {ConsoleKey.D5, "?"},
            {ConsoleKey.D6, "?"},
            {ConsoleKey.D7, "?"},
            {ConsoleKey.Escape, "Quit"},
        };
        private static int activePosition = 1;



        static string simplyLogo = @"
                                                             
,---.o          |         |   /               |   |          
`---..,-.-.,---.|    ,   .|__/ ,---.,---.. . .|---|,---..   .
    ||| | ||   ||    |   ||  \ |   ||   || | ||   |,---||   |
`---'`` ' '|---'`---'`---|`   ``   '`---'`-'-'`   '`---^`---'
           |         `---'                                   
";

        public static string? userName = string.Empty;

        // Start aplikacji, sprawdzenie Usera, Wyświetlenie menu
        public static void Starts()
        {
            Login();
            DisplayStart();
            SelectMenuOption();
        }

        public static void DisplayLogo()
        {

            Console.Clear();
            Console.ForegroundColor = FG;
            Console.WriteLine(simplyLogo);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Made entirely by kUcLis");
            Console.ForegroundColor = FG;
            Console.WriteLine();

        }

        public static void Login()
        {
            DisplayLogo();

            string welcomeMessage = "Welcome user! Give me your name:";
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

        public static void DisplayStart()
        {
            Console.CursorVisible = false;

            DisplayLogo();

            Console.SetCursorPosition((Console.WindowWidth - _stMenuOptions.ElementAt(1).Value.Length) / 2, Console.CursorTop);
            Console.WriteLine($"Hi {userName}! What you want to do?");
            Console.WriteLine();

            for (int i = 1; i <= _stMenuOptions.Count; i++)
            {
                if (activePosition == i)
                {
                    Console.BackgroundColor = BG_ACTIVE;
                    Console.ForegroundColor = FG_ACTIVE;
                    if (i == _stMenuOptions.Count)
                    {
                        Console.SetCursorPosition((Console.WindowWidth - _stMenuOptions.ElementAt(1).Value.Length) / 2, Console.CursorTop);
                        Console.Write($" ESC. ");
                    }
                    else
                    {
                        Console.SetCursorPosition((Console.WindowWidth - _stMenuOptions.ElementAt(1).Value.Length) / 2, Console.CursorTop);
                        Console.Write($" {i}. ");
                    }
                    //Console.SetCursorPosition((Console.WindowWidth - _stMenuOptions.ElementAt(1).Value.Length) / 2, Console.CursorTop);
                    Console.WriteLine("{0,-30}", _stMenuOptions.ElementAt(i - 1).Value);
                    Console.BackgroundColor = BG;
                    Console.ForegroundColor = FG;
                }
                else
                {
                    if (i == _stMenuOptions.Count)
                    {
                        Console.SetCursorPosition((Console.WindowWidth - _stMenuOptions.ElementAt(1).Value.Length) / 2, Console.CursorTop);
                        Console.Write(" ESC.");
                    }
                    else
                    {
                        Console.SetCursorPosition((Console.WindowWidth - _stMenuOptions.ElementAt(1).Value.Length) / 2, Console.CursorTop);
                        Console.Write($" {i}. ");
                    }
                    //Console.SetCursorPosition((Console.WindowWidth - _stMenuOptions.ElementAt(1).Value.Length) / 2, Console.CursorTop);
                    Console.WriteLine(_stMenuOptions.ElementAt(i - 1).Value);
                }
            }


        }

        public static void SelectMenuOption()
        {
            do
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    activePosition = (activePosition > 1) ? --activePosition : _stMenuOptions.Count;
                    DisplayStart();
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    activePosition = (activePosition % _stMenuOptions.Count) + 1;
                    DisplayStart();
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    activePosition = _stMenuOptions.Count;
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

        public static void RunOption()
        {
            switch (activePosition)
            {
                case 1:

                    Console.ReadKey();
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
                    ExitMessage();
                    break;
            }
        }

        public static void ExitMessage()
        {

        }






    }
   
}
