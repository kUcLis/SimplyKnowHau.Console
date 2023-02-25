using SimplyKnowHau_LogicAndData;
using SimplyKnowHau_LogicAndData.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public static void Starts(List<MenuItem> dictionary)
        {
            activePosition = 1;
            Login(dictionary);
            DisplayStart(dictionary);
            SelectMenuOption(dictionary);
            ChoosenOption(dictionary);
        }

        

        public static void Login(List<MenuItem> dictionary)
        {
            Logo.DisplayLogo();
            Console.CursorVisible = true;
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
                    else if (UserLogic.GetByName(userName) == null)
                    {
                        Logo.DisplayLogo();
                        Console.SetCursorPosition((Console.WindowWidth - welcomeMessage.Length) / 2, Console.CursorTop);
                        Console.WriteLine($"Hi {userName}!");
                        Console.SetCursorPosition((Console.WindowWidth - welcomeMessage.Length) / 2, Console.CursorTop);
                        Console.WriteLine("Remember that username, you were added to our database!");
                        Console.WriteLine();
                        Console.SetCursorPosition((Console.WindowWidth - welcomeMessage.Length) / 2, Console.CursorTop);
                        Console.WriteLine("Are you happy with your choice? (Y/N)");
                        Console.CursorVisible = false;
                        do
                        {
                            ConsoleKeyInfo key = Console.ReadKey();
                            if (key.Key == ConsoleKey.N)
                            {
                                userName = String.Empty;
                                Starts(dictionary);
                                break;
                            }
                            else if (key.Key == ConsoleKey.Y)
                            {
                                
                                break;
                            }
                        } while (true);

                        UserLogic.SetCurrentUser(UserLogic.AddUser(userName));
                        break;
                    }
                    else 
                    {
                        UserLogic.SetCurrentUser(UserLogic.GetByName(userName));
                        break; 
                    }
                } while (true);
            }


        }

        public static void DisplayStart(List<MenuItem> dictionary)
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
                    Console.WriteLine("{0,-30}", dictionary.ElementAt(i - 1).MenuString);
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
                    Console.WriteLine(dictionary.ElementAt(i - 1).MenuString);
                }
            }


        }

        public static void SelectMenuOption(List<MenuItem> dictionary)
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

        public static void ChoosenOption(List<MenuItem> dictionary)
        {

            if (dictionary == Dictionaries.stMenuOptions)
            {
                switch (activePosition)
                {
                    case 1:
                        var dictionary2 = new Dictionaries(2);
                        Starts(Dictionaries.AnimalMenuOptions);
                        break;
                    case 2:
                        var dictionary4 = new Dictionaries(5);
                        Starts(Dictionaries.ChooseAnimalMenuOptions);
                        break;
                    case 3:
                        var dictionary3 = new Dictionaries(4);
                        Starts(Dictionaries.AppointmentMenuOptions);
                        break;
                    case 4:

                        Starts(dictionary);
                        break;
                    case 5:
                        Starts(dictionary);
                        break;
                    case 6:
                        Starts(dictionary);
                        break;
                    case 7:
                        Starts(dictionary);
                        break;
                    case 8:
                        userName = String.Empty;
                        Starts(dictionary);
                        break;
                    case 9:
                        Exit(dictionary);
                        break;
                }
            }
            if (dictionary == Dictionaries.AnimalMenuOptions)
            {
                if(activePosition == 1)
                {
                    activePosition = 1;
                    CardMenu.AddCardAnimal(dictionary);
                }
                else if (activePosition == dictionary.Count) 
                {
                    activePosition = 1;
                    Exit(dictionary);
                }
                else if (dictionary.ElementAt(activePosition-1).MenuString != "No more animals to show")
                {
                    CardMenu.AnimalCard(AnimalLogic.GetById(dictionary.ElementAt(activePosition - 1).Id));
                }
                else
                {
                    Starts(dictionary);
                }
            }
            if (dictionary == Dictionaries.AppointmentMenuOptions)
            {
                if (activePosition == 1)
                {
                    activePosition = 1;
                    var dictionary4 = new Dictionaries(5);
                    Starts(Dictionaries.ChooseAnimalMenuOptions);
                }
                else if (activePosition == dictionary.Count)
                {
                    activePosition = 1;
                    Exit(dictionary);
                }
                else if (dictionary.ElementAt(activePosition - 1).MenuString != "No more appointments to show")
                {
                    CardMenu.AppointmentCard(AppointmentLogic.GetById(dictionary.ElementAt(activePosition - 1).Id));
                }
                else
                {
                    Starts(dictionary);
                }
            }
            if (dictionary == Dictionaries.ChooseAnimalMenuOptions)
            {
                if (dictionary.ElementAt(activePosition - 1).MenuString != "No more animals to show")
                {
                    CardMenu.AddCardAppointment(dictionary, AnimalLogic.GetById(dictionary.ElementAt(activePosition - 1).Id), UserLogic.GetCurrentUser());
                }
                else
                {
                    Starts(dictionary);
                }
            }

        }

        public static void Exit(List<MenuItem> dictionary)
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
                        activePosition = 0;
                        Console.ReadLine();
                        
                        Environment.Exit(0);
                        break;
                    }
                } while (true);

            }
            else if (dictionary == Dictionaries.AnimalMenuOptions)
            {
                Starts(Dictionaries.stMenuOptions);
            }
            else if (dictionary == Dictionaries.AppointmentMenuOptions)
            {
                Starts(Dictionaries.stMenuOptions);
            }
            else
            {
                var dictionary2 = new Dictionaries(2);
                Starts(Dictionaries.AnimalMenuOptions);
            }

        }
        // Short Menus
        public static void StartsShort(List<MenuItem> dictionary, object item)
        {
            activePosition = 1;
            DisplayStartShort(dictionary, item);
            SelectShortMenuOption(dictionary, item);
            ChoosenShortOption(dictionary, item);

        }
        public static void DisplayStartShort(List<MenuItem> dictionary, object item)
        {
            Console.CursorVisible = false;

            if (item.GetType() == typeof(Animal))
            {
                Logo.DisplayLogoAndCardAnimal((Animal)item);
            }
            else
            {
                Logo.DisplayLogoAndCardAppointment((Appointment)item);
            }

            Console.SetCursorPosition((Console.WindowWidth - welcomeMessage.Length) / 2, Console.CursorTop);
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
                    Console.WriteLine("{0,-30}", dictionary.ElementAt(i - 1).MenuString);
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
                    Console.WriteLine(dictionary.ElementAt(i - 1).MenuString);
                }
            }


        }
       
        public static void SelectShortMenuOption(List<MenuItem> dictionary, object item)
        {
            do
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    activePosition = (activePosition > 1) ? --activePosition : dictionary.Count;
                    DisplayStartShort(dictionary, item);
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    activePosition = (activePosition % dictionary.Count) + 1;
                    DisplayStartShort(dictionary, item);
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
                    break;
                }
            } while (true);
        }

       
        public static void ChoosenShortOption(List<MenuItem> dictionary, object item)
        {

             switch (activePosition)
                {
                    case 1:
                        var dictionary2 = new Dictionaries(2);
                        Starts(Dictionaries.AnimalMenuOptions);
                        break;
                    case 2:
                        EditCard.EditCardAnimal(dictionary, (Animal)item);
                        break;
                    default:
                        Exit(dictionary);
                        break;
             }
        }
            
            




    }
   
}
