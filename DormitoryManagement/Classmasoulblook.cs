using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagement
{
    class Masoulblook : Person
    {
        public static string Semat { get; set; }
        public static string Nameblook { get; set; }
        
        public Masoulblook(string name, string lastname, int nationalnumber, int phonenumber, string adress
            , string semat, string nameblook) : base(name, lastname, nationalnumber, phonenumber, adress)
        {
            Semat = semat;
            Nameblook = nameblook;
        }
    }

}
