using SimplyKnowHau_LogicAndData;
using SimplyKnowHau_LogicAndData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyKnowHau_Console
{
    public class EditCard
    {
        const ConsoleColor FG = ConsoleColor.DarkYellow;
        const ConsoleColor FG_ACTIVE = ConsoleColor.White;


        public static List<CardItem>? editCardItemsAnimal = new();

        public EditCard(Animal animal)
        {
            editCardItemsAnimal.Clear();
            editCardItemsAnimal.Add(new CardItem(1, "Name: ", animal.Name));
            editCardItemsAnimal.Add(new CardItem(2, "Specie: ", animal.AnimalCategory.Specie));
            editCardItemsAnimal.Add(new CardItem(3, "Date of birth: ", animal.DateOfBirth.ToShortDateString()));

        }
        public static void EditCardAnimal(List<MenuItem> dictionary, Animal animal)
        {
            var cardlist = new EditCard(animal);
            bool broken = false;
            Logo.DisplayLogo();
            Console.CursorVisible = true;


            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
            Console.WriteLine("Leave empty if you don't want to change value");
            for (int i = 1; i <= editCardItemsAnimal.Count; i++)
            {

                if (i == 2)
                {
                    Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                    Console.ForegroundColor = FG_ACTIVE;
                    Console.WriteLine($"Spiecies you can choose:{SpeciesLogic.SpeciesToString()}");
                    Console.ForegroundColor = FG;
                }
                Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                Console.ForegroundColor = FG;
                Console.Write($"{editCardItemsAnimal.ElementAt(i - 1).CardString}");
                Console.Write($"{editCardItemsAnimal.ElementAt(i - 1).CardContent}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                Console.Write("New :");

                do
                {
                    string? userInsert = Console.ReadLine();
                    if (userInsert == string.Empty)
                    {

                        break;
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
                                i = editCardItemsAnimal.Count();
                                break;
                            }
                        }
                        if (!broken)
                        {
                            editCardItemsAnimal.ElementAt(i - 1).CardContent = userInsert;
                        }
                        break;
                    }
                    else if (i == 2)
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
                                i = editCardItemsAnimal.Count();
                                break;
                            }
                        }
                        if (!broken)
                        {
                            editCardItemsAnimal.ElementAt(i - 1).CardContent = userInsert;
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
                                i = editCardItemsAnimal.Count();
                                break;
                            }
                        }
                        if (!broken)
                        {
                            editCardItemsAnimal.ElementAt(i - 1).CardContent = userInsert;
                        }
                        break;
                    }
                } while (true);
            }
            if (!broken)
            {
                DataMenager.Animals.First(c => c.Id == animal.Id).Name = editCardItemsAnimal.ElementAt(0).CardContent;
                animal.Name = editCardItemsAnimal.ElementAt(0).CardContent;

                DataMenager.Animals.First(c => c.Id == animal.Id).AnimalCategory = SpeciesLogic.GetByName(editCardItemsAnimal.ElementAt(1).CardContent);
                animal.AnimalCategory = SpeciesLogic.GetByName(editCardItemsAnimal.ElementAt(1).CardContent);

                DataMenager.Animals.First(c => c.Id == animal.Id).DateOfBirth = DateTime.Parse(editCardItemsAnimal.ElementAt(2).CardContent);
                animal.DateOfBirth = DateTime.Parse(editCardItemsAnimal.ElementAt(2).CardContent);
            }
            editCardItemsAnimal.Clear();
            var dictionary2 = new CardMenu(animal);
            CardMenu.AnimalCard(animal);
        }
    }
}
