using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyKnowHau_Console
{
    internal class AnimalMenu
    {

        const ConsoleColor BG = ConsoleColor.Black;
        const ConsoleColor BG_ACTIVE = ConsoleColor.DarkYellow;
        const ConsoleColor FG = ConsoleColor.DarkYellow;
        const ConsoleColor FG_ACTIVE = ConsoleColor.White;

        private static readonly Dictionary<ConsoleKey, string> _stMenuOptions = new()
        {
            {ConsoleKey.D1, "Add new animal"},
            {ConsoleKey.D2, "Make an apointment"},
            {ConsoleKey.D3, "History of apointments"},
            {ConsoleKey.D4, "?"},
            {ConsoleKey.D5, "?"},
            {ConsoleKey.D6, "?"},
            {ConsoleKey.D7, "?"},
            {ConsoleKey.Escape, "Quit"},
        };
        private static int activePosition = 1;












    }
}
