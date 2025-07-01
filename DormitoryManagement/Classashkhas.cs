using System;
using System.Collections.Generic;
using System.Linq;

namespace DormitoryManagement
{
    class ClassBlockManagement
    {
        private List<Blook> blocks = new List<Blook>();

        public void AddBlock(List<Masoulblook> blockManagers)
        {
            Console.WriteLine("\n➕ Afzoodan Block:");

            Console.Write("Name Block: ");
            string blockName = Console.ReadLine();

            Console.Write("Name Dormitory: ");
            string dormName = Console.ReadLine();

            Console.Write("Tedad Tabaghat: ");
            int numberOfFloors = int.Parse(Console.ReadLine());

            Console.Write("Tedad Otagh-ha: ");
            int numberOfRooms = int.Parse(Console.ReadLine());

            Console.Write("Nam Masoul Block: ");
            string managerName = Console.ReadLine();

            // Peyda kardan Masoul
            Masoulblook blockManager = blockManagers.FirstOrDefault(m => m.Name == managerName);

            if (blockManager == null)
            {
                Console.WriteLine("❌ Masoul Block peyda nashod. Block sakhte nashod.");
                return;
            }

            // Block jadid ra misazim
            Blook newBlock = new Blook(blockName, dormName, blockManager, numberOfFloors, numberOfRooms);
            blocks.Add(newBlock);

            Console.WriteLine("✅ Block be soorat movafagh ezafe shod.");
        }

        public void ShowAllBlocks()
        {
            Console.WriteLine("\n📋 Liste Block-ha:");
            foreach (var b in blocks)
            {
                Console.WriteLine($"- Name: {b.BlockName} | Dormitory: {b.DormitoryName} | Masoul: {b.BlockManager?.Name} {b.BlockManager?.Lastname} | Tabaghat: {b.NumberOfFloors} | Otagh-ha: {b.NumberOfRooms}");
            }
        }

        public void DeleteBlock()
        {
            Console.Write("Name Block baraye hazf: ");
            string name = Console.ReadLine();

            var block = blocks.FirstOrDefault(b => b.BlockName == name);
            if (block != null)
            {
                blocks.Remove(block);
                Console.WriteLine("🗑️ Block ba movafaghiat hazf shod.");
            }
            else
            {
                Console.WriteLine("❌ Block peyda nashod.");
            }
        }

        public void EditBlock()
        {
            Console.Write("Name Block baraye virayesh: ");
            string name = Console.ReadLine();

            var block = blocks.FirstOrDefault(b => b.BlockName == name);
            if (block == null)
            {
                Console.WriteLine("❌ Block peyda nashod.");
                return;
            }

            Console.Write("Name jadid Block: ");
            block.BlockName = Console.ReadLine();

            Console.Write("Dormitory jadid: ");
            block.DormitoryName = Console.ReadLine();

            Console.Write("Tedad Tabaghat jadid: ");
            block.NumberOfFloors = int.Parse(Console.ReadLine());

            Console.Write("Tedad Otagh-ha jadid: ");
            block.NumberOfRooms = int.Parse(Console.ReadLine());

            Console.WriteLine("✅ Virayesh Block anjam shod.");
        }

        // Baraye daryaft liste blocks (agar lazem shod)
        public List<Blook> GetBlocks()
        {
            return blocks;
        }
    }
}
