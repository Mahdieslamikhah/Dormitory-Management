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
