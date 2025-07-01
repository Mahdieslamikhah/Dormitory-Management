using System;
using System.Collections.Generic;
using System.Linq;

namespace DormitoryManagement
{
    class ClassModiriyatBlook
    {
        private List<Blook> blocks = new List<Blook>();
        private List<Masoulblook> masoulinBlock = new List<Masoulblook>();

        // Add Masoul Block (for testing)
        public void AddMasoulBlock(Masoulblook masoul)
        {
            masoulinBlock.Add(masoul);
        }

        public void AddBlook()
        {
            Console.WriteLine("\n Afzoodan Blook Jadid:");

            Console.Write("Name Blook: ");
            string blockName = Console.ReadLine();

            Console.Write("Name Khabgah: ");
            string dormitoryName = Console.ReadLine();

            Console.Write("Shomare Daneshjooei Masoul Blook: ");
            int daneshjoCode = int.Parse(Console.ReadLine());

            var masoul = masoulinBlock.FirstOrDefault(m => m.Daneshjonumber == daneshjoCode);
            if (masoul == null)
            {
                Console.WriteLine(" Masouli ba in shomare yaft nashod.");
                return;
            }

            Console.Write("Tedad Tabaghat: ");
            int numberOfFloors = int.Parse(Console.ReadLine());

            Console.Write("Tedad Otagh-ha: ");
            int numberOfRooms = int.Parse(Console.ReadLine());

            Blook newBlook = new Blook(blockName, dormitoryName, masoul, numberOfFloors, numberOfRooms);
            blocks.Add(newBlook);

            Console.WriteLine(" Blook jadid ba movafaghiat ezafe shod.");
        }

        public void ShowAllBlooks()
        {
            Console.WriteLine("\n Liste Blook-ha:");
            if (blocks.Count == 0)
            {
                Console.WriteLine("Hich Blooki sabt nashode ast.");
                return;
            }

            foreach (var b in blocks)
            {
                Console.WriteLine($"- {b.BlockName} | Khabgah: {b.DormitoryName} | Tabaghat: {b.NumberOfFloors} | Otagh-ha: {b.NumberOfRooms} | Masoul: {b.BlockManager.Name} {b.BlockManager.Lastname}");
            }
        }

        public void DeleteBlook()
        {
            Console.Write("Name Blook baraye hazf: ");
            string name = Console.ReadLine();

            var blook = blocks.FirstOrDefault(b => b.BlockName == name);
            if (blook != null)
            {
                blocks.Remove(blook);
                Console.WriteLine(" Blook hazf shod.");
            }
            else
            {
                Console.WriteLine(" Blooki ba in name yaft nashod.");
            }
        }

        public void EditBlook()
        {
            Console.Write("Name Blook baraye virayesh: ");
            string name = Console.ReadLine();

            var blook = blocks.FirstOrDefault(b => b.BlockName == name);
            if (blook == null)
            {
                Console.WriteLine(" Blook peyda nashod.");
                return;
            }

            Console.Write("Name jadid Blook: ");
            blook.BlockName = Console.ReadLine();

            Console.Write("Name jadid Khabgah: ");
            blook.DormitoryName = Console.ReadLine();

            Console.Write("Shomare Daneshjooei Masoul jadid: ");
            int daneshjoCode = int.Parse(Console.ReadLine());
            var newManager = masoulinBlock.FirstOrDefault(m => m.Daneshjonumber == daneshjoCode);
            if (newManager != null)
            {
                blook.BlockManager = newManager;
            }
            else
            {
                Console.WriteLine("❗ Masoul jadid yaft nashod. Taghir anjam nashod.");
            }

            Console.Write("Tedad jadid Tabaghat: ");
            blook.NumberOfFloors = int.Parse(Console.ReadLine());

            Console.Write("Tedad jadid Otagh-ha: ");
            blook.NumberOfRooms = int.Parse(Console.ReadLine());

            Console.WriteLine(" Virayesh anjam shod.");
        }
    }
}
