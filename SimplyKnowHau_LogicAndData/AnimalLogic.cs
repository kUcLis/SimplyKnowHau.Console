using SimplyKnowHau_LogicAndData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimplyKnowHau_LogicAndData
{
    public class AnimalLogic
    {
        private static int _idCounter = DataMenager.Animals.Max(c => c.Id);

        private static readonly List<Animal>? _cars = DataMenager.Animals;
        public static Animal AddAnimal(string name, Species animalCategory, DateTime dateOfBirth)
        {
            int id = GetNextId();
            int userId = UserLogic.GetCurrentUser().Id;
            var animal = new Animal(id,userId,name,animalCategory, dateOfBirth);
            DataMenager.Animals.Add(animal);
            return animal;
        }

        public static Animal GetById(int id)
        {
            return _cars.FirstOrDefault(c => c.Id == id);
        }

        private static int GetNextId()
        {
            return ++_idCounter;
        }


    }
}
