using SimplyKnowHau_LogicAndData;

namespace SimplyKnowHau_Console
{
    internal class Dictionaries
    {
<<<<<<< HEAD
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
=======
        public static List<MenuItem> stMenuOptions = new();
>>>>>>> feature_animalmenu



        public static List<MenuItem> AnimalMenuOptions = new();

        public Dictionaries(int id)
        {
            switch (id)
            {
                case 1:
                    {
                        stMenuOptions.Add(new MenuItem(1, "Your Animals"));
                        stMenuOptions.Add(new MenuItem(2, "Make an apointment"));
                        stMenuOptions.Add(new MenuItem(3, "History of apointments"));
                        stMenuOptions.Add(new MenuItem(4, "?"));
                        stMenuOptions.Add(new MenuItem(5, "?"));
                        stMenuOptions.Add(new MenuItem(6, "?"));
                        stMenuOptions.Add(new MenuItem(7, "?"));
                        stMenuOptions.Add(new MenuItem(8, "?"));
                        stMenuOptions.Add(new MenuItem(9, "Quit"));
                        break;
                    }
                case 2:
                    {
                        AnimalMenuOptions = AnimalLogic.UserIdToMenu();
                        break;
                    }
                 
            }
        }
    }
}
