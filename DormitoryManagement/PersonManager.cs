using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DormitoryManagement
{
    class PersonManager
    {
        public List<Masoulkhabgah> masoulinKhabgah = new List<Masoulkhabgah>();
        private List<Masoulblook> masoulinBlook = new List<Masoulblook>();
        private List<Daneshjoo> daneshjooList = new List<Daneshjoo>();

        // Modiriyat Masoulin Khabgah
        public void AddKhabgahManager()
        {
            Console.WriteLine("\nAfzoodan Masoul Khabgah:");
            Console.Write("Nam: ");
            string name = Console.ReadLine();
            Console.Write("Nam Khanvadegi: ");
            string lastName = Console.ReadLine();
            Console.Write("Code Melli: ");
            int nationalCode = int.Parse(Console.ReadLine());
            Console.Write("Telefon: ");
            int phone = int.Parse(Console.ReadLine());
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Semat: ");
            string position = Console.ReadLine();
            Console.Write("Name Khabgah: ");
            string dormName = Console.ReadLine();

            masoulinKhabgah.Add(new Masoulkhabgah(name, lastName, nationalCode, phone, address, position, dormName));
            Console.WriteLine("Masoul Khabgah ezafe shod.");
        }

        public void DeleteKhabgahManager()
        {
            Console.Write("Nam baraye hazf: ");
            string name = Console.ReadLine();
            Masoulkhabgah nam_masoul = null;

            foreach (var m in masoulinKhabgah)
            {
                if (m.Name == name)
                {
                    nam_masoul = m;
                    break;
                }
            }

            if (nam_masoul != null)
            {
                masoulinKhabgah.Remove(nam_masoul);
                Console.WriteLine("Hazf anjam shod.");
            }
            else
            {
                Console.WriteLine("Yaft nashod.");
            }
        }

        public void EditKhabgahManager()
        {
            Console.Write("Nam baraye virayesh: ");
            string name = Console.ReadLine();
            Masoulkhabgah nam_masoul = null;

            foreach (var m in masoulinKhabgah)
            {
                if (m.Name == name)
                {
                    nam_masoul = m;
                    break;
                }
            }

            if (nam_masoul == null)
            {
                Console.WriteLine("Peyda nashod.");
                return;
            }

            Console.Write("Nam jadid: ");
            nam_masoul.Name = Console.ReadLine();
            Console.Write("Nam Khanvadegi jadid: ");
            nam_masoul.Lastname = Console.ReadLine();
            Console.Write("Code Melli jadid: ");
            nam_masoul.Nationalnumber = int.Parse(Console.ReadLine());
            Console.Write("Telefon jadid: ");
            nam_masoul.Phonenumber = int.Parse(Console.ReadLine());
            Console.Write("Address jadid: ");
            nam_masoul.Adress = Console.ReadLine();
            Console.Write("Semat jadid: ");
            nam_masoul.Semat = Console.ReadLine();
            Console.Write("Name Khabgah jadid: ");
            nam_masoul.Namekhabgah = Console.ReadLine();

            Console.WriteLine("Virayesh anjam shod.");
        }

        public void ShowKhabgahManagers()
        {
            Console.WriteLine("\nListe Masoulin Khabgah:");
            foreach (var m in masoulinKhabgah)
            {
                Console.WriteLine($"- {m.Name} {m.Lastname} | {m.Semat} | Khabgah: {m.Namekhabgah}");
            }
        }

        // Modiriyat Masoulin Blook
        public void AddBlookManager()
        {
            Console.WriteLine("\nAfzoodan Masoul Blook:");
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
            Console.Write("Name Blook: ");
            string nameBlook = Console.ReadLine();

            Otagh otagh = new Otagh();
            Blook blook = new Blook();
            Khabgah khabgah = new Khabgah();
            List<Tajhizat> tajhizat = new List<Tajhizat>();

            masoulinBlook.Add(new Masoulblook(semat, nameBlook, studentId, otagh, blook, khabgah, tajhizat, name, lastname, national, phone, address));
            Console.WriteLine("Masoul Blook ezafe shod.");
        }

        public void DeleteBlookManager()
        {
            Console.Write("Nam baraye hazf: ");
            string name = Console.ReadLine();
            Masoulblook nam_masoul = null;

            foreach (var m in masoulinBlook)
            {
                if (m.Name == name)
                {
                    nam_masoul = m;
                    break;
                }
            }

            if (nam_masoul != null)
            {
                masoulinBlook.Remove(nam_masoul);
                Console.WriteLine("Hazf shod.");
            }
            else
            {
                Console.WriteLine("Yaft nashod.");
            }
        }

        public void EditBlookManager()
        {
            Console.Write("Nam Masoul Blook baraye virayesh: ");
            string name = Console.ReadLine();
            Masoulblook nam_masoul = null;

            foreach (var m in masoulinBlook)
            {
                if (m.Name == name)
                {
                    nam_masoul = m;
                    break;
                }
            }

            if (nam_masoul == null)
            {
                Console.WriteLine("Yaft nashod.");
                return;
            }

            Console.Write("Nam jadid: ");
            nam_masoul.Name = Console.ReadLine();
            Console.Write("Nam Khanvadegi jadid: ");
            nam_masoul.Lastname = Console.ReadLine();
            Console.Write("Shomare Daneshjooei jadid: ");
            nam_masoul.Daneshjonumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Virayesh anjam shod.");
        }

        public void ShowBlookManagers()
        {
            Console.WriteLine("\nListe Masoulin Blook:");
            foreach (var m in masoulinBlook)
            {
                Console.WriteLine($"- {m.Name} {m.Lastname} | Code: {m.Daneshjonumber} | Semat: {m.Semat} | Blook: {m.Nameblook}");
            }
        }

        // Modiriyat Daneshjoo
        public void AddStudent()
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

            daneshjooList.Add(new Daneshjoo(studentId, otagh, blook, khabgah, tajhizat, name, lastname, national, phone, address));
            Console.WriteLine("Daneshjoo ezafe shod.");
        }

        public void ShowAllStudents()
        {
            Console.WriteLine("\nListe Daneshjooha:");
            foreach (var d in daneshjooList)
            {
                Console.WriteLine($"- {d.Name} {d.Lastname} | Shomare Daneshjooei: {d.Daneshjonumber}");
            }
        }
    }
}
