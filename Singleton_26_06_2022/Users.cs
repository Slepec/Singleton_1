using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_26_06_2022
{
    public class Users
    {
        private static List<User> usersList;
        private static Users instance;
        private Users() 
        {
            usersList = new List<User>(5);
            ClassSer.fromXML<List<User>>(ref usersList,"users.xml");
        }

        public static Users getInstance()
        {
            if (instance == null)
            {
                instance =  new Users();
               
            }
            return instance;
        }
        public User getAccountByName(string name)
        {
            foreach(User u in usersList)
            {
                if (u.Name == name) return u;
            }
            return null;
        }
        public void printAccounts()
        {
            foreach (User u in usersList)
            {
                Console.WriteLine(u.Name+"|"+u.Description);
            }
        }
        public bool leave(User user)
        {

            if (usersList.Count > 0)
            {
                usersList.Remove(user);
                ClassSer.toXML<List<User>>(ref usersList, "users.xml");
                return true;
            }
            return false;
        }
        public bool addAccount(User user)
        {
            if (usersList.Count < 5 && getAccountByName(user.Name)==null)
            {
                usersList.Add(user);
                ClassSer.toXML<List<User>>(ref usersList, "users.xml");
                return true;
            }
            return false;
        }
    }
}
