using System;
using System.Linq;
using System.Collections.Generic;

namespace DormitoryManagement
{
    public class ReportGenerator
    {
        private readonly ModiriyatAshkhas _ashkhasManager;
        private readonly ModriyatKhahbgah _khabgahManager;
        private readonly ClassModiriyatAmval _amvalManager;

        public ReportGenerator(ModiriyatAshkhas ashkhasManager, ModriyatKhahbgah khabgahManager, ClassModiriyatAmval amvalManager)
        {
            _ashkhasManager = ashkhasManager;
            _khabgahManager = khabgahManager;
            _amvalManager = amvalManager;
        }

        #region 1. gozaresh vaziat eskan

        public void ShowOverallAccommodationStats()
        {
            Console.WriteLine("\n--- Amareh kolli eskan daneshjooyan ---");
            var allStudents = _ashkhasManager.GetAllStudents();
            int totalStudents = allStudents.Count;
            int housedStudents = allStudents.Count(s => s.Otagh != null);
            
            Console.WriteLine($"tedade kol daneshjooyane sabt shode: {totalStudents}");
            Console.WriteLine($"tedade daneshjooyane eskan dade shode: {housedStudents}");
            Console.WriteLine($"tedade daneshjooyane bedune khabgah: {totalStudents - housedStudents}");
            Console.WriteLine("---------------------------------");
        }

        public void ShowRoomOccupancyList()
        {
            Console.WriteLine("\n--- List vaziat otagh ha ---");
            var dorms = _khabgahManager.GetDormitoryList();
            if (!dorms.Any())
            {
                Console.WriteLine("hich khabgahi sabt nashode ast.");
                return;
            }

            foreach (var dorm in dorms)
            {
                Console.WriteLine($"\n# Khabgah: {dorm.Namekhabgah}");
                if (dorm.Blookha == null || !dorm.Blookha.Any())
                {
                    Console.WriteLine("in khabgah hich blocki nadarad.");
                    continue;
                }

                foreach (var block in dorm.Blookha)
                {
                    Console.WriteLine($"  ## Block: {block.BlockName}");
                    if (block.Rooms == null || !block.Rooms.Any()) 
                    {
                        Console.WriteLine("in block hich otaghi nadarad.");
                        continue;
                    }
                    
                    foreach (var room in block.Rooms) 
                    {
                        string status = room.DaneshjoosMarbote.Count == 0 ? "khali" : $"{room.DaneshjoosMarbote.Count} nafar az {room.Capacity} nafar";
                        Console.WriteLine($"    - otaghe shomareh {room.RoomNumber} | Vaziat: {status}");
                    }
                }
            }
            Console.WriteLine("--------------------------");
        }

        public void ShowDormAndBlockCapacity()
        {
            Console.WriteLine("\n--- zarfiat baghimandeh khabgah ha va block ha ---");
            var dorms = _khabgahManager.GetDormitoryList();
            if (!dorms.Any())
            {
                Console.WriteLine("hich khabgahi sabt nashode ast.");
                return;
            }

            foreach (var dorm in dorms)
            {
                int dormTotalCapacity = 0;
                int dormTotalOccupied = 0;

                if (dorm.Blookha != null)
                {
                    foreach (var block in dorm.Blookha)
                    {
                        int blockCapacity = block.Rooms?.Sum(r => r.Capacity) ?? 0;
                        int blockOccupied = block.Rooms?.Sum(r => r.DaneshjoosMarbote.Count) ?? 0;
                        Console.WriteLine($"  - Block '{block.BlockName}' dar khabgah '{dorm.Namekhabgah}': {blockOccupied} nafar az {blockCapacity} | zarfiat khali: {blockCapacity - blockOccupied}");
                        
                        dormTotalCapacity += blockCapacity;
                        dormTotalOccupied += blockOccupied;
                    }
                }
                Console.WriteLine($"# Khabgah '{dorm.Namekhabgah}' (majmoo): {dormTotalOccupied} nafar az {dormTotalCapacity} | zarfiat khali: {dormTotalCapacity - dormTotalOccupied}");
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------------------");
        }

        #endregion

        #region 2. gozaresh amval

        public void ShowFullAssetList()
        {
            Console.WriteLine("\n--- liste kamel amval ---");
            _amvalManager.ShowAllTajhizat();
            Console.WriteLine("-----------------------");
        }

        public void ShowAssetsByRoom()
        {
            Console.Write("lotfan shomareh otaghe morede nazar ra vared konid: ");
            if (!int.TryParse(Console.ReadLine(), out int roomNumber))
            {
                Console.WriteLine("shomareh otagh namotabar ast.");
                return;
            }

            Console.WriteLine($"\n--- gozaresh amval otaghe shomareh {roomNumber} ---");
            _amvalManager.ShowAssetsByRoom(roomNumber);
        }

        public void ShowAssetsByStudent()
        {
            Console.WriteLine("\n--- gozaresh amval bar asase shomareh daneshjooyi ---");
            _amvalManager.SearchByStudentNumber();
        }

        public void ShowDefectiveAssets()
        {
            Console.WriteLine("\n--- list amval mayoob va dar hale tamir ---");
            _amvalManager.ShowDefectiveAssets();
        }
        #endregion

        #region 3. gozaresh haye takhasosi

        public void ShowRepairRequestsReport()
        {
            Console.WriteLine("\n--- gozaresh darkhasthaye tamirat (amval mayoob) ---");
            ShowDefectiveAssets();
        }

        public void ShowStudentAccommodationHistory()
        {
            Console.WriteLine("\n--- vaziat فعلی eskan daneshjoo ---");
            Console.WriteLine(" توجه: model فعلی project tarikhcheh jabejayee ra zakhireh nemikonad va faghat makan فعلی namayesh dadeh mishavad.");
            Console.Write("shomareh daneshjooyi ra vared konid: ");
            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                Console.WriteLine("shomareh daneshjooyi namotabar ast.");
                return;
            }

            var student = _ashkhasManager.FindDaneshjooByNumber(studentId);
            if (student == null)
            {
                Console.WriteLine("daneshjoo yaft nashod.");
                return;
            }

            if (student.Otagh != null && student.Blook != null && student.Khabgah != null)
            {
                Console.WriteLine($"Daneshjoo: {student.Name} {student.Lastname}");
                Console.WriteLine($"Khabgah: {student.Khabgah.Namekhabgah}");
                Console.WriteLine($"Block: {student.Blook.BlockName}");
                Console.WriteLine($"Otagh: {student.Otagh.RoomNumber}");
            }
            else
            {
                Console.WriteLine($"Daneshjooye {student.Name} {student.Lastname} dar hale hazer dar hich otaghi saken nist.");
            }
        }
        #endregion
    }
}
