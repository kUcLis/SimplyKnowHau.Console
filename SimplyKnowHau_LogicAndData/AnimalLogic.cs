using SimplyKnowHau_LogicAndData.Model;

namespace SimplyKnowHau_LogicAndData
{
    public class AnimalLogic
    {
        private static int _idCounter = DataMenager.Animals.Max(c => c.Id);

        private static readonly List<Animal>? _animals = DataMenager.Animals;
        public static Animal AddAnimal(string name, Species animalCategory, DateTime dateOfBirth)
        {
            int id = GetNextId();
            int userId = UserLogic.GetCurrentUser().Id;
            var animal = new Animal(id, userId, name, animalCategory, dateOfBirth);
            DataMenager.Animals.Add(animal);
            return animal;
        }

        public static Animal GetById(int id)
        {
            return _animals.FirstOrDefault(c => c.Id == id);
        }

        public static List<MenuItem> UserIdToMenu()
        {

            var animalList = _animals.Where(c => c.UserId == UserLogic.GetCurrentUser().Id);
            var menu = new List<MenuItem>();

            for (int i = 1; i <= animalList.Count()+3; i++)
            {
                if (i == 1)
                {
                    menu.Add(new MenuItem(i, "Add your Animal"));
                }               
                else if( i == animalList.Count() + 3)
                {
                    menu.Add(new MenuItem(i, "Back"));
                }
                else if (i >= animalList.Count() + 2)
                {
                    menu.Add(new MenuItem(i, "No more animals to show"));
                }
                else
                {
                    menu.Add(new MenuItem(animalList.ElementAt(i-2).Id,$"{animalList.ElementAt(i-2).AnimalCategory.Specie}: {animalList.ElementAt(i-2).Name}, Age:{AnimalLogic.Age(animalList.ElementAt(i-2))}"));
                }
            }

            return menu;
        }

        public static List<MenuItem> ChooseAnimalUserIdToMenu()
        {

            var animalList = _animals.Where(c => c.UserId == UserLogic.GetCurrentUser().Id);
            var menu = new List<MenuItem>();

            for (int i = 1; i <= animalList.Count() + 2; i++)
            {
                if (i == animalList.Count() + 2)
                {
                    menu.Add(new MenuItem(i, "Back"));
                }
                else if (i >= animalList.Count() + 1)
                {
                    menu.Add(new MenuItem(i, "No more animals to show"));
                }
                else
                {
                    menu.Add(new MenuItem(animalList.ElementAt(i - 1).Id, $"{animalList.ElementAt(i - 1).AnimalCategory.Specie}: {animalList.ElementAt(i - 1).Name}, Age:{AnimalLogic.Age(animalList.ElementAt(i - 1))}"));
                }
            }

            return menu;
        }

        private static int GetNextId()
        {
            return ++_idCounter;
        }

        public static int Age(Animal animal)
        {
            int age = DateTime.Now.Year - animal.DateOfBirth.Year;
            if(DateTime.Now.Month < animal.DateOfBirth.Month)
            {
                age--;
            }

            return age;
        }
        //public static List<CardItem> AddAnimalCard()
        //{





        //}
    }
}
