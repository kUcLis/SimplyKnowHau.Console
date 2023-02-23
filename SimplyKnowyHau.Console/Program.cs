using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SimplyKnowHau_LogicAndData;


namespace SimplyKnowHau_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var dictionary = new Dictionaries(1);
            StartingMenu.Starts(Dictionaries.stMenuOptions);


        }
    }
}