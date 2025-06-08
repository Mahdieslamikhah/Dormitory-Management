using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DormitoryManagement
{
    class Khabgah
    {
        public string Namekhabgah { get; set; }
        public string Adress { get; set; }
        public int Zarfiyatkol { get; set; }
        public Masoulkhabgah Masoulkhabgah { get; set; }
        public List<Blook> Blookha { get; set; }
        public Khabgah(string namekhabgah, string adress, int zarfiyatkol, Masoulkhabgah masoulkhabgah, List<Blook> blookha)
        {
            Namekhabgah = namekhabgah;
            Adress = adress;
            Zarfiyatkol = zarfiyatkol;
            Masoulkhabgah = masoulkhabgah;
            Blookha = blookha;
        }
        public Khabgah() { }
    }
}
