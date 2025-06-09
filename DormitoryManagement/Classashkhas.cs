using System;
using System.Collections.Generic;
using System.Linq;

namespace DormitoryManagement
{
    class Classashkhas
    {
        public List<Masoulkhabgah> masoulinKhabgah = new List<Masoulkhabgah>();
        private List<Masoulblook> masoulinBlock = new List<Masoulblook>();
        private List<Daneshjoo> daneshjooha = new List<Daneshjoo>();

        // --- Modiriyat Masoul Khabgah ---
        public void AddMasoulKhabgah()
        {
            Console.WriteLine("\nAfzoodan Masoul Khabgah:");
            Console.Write("Nam: ");
            string name = Console.ReadLine();
            Console.Write("Nam Khanvadegi: ");
            string lastname = Console.ReadLine();
            Console.Write("Code Melli: ");
            int national = int.Parse(Console.ReadLine());
            Console.Write("Telefon: ");
            int phone = int.Parse(Console.ReadLine());
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Semat: ");
            string semat = Console.ReadLine();
            Console.Write("Name Khabgah: ");
            string khabgah = Console.ReadLine();

            masoulinKhabgah.Add(new Masoulkhabgah(name, lastname, national, phone, address, semat, khabgah));
            Console.WriteLine(" Masoul Khabgah ezafe shod.");
        }

        public void DeleteMasoulKhabgah()
        {
            Console.Write("Nam Masoul Khabgah baraye hazf: ");
            string name = Console.ReadLine();
            var masoul = masoulinKhabgah.FirstOrDefault(m => m.Name == name);
            if (masoul != null)
            {
                masoulinKhabgah.Remove(masoul);
                Console.WriteLine(" Hazf shod.");
            }
            else Console.WriteLine(" Peyda nashod.");
        }

        public void EditMasoulKhabgah()
        {
            Console.Write("Nam Masoul Khabgah baraye virayesh: ");
            string name = Console.ReadLine();
            var m = masoulinKhabgah.FirstOrDefault(x => x.Name == name);
            if (m == null) { Console.WriteLine(" Yaft nashod."); return; }

            Console.Write("Nam jadid: "); m.Name = Console.ReadLine();
            Console.Write("Nam Khanvadegi jadid: "); m.Lastname = Console.ReadLine();
            Console.Write("Code Melli jadid: "); m.Nationalnumber = int.Parse(Console.ReadLine());
            Console.Write("Telefon jadid: "); m.Phonenumber = int.Parse(Console.ReadLine());
            Console.Write("Address jadid: "); m.Adress = Console.ReadLine();
            Console.Write("Semat jadid: "); m.Semat = Console.ReadLine();
            Console.Write("Name Khabgah jadid: "); m.Namekhabgah = Console.ReadLine();

            Console.WriteLine("✅ Virayesh anjam shod.");
        }

        public void ShowMasoulinKhabgah()
        {
            Console.WriteLine("\nListe Masoulin Khabgah:");
            foreach (var m in masoulinKhabgah)
            {
                Console.WriteLine($"- {m.Name} {m.Lastname} | {m.Semat} | Khabgah: {m.Namekhabgah}");
            }
        }

        // --- Modiriyat Masoul Block ---
        public void AddMasoulBlock()
        {
            Console.WriteLine("\nAfzoodan Masoul Block:");

            Console.Write("Nam: ");
            string name = Console.ReadLine();
            Console.Write("Nam Khanvadegi: ");
            string lastname = Console.ReadLine();
            Console.Write("Code Melli: ");
            int national = int.Parse(Console.ReadLine());
            Console.Write("Telefon: ");
            int phone = int.Parse(Console.ReadLine());
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Shomare Daneshjooei: ");
            int studentId = int.Parse(Console.ReadLine());
            Console.Write("Semat: ");
            string semat = Console.ReadLine();
            Console.Write("Name Block: ");
            string nameblook = Console.ReadLine();

            Otagh otagh = new Otagh();
            Blook blook = new Blook();
            Khabgah khabgah = new Khabgah();
            List<Tajhizat> tajhizat = new List<Tajhizat>();

            masoulinBlock.Add(new Masoulblook(semat, nameblook, studentId, otagh, blook, khabgah, tajhizat, name, lastname, national, phone, address));
            Console.WriteLine(" Masoul Block ezafe shod.");
        }

        public void DeleteMasoulBlock()
        {
            Console.Write("Nam baraye hazf: ");
            string name = Console.ReadLine();
            var m = masoulinBlock.FirstOrDefault(x => x.Name == name);
            if (m != null)
            {
                masoulinBlock.Remove(m);
                Console.WriteLine(" Hazf shod.");
            }
            else Console.WriteLine(" Yaft nashod.");
        }

        public void EditMasoulBlock()
        {
            Console.Write("Nam Masoul Block baraye virayesh: ");
            string name = Console.ReadLine();
            var m = masoulinBlock.FirstOrDefault(x => x.Name == name);
            if (m == null) { Console.WriteLine(" Yaft nashod."); return; }

            Console.Write("Nam jadid: "); m.Name = Console.ReadLine();
            Console.Write("Nam Khanvadegi jadid: "); m.Lastname = Console.ReadLine();
            Console.Write("Shomare Daneshjooei jadid: "); m.Daneshjonumber = int.Parse(Console.ReadLine());

            Console.WriteLine(" Virayesh anjam shod.");
        }

        public void ShowMasoulinBlock()
        {
            Console.WriteLine("\nListe Masoulin Block:");
            foreach (var m in masoulinBlock)
            {
                Console.WriteLine($"- {m.Name} {m.Lastname} | Code: {m.Daneshjonumber} | Semat: {Masoulblook.Semat} | Block: {Masoulblook.Nameblook}");
            }
        }

        // --- Modiriyat Daneshjoo ---
        public void AddDaneshjoo()
        {
            Console.WriteLine("\nAfzoodan Daneshjoo:");
            Console.Write("Nam: ");
            string name = Console.ReadLine();
            Console.Write("Nam Khanvadegi: ");
            string lastname = Console.ReadLine();
            Console.Write("Code Melli: ");
            int national = int.Parse(Console.ReadLine());
            Console.Write("Shomare Daneshjooei: ");
            int studentId = int.Parse(Console.ReadLine());
            Console.Write("Telefon: ");
            int phone = int.Parse(Console.ReadLine());
            Console.Write("Address: ");
            string address = Console.ReadLine();

            Otagh otagh = new Otagh();
            Blook blook = new Blook();
            Khabgah khabgah = new Khabgah();
            List<Tajhizat> tajhizat = new List<Tajhizat>();

            daneshjooha.Add(new Daneshjoo(studentId, otagh, blook, khabgah, tajhizat, name, lastname, national, phone, address));
            Console.WriteLine(" Daneshjoo ezafe shod.");
        }

        public void ShowAllDaneshjoo()
        {
            Console.WriteLine("\nListe Daneshjooha:");
            foreach (var d in daneshjooha)
            {
                Console.WriteLine($"- {d.Name} {d.Lastname} | Shomare Daneshjooei: {d.Daneshjonumber}");
            }
        }
    }
}
