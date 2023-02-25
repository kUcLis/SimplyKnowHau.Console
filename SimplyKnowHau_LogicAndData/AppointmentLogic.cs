using SimplyKnowHau_LogicAndData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyKnowHau_LogicAndData
{
    public class AppointmentLogic
    {

        private static int _idCounter = DataMenager.Appointments.Max(c => c.Id);

        private static List<Appointment>? _appointments = DataMenager.Appointments;

        public static Appointment AddAppointment(int userid, int animalid, DateTime date,string description,string recipe)
        {
            int id = GetNextId();
            var appointment = new Appointment(id, userid, animalid, date, description, recipe);
            DataMenager.Appointments.Add(appointment);
            return appointment;
        }

        public static Appointment GetById(int id)
        {

            return _appointments.FirstOrDefault(c => c.Id == id);

        }

        public static Appointment GetByAnimalId(int animalid)
        {

            return _appointments.FirstOrDefault(c => c.Id == animalid);

        }

        public static List<MenuItem> UserIdToMenu()
        {

            var appointmentList = _appointments.Where(c => c.UserId == UserLogic.GetCurrentUser().Id);
            var menu = new List<MenuItem>();

            for (int i = 1; i <= appointmentList.Count() + 3; i++)
            {
                if (i == 1)
                {
                    menu.Add(new MenuItem(i, "Make an appointment"));
                }
                else if (i == appointmentList.Count() + 3)
                {
                    menu.Add(new MenuItem(i, "Back"));
                }
                else if (i >= appointmentList.Count() + 2)
                {
                    menu.Add(new MenuItem(i, "No more appointments to show"));
                }
                else
                {
                    menu.Add(new MenuItem(appointmentList.ElementAt(i - 2).Id, $"{appointmentList.ElementAt(i - 2).Date.ToShortDateString()}: {AnimalLogic.GetById(appointmentList.ElementAt(i - 2).AnimalId).Name}"));
                }
            }

            return menu;
        }



        private static int GetNextId()
        {
            return ++_idCounter;
        }
    }
}
