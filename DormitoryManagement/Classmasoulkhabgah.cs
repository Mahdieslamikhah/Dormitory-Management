using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagement
{
    class Classmasoulkhabgah : Classperson
    {
        public string Semat { get; set; }
        public string Namekhabgah { get; set; }
        public Classmasoulkhabgah(string name, string lastname, int nationalnumber, int phonenumber, string adress,
            string semat,string namekhabgah) : base(name, lastname, nationalnumber, phonenumber, adress)
        {
            Semat = semat;
            Namekhabgah = namekhabgah;
        }
    }
}
