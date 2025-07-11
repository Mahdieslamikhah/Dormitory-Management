﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagement
{
    public class Masoulblook : Daneshjoo
    {
        public string Semat { get; set; }
        public string Nameblook { get; set; }

        public Masoulblook(string semat, string nameblook, int daneshjonumber, Otagh otagh, Blook blook
        , Khabgah khabgah, List<Tajhizat> tajhizat
        , string name, string lastname, int nationalnumber, int phonenumber, string adress) : base(daneshjonumber, otagh, blook
            , khabgah, tajhizat, name
            , lastname, nationalnumber, phonenumber, adress)
        {
            Semat = semat;
            Nameblook = nameblook;
        }
        public Masoulblook() { }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}