using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagement
{
    class Person
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Nationalnumber { get; set; }
        public int Phonenumber { get; set; }
        public string Adress { get; set; }

        public Person(string name, string lastname, int nationalnumber, int phonenumber, string adress)
        {
            Name = name;
            Lastname = lastname;
            Nationalnumber = nationalnumber;
            Phonenumber = phonenumber;
            Adress = adress;
        }
        public Person() { }
    }
}
