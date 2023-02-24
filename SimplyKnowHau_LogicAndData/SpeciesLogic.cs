using SimplyKnowHau_LogicAndData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SimplyKnowHau_LogicAndData
{
    public class SpeciesLogic
    {
        private static int _idCounter = DataMenager.Species.Max(c => c.Id);

        private static List<Species>? _species = DataMenager.Species;

        public static Species AddSpecie(string name)
        {
            int id = GetNextId();
            var specie = new Species(id, name);
            DataMenager.Species.Add(specie);
            return specie;
        }

        public static Species GetById(int id)
        {

            return _species.FirstOrDefault(c => c.Id == id);

        }

        public static Species GetByName(string specie)
        {

            return _species.FirstOrDefault(c => c.Specie == specie);

        }

        public static string? SpeciesToString()
        {
            string? speciesString = string.Empty;
            for(int i = 0; i <= _species.Count-1;i++)
            {
                if (i == 0)
                {
                    speciesString +=" " + _species.ElementAt(i).Specie;
                }
                else if (i == _species.Count - 1)
                {
                    speciesString += "," + _species.ElementAt(i).Specie;
                }
                else
                {
                    speciesString += "," + _species.ElementAt(i).Specie + " ";
                }
            }
            return speciesString;
        }
        private static int GetNextId()
        {
            return ++_idCounter;
        }
    }
}
