using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DormitoryManagement
{
    public class Masoulkhabgah : Person
    {
        public string Semat { get; set; }
        public string Namekhabgah { get; set; }
        public Masoulkhabgah(string name, string lastname, int nationalnumber, int phonenumber, string adress,
            string semat, string namekhabgah) : base(name, lastname, nationalnumber, phonenumber, adress)
        {
            Semat = semat;
            Namekhabgah = namekhabgah;
        }
        public override string ToString()
        {
            return $"{Name}";
        }
        public Masoulkhabgah(string name, string lastname, int nationalnumber, int phonenumber, string adress) : base(name, lastname, nationalnumber, phonenumber, adress) { }
    }
}
