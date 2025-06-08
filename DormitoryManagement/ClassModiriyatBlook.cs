using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace DormitoryManagement
{
    class ClassModiriyatBlook
    {
        private List<Blook> blocks = new List<Blook>();
        public void AddBlook()
        {
            Console.Write("nam blook");
            string blockName = Console.ReadLine();

            Console.Write("nam khabgah");
            string dormName = Console.ReadLine();

            Console.WriteLine("\netelat masoul blook");
            Console.Write("nam");
            string name = Console.ReadLine();

            Console.Write("nam khanevadegi");
            string lastname = Console.ReadLine();

            Console.Write("code melli");
            int nationalnumber = int.Parse(Console.ReadLine());

            Console.Write("shomare tamas");
            int phonenumber = int.Parse(Console.ReadLine());

            Console.Write("adress");
            string adress = Console.ReadLine();

            Console.Write("semat ");
            string semat = Console.ReadLine();

            Console.Write("nam khabgah mortabet");
            string namekhabgah = Console.ReadLine();
            var blockManager = new Masoulblook(name, lastname, nationalnumber, phonenumber, adress, semat, namekhabgah);

            Console.Write("tedad tabaghat");
            int floors = int.Parse(Console.ReadLine());

            Console.Write("tedad otagh ");
            int numberOfRooms = int.Parse(Console.ReadLine());

            var newBlook = new Blook(blockName, dormName, blockManager, floors, numberOfRooms);

            // گرفتن اطلاعات اتاق‌ها
            for (int i = 0; i < numberOfRooms; i++)
            {
                Console.WriteLine($"etelat otagh {i + 1}:\n");

                Console.Write("shomare otagh\n");
                int roomNumber = int.Parse(Console.ReadLine());

                Console.Write(" tabaghe \n");
                int floor = int.Parse(Console.ReadLine());

                var otagh = new Otagh(roomNumber, floor, newBlook);
                newBlook.Rooms.Add(otagh);
            }

            blocks.Add(newBlook);
            Console.WriteLine(" blook ezafeh shod\n ");
        }
        public void DeleteBlook()
        {
            Console.Write("nam blook baraye hazf\n ");
            string blockName = Console.ReadLine();
       
            var blook = blocks.Find(b => b.BlockName == blockName);

            if (blook == null)
            {
                Console.WriteLine(" blook peyda nashod\n ");
                return;
            }

            blocks.Remove(blook);
            Console.WriteLine(" blook hazf shod\n");
        }
        public void EditBlook()
        {
            Console.Write("nam blook\n ");
            string blockName = Console.ReadLine();

            var blook = blocks.Find(b => b.BlockName == blockName);

            if (blook == null)
            {
                Console.WriteLine(" Blook peyda nashod\n");
                return;
            }
            Console.Write("nam jadid masoul blook\n");
            string name = Console.ReadLine();

            string lastname = Console.ReadLine();
            int nationalnumber = int.Parse(Console.ReadLine());
            int phonenumber = int.Parse(Console.ReadLine());
            string adress = Console.ReadLine();
            string semat = Console.ReadLine();
            string namekhabgah = Console.ReadLine();

            blook.BlockManager = new Masoulblook(
        name, lastname, nationalnumber, phonenumber, adress, semat, namekhabgah);

            Console.WriteLine(" اطلاعات بلوک با موفقیت ویرایش شد.");
        }
        public void ShowAllBlooks()
        {
            if (!blocks.Any())
            {
                Console.WriteLine(" هیچ بلوکی ثبت نشده است.");
                return;
            }

            foreach (var b in blocks)
            {
                Console.WriteLine($"\n {b.BlockName} | خوابگاه: {b.DormitoryName} | مسئول: {b.BlockManager} | طبقات: {b.NumberOfFloors} | تعداد اتاق: {b.NumberOfRooms}");

                foreach (var r in b.Rooms)
                {
                    Console.WriteLine($" اتاق {r.RoomNumber} | طبقه: {r.Floor} | ظرفیت: {r.Capacity}");
                }
            }
        }
    }
}
