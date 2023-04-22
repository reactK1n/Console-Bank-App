using System;
using System.Collections.Generic;

namespace ThinkActBank.model
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public ICollection<Account> Accounts { get; set; }

        //empty ctor
        public User()
        {
            
        }
        //creating user
        public User(string username, string password, string fullName)
        {
            FullName = fullName;
            Username = username;
            Password = password;
            CreatedOn = DateTime.UtcNow;
        }

        //adding account
        public User(List<Account> accounts)
        {
            Accounts = accounts;
            UpdatedOn = DateTime.UtcNow;
        }

        public User(string fullName, string username, string password, List<Account> accounts)
        {
            FullName = fullName;
            Username = username;
            Password = password;
            UpdatedOn = DateTime.UtcNow;
            Accounts = accounts;
        }
    }
}
