using System;
namespace DormitoryManagement
{
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Naghsh { get; set; }
        public User(string username, string password, string naghsh)
    {
        Username = username;
        Password = password;
        Naghsh = naghsh;
    }
    }
}