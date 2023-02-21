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
            DisplayLogo();

            Console.ReadLine();


        }






    }
   
}
