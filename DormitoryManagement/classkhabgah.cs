using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DormitoryManagement
{
    class Classkhabgah
    {
        public string Namekhabgah { get; set; }
        public string Adress { get; set; }
        public int Zarfiyatkol { get; set; }
        public Classmasoulkhabgah Masoulkhabgah { get; set; }
        public List<Classblook> Blookha { get; set; }
        public Classkhabgah(string namekhabgah, string adress, int zarfiyatkol, Classmasoulkhabgah masoulkhabgah, List<Classblook> blookha)
        {
            Namekhabgah = namekhabgah;
            Adress = adress;
            Zarfiyatkol = zarfiyatkol;
            Masoulkhabgah = masoulkhabgah;
            Blookha = blookha;
        }
    }
}
