using System;
using System.Collections.Generic;

namespace DormitoryManagement
{
     class UserManager
    {
        private List<User> users = new List<User>();

        public User Login(string username, string password)
        {
            foreach (var user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return user;
                }
            }
            return null; 
        }

        public void Register(string username, string password, string naghsh) 
        {
            
            if (users.Exists(u => u.Username == username))
            {
                throw new Exception("ghablan sabte nam kardid");
            }

            User newUser = new User(username, password, naghsh);
            users.Add(newUser);
            Console.WriteLine(" >> Ba movafaghiyat sabt nam kardid..");
        }

        
        public bool UserExists(string username)
        {
            return users.Exists(u => u.Username == username);
        }
    }
}