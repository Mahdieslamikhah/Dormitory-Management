using System;
namespace DormitoryManagement
{
    class Classblook
    {
        public string BlockName { get; set; }
        public string DormitoryName { get; set; } // خوابگاه مربوطه
        public string BlockManager { get; set; } // مسیول خوابگاه 
        public int NumberOfFloors { get; set; } // تعداد طبقه 
        public int NumberOfRooms { get; set; }
        public List<Classotagh> Rooms { get; set; }

        public Classblook(string blockName, string dormitoryName, string blockManager, int numberOfFloors, int numberOfRooms)
        {
            BlockName = blockName;
            DormitoryName = dormitoryName;
            BlockManager = blockManager;
            NumberOfFloors = numberOfFloors;
            NumberOfRooms = numberOfRooms;
            Rooms = new List<Classotagh>();
        }


    }
}