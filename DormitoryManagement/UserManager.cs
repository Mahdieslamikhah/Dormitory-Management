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
            return null; // یوزر نبود 
        }

        public void Register(string username, string password, string naghsh) // تغییر نام به Register
        {
            // بررسی اینکه آیا کاربر قبلاً ثبت‌نام کرده است
            if (users.Exists(u => u.Username == username))
            {
                throw new Exception("این نام کاربری قبلاً ثبت‌نام شده است.");
            }

            User newUser = new User(username, password, naghsh);
            users.Add(newUser);
            Console.WriteLine("با موفقیت ثبت نام کردید! حالا وارد شوید ...");
        }

        // بررسی وجود نام کاربری
        public bool UserExists(string username)
        {
            return users.Exists(u => u.Username == username);
        }
    }
}