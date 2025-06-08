using System;
namespace DormitoryManagement
{
    class Blook
    {
        public string BlockName { get; set; }
        public string DormitoryName { get; set; } // خوابگاه مربوطه
        public Masoulblook BlockManager { get; set; } // مسیول خوابگاه 
        public int NumberOfFloors { get; set; } // تعداد طبقه 
        public int NumberOfRooms { get; set; }
        public List<Otagh> Rooms { get; set; }

        public Blook(string blockName, string dormitoryName, Masoulblook blockManager, int numberOfFloors, int numberOfRooms)
        {
            BlockName = blockName;
            DormitoryName = dormitoryName;
            BlockManager = blockManager;
            NumberOfFloors = numberOfFloors;
            NumberOfRooms = numberOfRooms;
            Rooms = new List<Otagh>();
        }


    }
}