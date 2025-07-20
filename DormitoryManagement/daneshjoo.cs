using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagement
{
    public class Daneshjoo: Person
    {
        public int Daneshjonumber { get; set; }
        public Otagh Otagh { get; set; }
        public Blook Blook { get; set; }
        public Khabgah Khabgah { get; set; }

        public List<Tajhizat> Tajhizat { get; set; }


        public Daneshjoo(int daneshjonumber, Otagh otagh, Blook blook, Khabgah khabgah, List<Tajhizat> tajhizat
        , string name, string lastname, int nationalnumber, int phonenumber, string adress) : base(name, lastname, nationalnumber, phonenumber
            , adress)
        {
            Daneshjonumber = daneshjonumber;
            Otagh = otagh;
            Blook = blook;
            Khabgah = khabgah;
            Tajhizat = tajhizat;
        }
        public Daneshjoo() { }
    }
}
