﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplyKnowHau_LogicAndData;
using SimplyKnowHau_LogicAndData.Model;

namespace SimplyKnowHau_Console
{
    internal class CardMenu
    {
        const ConsoleColor FG = ConsoleColor.DarkYellow;
        const ConsoleColor FG_ACTIVE = ConsoleColor.White;

        public static List<CardItem>? cardItemsAnimal = new();

        public CardMenu()
        {
            
                cardItemsAnimal.Clear();
                cardItemsAnimal.Add(new CardItem(1, "Name of the animal:"));
                cardItemsAnimal.Add(new CardItem(2, "Specie:"));
                cardItemsAnimal.Add(new CardItem(3, "Date of birth (YYYY-MM-DD):"));
            


        }



        public CardMenu(Animal animal)
        {
            
           
                cardItemsAnimal.Clear();
                cardItemsAnimal.Add(new CardItem(1, "Animal Id: ", animal.Id.ToString()));
                cardItemsAnimal.Add(new CardItem(2, "Name: ", animal.Name));
                cardItemsAnimal.Add(new CardItem(3, "Specie: ", animal.AnimalCategory.Specie));
                cardItemsAnimal.Add(new CardItem(4, "Age: ", AnimalLogic.Age(animal).ToString()));
                cardItemsAnimal.Add(new CardItem(5, "Date of birth: ", animal.DateOfBirth.ToShortDateString()));
                cardItemsAnimal.Add(new CardItem(6, "Date of last visit: ", "TODO"));
                cardItemsAnimal.Add(new CardItem(7, "Description of the visit: ", "TODO"));
                cardItemsAnimal.Add(new CardItem(8, "Receives: ", "TODO"));
                
                


        }


        public static void AddCardAnimal(List<MenuItem> dictionary)
        {
            var cardlist = new CardMenu();
            bool broken = false;
            Logo.DisplayLogo();
            Console.CursorVisible = true;

            for (int i = 1; i <= cardItemsAnimal.Count; i++)
            {
                
                if(i == 2)
                {
                    Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                    Console.ForegroundColor= FG_ACTIVE;
                    Console.WriteLine($"Spiecies you can choose:{SpeciesLogic.SpeciesToString()}");
                    Console.ForegroundColor = FG;
                }
                Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                Console.Write($"{cardItemsAnimal.ElementAt(i - 1).CardString}");

                do
                {
                    string? userInsert = Console.ReadLine();
                    if (userInsert == string.Empty)
                    {
                        Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Type something!");
                        Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                        Console.WriteLine("ESC - To go back to Animal Menu. Press any key now to continue.");
                        Console.ForegroundColor = FG;
                        Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                        ConsoleKeyInfo key = Console.ReadKey();
                        if (key.Key != ConsoleKey.Escape)
                        {
                            i--;
                            break;

                        }
                        else
                        {
                            broken = true;
                            i = cardItemsAnimal.Count();
                            break;
                        }
                    }
                    if (i == 1)
                    {
                        if (userInsert.Length > 15)
                        {
                            Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Maximum 15 characters!");
                            Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                            Console.WriteLine("ESC - To go back to Animal Menu. Press any key now to continue.");
                            Console.ForegroundColor = FG;
                            Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                            ConsoleKeyInfo key = Console.ReadKey();
                            if (key.Key != ConsoleKey.Escape)
                            {
                                i--;
                                break;

                            }
                            else
                            {
                                broken = true;
                                i = cardItemsAnimal.Count();
                                break;
                            }
                        }
                        if (!broken)
                        {
                            cardItemsAnimal.ElementAt(i - 1).CardContent = userInsert;
                        }
                        break;
                    }
                    else if(i == 2)
                    {
                        if (SpeciesLogic.GetByName(userInsert) == null)
                        {
                            Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                            Console.ForegroundColor = FG_ACTIVE;
                            Console.WriteLine($"Spiecies you can choose:{SpeciesLogic.SpeciesToString()}");
                            Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Must be in the one of Categories!");
                            Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                            Console.WriteLine("ESC - To go back to Animal Menu. Press any key now to continue.");
                            Console.ForegroundColor = FG;
                            Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                            ConsoleKeyInfo key = Console.ReadKey();
                            if (key.Key != ConsoleKey.Escape)
                            {
                                i--;
                                break;

                            }
                            else
                            {
                                broken = true;
                                i = cardItemsAnimal.Count();
                                break;
                            }
                        }
                        if (!broken)
                        {
                            cardItemsAnimal.ElementAt(i - 1).CardContent = userInsert;
                        }
                        break;
                    }
                    else
                    {
                        if (!DateTime.TryParse(userInsert, out DateTime result))
                        {
                            Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                            Console.ForegroundColor = FG_ACTIVE;
                            Console.WriteLine("It has to be in forma YYYY-MM-DD. Example: 1989-03-06");
                            Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Format the date correctly!");
                            Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                            Console.WriteLine("ESC - To go back to Animal Menu. Press any key now to continue.");
                            Console.ForegroundColor = FG;
                            Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                            ConsoleKeyInfo key = Console.ReadKey();
                            if (key.Key != ConsoleKey.Escape)
                            {
                                i--;
                                break;

                            }
                            else
                            {
                                broken = true;
                                i = cardItemsAnimal.Count();
                                break;
                            }
                        }
                        if (!broken)
                        {
                            cardItemsAnimal.ElementAt(i - 1).CardContent = userInsert;
                        }
                        break;
                    }
                } while (true);
            }
            if (!broken)
            {
                AnimalLogic.AddAnimal(
                    cardItemsAnimal.ElementAt(0).CardContent,
                    SpeciesLogic.GetByName(cardItemsAnimal.ElementAt(1).CardContent),
                    DateTime.Parse(cardItemsAnimal.ElementAt(2).CardContent)
                    );
            }
            cardItemsAnimal.Clear();
            var dictionary2 = new Dictionaries(2);
            StartingMenu.Starts(Dictionaries.AnimalMenuOptions);
        }

        

        public static void AnimalCard(Animal animal)
        {
            var dictionary = new Dictionaries(3);
            StartingMenu.StartsShort(Dictionaries.shortMenu, animal);

        }
    }
}
