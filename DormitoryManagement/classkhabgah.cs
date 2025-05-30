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
        public string Masoulkhabgah { get; set; }
        public List<string> Blookha { get; set; }
        public Classkhabgah(string namekhabgah, string adress, int zarfiyatkol, string masoulkhabgah, List<string> blookha)
        {
            Namekhabgah = namekhabgah;
            Adress = adress;
            Zarfiyatkol = zarfiyatkol;
            Masoulkhabgah = masoulkhabgah;
            Blookha = blookha;
        }
    }
}
