using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplyKnowHau_LogicAndData;

namespace SimplyKnowHau_Console
{
    internal class CardMenu
    {
        public static List<CardItem>? cardItemsAnimal = new();

        public CardMenu(int id)
        {
            if (id == 1)
            {
                cardItemsAnimal.Add(new CardItem(1,"Name of the animal:"));
                cardItemsAnimal.Add(new CardItem(2,"Specie:"));
                cardItemsAnimal.Add(new CardItem(3,"Date of birth (YYYY-MM-DD):"));
            }


        }


        public static void AddCardAnimal(List<MenuItem> dictionary)
        {
            var cardlist = new CardMenu(1);

            Logo.DisplayLogo();

            for (int i = 1; i <= cardItemsAnimal.Count; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
                Console.Write($"{cardItemsAnimal.ElementAt(i - 1).CardString}");
                Console.ReadLine();
            }


            cardItemsAnimal.Clear();
            StartingMenu.Starts(dictionary);
        }
    }
}
