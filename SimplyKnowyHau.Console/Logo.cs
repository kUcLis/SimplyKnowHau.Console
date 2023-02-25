using SimplyKnowHau_LogicAndData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyKnowHau_Console
{
    internal class Logo
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

        public static void DisplayLogo()
        {


            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = FG;
            Console.WriteLine(simplyLogo);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Made entirely by kUcLis");
            Console.ForegroundColor = FG;
            Console.WriteLine();

        }

        public static void DisplayLogoAndCardAnimal(Animal animal)
        {
            var cardlist = new CardMenu(animal);

            Logo.DisplayLogo();

            for (int i = 0; i < CardMenu.cardItemsAnimal.Count; i++)
            {

                Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                Console.Write($"{CardMenu.cardItemsAnimal.ElementAt(i).CardString}");
                Console.ForegroundColor = FG_ACTIVE;
                Console.Write($"{CardMenu.cardItemsAnimal.ElementAt(i).CardContent}");
                Console.WriteLine();
                Console.ForegroundColor = FG;
            }

            



        }

        public static void DisplayLogoAndCardAppointment(Appointment appointment)
        {
            var cardlist = new CardMenu(appointment);

            Logo.DisplayLogo();

            for (int i = 0; i < CardMenu.cardItemsAppointment.Count; i++)
            {

                Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                Console.Write($"{CardMenu.cardItemsAppointment.ElementAt(i).CardString}");
                Console.ForegroundColor = FG_ACTIVE;
                while (true)
                {
                    if (CardMenu.cardItemsAppointment.ElementAt(i).CardContent.Length > 60)
                    {

                        Console.WriteLine();
                        Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                        int j = 50;
                        string stringhelper = CardMenu.cardItemsAppointment.ElementAt(i).CardContent;
                        while (true)
                        {
                            if (stringhelper[j] != ' ')
                            {
                                j++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        stringhelper = stringhelper.Substring(0, j);
                        Console.Write(stringhelper);
                        stringhelper = CardMenu.cardItemsAppointment.ElementAt(i).CardContent;
                        Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                        CardMenu.cardItemsAppointment.ElementAt(i).CardContent = stringhelper.Substring(j + 1, stringhelper.Length - (j + 1));

                    }
                    else
                    {
                        Console.Write($"{CardMenu.cardItemsAppointment.ElementAt(i).CardContent}");
                        break;
                    }
                }
                Console.WriteLine();
                Console.ForegroundColor = FG;
            }





        }



    }
}
