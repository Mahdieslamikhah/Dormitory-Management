using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagement
{
    class Classdaneshjoo:Classperson
    {
        public int Daneshjonumber { get; set; }
        public int Otagh { get; set; }
        public int Blook { get; set; }
        public string Khabgah { get; set; }

        public List<string> Tajhizat { get; set; }


        public Classdaneshjoo(int daneshjonumber, int otagh, int blook, string khabgah, List<string> tajhizat
        , string name, string lastname, int nationalnumber, int phonenumber, string adress) : base(name, lastname, nationalnumber, phonenumber
            , adress)
        {
            Daneshjonumber = daneshjonumber;
            Otagh = otagh;
            Blook = blook;
            Khabgah = khabgah;
            Tajhizat = tajhizat;
        }
    }
}
