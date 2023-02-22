using SimplyKnowHau_LogicAndData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyKnowHau_LogicAndData
{
    public class UserLogic
    {
        private static int _idCounter = DataMenager.Users.Max(c => c.Id);

        private static readonly List<User>? _users = DataMenager.Users;

        public static User? currentUser = null;
        public static User AddUser(string name)
        {
            int id = GetNextId();
            var user = new User(id, name);
            DataMenager.Users.Add(user);
            return user;
        }

        public static User GetById(int id)
        {
            return _users.FirstOrDefault(c => c.Id == id);
        }

        public static User GetByName(string name)
        {
            return _users.FirstOrDefault(c => c.Name == name);
        }

        public static User SetCurrentUser(User user)
        {
            UserLogic.currentUser = user;
            return UserLogic.currentUser;
        }

        public static User GetCurrentUser()
        {
            return currentUser;
        }

        private static int GetNextId()
        {
            return ++_idCounter;
        }

    }
}
