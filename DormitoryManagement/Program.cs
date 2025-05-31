using System;
namespace DormitoryManagement
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Welcom To Dormitory Management..");
                Console.WriteLine();
                Console.WriteLine("1. Singup / Singin");
                int input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    Console.WriteLine("1. Modriyat Khabgah");
                    Console.WriteLine("2. Modriyat Block");
                    Console.WriteLine("1. Modriyat Ashkhas");
                    Console.WriteLine("1. Modriyat Danshjoyan");
                }
                return;

            }
        }
    }
}