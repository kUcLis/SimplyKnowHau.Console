using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyKnowHau_Console
{
    internal class Dictionaries
    {
        internal static readonly Dictionary<ConsoleKey, string> stMenuOptions = new()
        {
            {ConsoleKey.D1, "Your Animals"},
            {ConsoleKey.D2, "Make an apointment"},
            {ConsoleKey.D3, "History of apointments"},
            {ConsoleKey.D4, "?"},
            {ConsoleKey.D5, "?"},
            {ConsoleKey.D6, "?"},
            {ConsoleKey.D7, "Logout"},
            {ConsoleKey.Escape, "Quit"},
        };

        internal static readonly Dictionary<ConsoleKey, string> AnimalMenuOptions = new()
        {
            {ConsoleKey.D1, "Add new animal"},
            {ConsoleKey.D2, "?"},
            {ConsoleKey.D3, "?"},
            {ConsoleKey.D4, "?"},
            {ConsoleKey.D5, "?"},
            {ConsoleKey.D6, "?"},
            {ConsoleKey.D7, "?"},
            {ConsoleKey.Escape, "Back"},
        };

    }
}
