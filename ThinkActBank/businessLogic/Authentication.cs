using System.Collections.Generic;
using System.Linq;
using ThinkActBank.model;

namespace ThinkActBank.businessLogic
{
    public class Authentication
    {
        public static List<User> Users { get; set;} = new List<User>();
        public static User CurrentUser { get; set; }
        


        //register user
        public static void RegisterUser(User userData)
        {
            Users.Add(userData);
        }  

        public static User UserLogin(string username, string password)
        {
            var user = Users.FirstOrDefault(x => x.Username == username && x.Password == password);
            CurrentUser = user;
            return user;
        }
    }
}
