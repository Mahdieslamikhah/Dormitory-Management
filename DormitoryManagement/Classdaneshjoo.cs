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
        public ClassOtagh Otagh { get; set; }
        public Classblook Blook { get; set; }
        public Classkhabgah Khabgah { get; set; }

        public List<Classtajhizat> Tajhizat { get; set; }


        public Classdaneshjoo(int daneshjonumber, Classotagh otagh, Classblook blook, Classkhabgah khabgah, List<Classtajhizat> tajhizat
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
