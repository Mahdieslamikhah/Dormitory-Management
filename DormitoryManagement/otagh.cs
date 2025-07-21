using System;
namespace DormitoryManagement
{
    public class Otagh
    {
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public int Capacity { get; } = 6;
        public List<Tajhizat> ListTajhizat = new List<Tajhizat>();
        public List<Daneshjoo> DaneshjoosMarbote { get; set; } = new List<Daneshjoo>();
        public Blook BlookMarbote { get; set; }

        public Otagh(int roomNumber, int floor, Blook blook)
        {
            RoomNumber = roomNumber;
            Floor = floor;
            BlookMarbote = blook;
        }
        public Otagh() { }
    }
}