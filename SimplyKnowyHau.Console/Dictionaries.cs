using SimplyKnowHau_LogicAndData;

namespace SimplyKnowHau_Console
{
    internal class Dictionaries
    {

        public static List<MenuItem> stMenuOptions = new();

        public static List<MenuItem> AnimalMenuOptions = new();

        public static List<MenuItem> ChooseAnimalMenuOptions = new();

        public static List<MenuItem> AppointmentMenuOptions = new();

        public static List<MenuItem> shortMenu = new();

        public Dictionaries(int id)
        {
            switch (id)
            {
                case 1:
                    {
                        stMenuOptions.Clear();
                        stMenuOptions.Add(new MenuItem(1, "Your Animals"));
                        stMenuOptions.Add(new MenuItem(2, "Make an apointment"));
                        stMenuOptions.Add(new MenuItem(3, "History of apointments"));
                        stMenuOptions.Add(new MenuItem(4, "?"));
                        stMenuOptions.Add(new MenuItem(5, "?"));
                        stMenuOptions.Add(new MenuItem(6, "?"));
                        stMenuOptions.Add(new MenuItem(7, "?"));
                        stMenuOptions.Add(new MenuItem(8, "Logout"));
                        stMenuOptions.Add(new MenuItem(9, "Quit"));
                        break;
                    }
                case 2:
                    {
                        AnimalMenuOptions.Clear();
                        AnimalMenuOptions = AnimalLogic.UserIdToMenu();
                        break;
                    }
                case 3:
                    {
                        shortMenu.Clear();
                        shortMenu.Add(new MenuItem(1, "Make an appointment for that animal"));
                        shortMenu.Add(new MenuItem(2, "Edit animal"));
                        shortMenu.Add(new MenuItem(3, "Back"));
                        break;

                    }
                case 4:
                    {
                        AppointmentMenuOptions.Clear();
                        AppointmentMenuOptions = AppointmentLogic.UserIdToMenu();
                        break;
                    }
                case 5:
                    {
                        ChooseAnimalMenuOptions.Clear();
                        ChooseAnimalMenuOptions = AnimalLogic.ChooseAnimalUserIdToMenu();
                        break;
                    }

            }
        }
    }
}
