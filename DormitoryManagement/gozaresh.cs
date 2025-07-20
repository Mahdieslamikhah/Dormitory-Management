
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

        #region 1. گزارش وضعیت اسکان

        public void ShowOverallAccommodationStats()
        {
            Console.WriteLine("\n--- آمار کلی اسکان دانشجویان ---");
            var allStudents = _ashkhasManager.GetAllStudents();
            int totalStudents = allStudents.Count;
            int housedStudents = allStudents.Count(s => s.Otagh != null);
            
            Console.WriteLine($"تعداد کل دانشجویان ثبت شده: {totalStudents}");
            Console.WriteLine($"تعداد دانشجویان اسکان داده شده: {housedStudents}");
            Console.WriteLine($"تعداد دانشجویان بدون خوابگاه: {totalStudents - housedStudents}");
            Console.WriteLine("---------------------------------");
        }

        public void ShowRoomOccupancyList()
        {
            Console.WriteLine("\n--- لیست وضعیت اتاق‌ها ---");
            var dorms = _khabgahManager.GetDormitoryList();
            if (!dorms.Any())
            {
                Console.WriteLine("هیچ خوابگاهی ثبت نشده است.");
                return;
            }

            foreach (var dorm in dorms)
            {
                Console.WriteLine($"\n# خوابگاه: {dorm.Namekhabgah}");
                if (dorm.Blookha == null || !dorm.Blookha.Any())
                {
                    Console.WriteLine("  این خوابگاه هیچ بلوکی ندارد.");
                    continue;
                }

                foreach (var block in dorm.Blookha)
                {
                    Console.WriteLine($"  ## بلوک: {block.BlockName}"); // تصحیح شده بر اساس فایل blook.cs
                    if (block.Rooms == null || !block.Rooms.Any()) // تصحیح شده بر اساس فایل blook.cs
                    {
                        Console.WriteLine("    این بلوک هیچ اتاقی ندارد.");
                        continue;
                    }
                    
                    foreach (var room in block.Rooms) // تصحیح شده
                    {
                        string status = room.DaneshjoosMarbote.Count == 0 ? "خالی" : $"{room.DaneshjoosMarbote.Count} نفر از {room.Capacity} نفر";
                        Console.WriteLine($"    - اتاق شماره {room.RoomNumber} | وضعیت: {status}");
                    }
                }
            }
            Console.WriteLine("--------------------------");
        }

        public void ShowDormAndBlockCapacity()
        {
            Console.WriteLine("\n--- ظرفیت باقیمانده خوابگاه‌ها و بلوک‌ها ---");
            var dorms = _khabgahManager.GetDormitoryList();
            if (!dorms.Any())
            {
                Console.WriteLine("هیچ خوابگاهی ثبت نشده است.");
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
                        Console.WriteLine($"  - بلوک '{block.BlockName}' در خوابگاه '{dorm.Namekhabgah}': {blockOccupied} نفر از {blockCapacity} | ظرفیت خالی: {blockCapacity - blockOccupied}");
                        
                        dormTotalCapacity += blockCapacity;
                        dormTotalOccupied += blockOccupied;
                    }
                }
                Console.WriteLine($"# خوابگاه '{dorm.Namekhabgah}' (مجموع): {dormTotalOccupied} نفر از {dormTotalCapacity} | ظرفیت خالی: {dormTotalCapacity - dormTotalOccupied}");
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------------------");
        }

        #endregion

        #region 2. گزارش اموال

        public void ShowFullAssetList()
        {
            Console.WriteLine("\n--- لیست کامل اموال ---");
            _amvalManager.ShowAllTajhizat();
            Console.WriteLine("-----------------------");
        }

        public void ShowAssetsByRoom()
        {
            Console.Write("لطفا شماره اتاق مورد نظر را وارد کنید: ");
            if (!int.TryParse(Console.ReadLine(), out int roomNumber))
            {
                Console.WriteLine("شماره اتاق نامعتبر است.");
                return;
            }

            Console.WriteLine($"\n--- گزارش اموال اتاق شماره {roomNumber} ---");
            _amvalManager.ShowAssetsByRoom(roomNumber);
        }

        public void ShowAssetsByStudent()
        {
            Console.WriteLine("\n--- گزارش اموال بر اساس شماره دانشجویی ---");
            _amvalManager.SearchByStudentNumber();
        }

        public void ShowDefectiveAssets()
        {
            Console.WriteLine("\n--- لیست اموال معیوب و در حال تعمیر ---");
            _amvalManager.ShowDefectiveAssets();
        }
        #endregion

        #region 3. گزارش‌های تخصصی

        public void ShowRepairRequestsReport()
        {
            Console.WriteLine("\n--- گزارش درخواست‌های تعمیرات (اموال معیوب) ---");
            ShowDefectiveAssets();
        }

        public void ShowStudentAccommodationHistory()
        {
            Console.WriteLine("\n--- وضعیت فعلی اسکان دانشجو ---");
            Console.WriteLine("توجه: مدل فعلی پروژه تاریخچه جابجایی را ذخیره نمی‌کند و فقط مکان فعلی نمایش داده می‌شود.");
            Console.Write("شماره دانشجویی را وارد کنید: ");
            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                Console.WriteLine("شماره دانشجویی نامعتبر است.");
                return;
            }

            var student = _ashkhasManager.FindDaneshjooByNumber(studentId);
            if (student == null)
            {
                Console.WriteLine("دانشجو یافت نشد.");
                return;
            }

            if (student.Otagh != null && student.Blook != null && student.Khabgah != null)
            {
                Console.WriteLine($"دانشجو: {student.Name} {student.Lastname}");
                Console.WriteLine($"خوابگاه: {student.Khabgah.Namekhabgah}");
                Console.WriteLine($"بلوک: {student.Blook.BlockName}");
                Console.WriteLine($"اتاق: {student.Otagh.RoomNumber}");
            }
            else
            {
                Console.WriteLine($"دانشجوی {student.Name} {student.Lastname} در حال حاضر در هیچ اتاقی ساکن نیست.");
            }
        }
        #endregion
    }
}
