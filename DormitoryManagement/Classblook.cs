using System;
namespace DormitoryManagement
{
    public class Blook
    {
        public string BlockName { get; set; }
        public string DormitoryName { get; set; } 
        public Masoulblook BlockManager { get; set; }
        public int NumberOfFloors { get; set; }
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
        public Blook() { }

    }
}