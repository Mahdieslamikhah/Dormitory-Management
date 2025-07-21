using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagement
{
    public class ClassModiriyatAmval
    {
        private List<Tajhizat> tajhizatList;
        private ModiriyatAshkhas ashkhasManager;

        public ClassModiriyatAmval(ModiriyatAshkhas manager)
        {
            ashkhasManager = manager;
            tajhizatList = new List<Tajhizat>();
        }

        public void AddTajhizat()
        {
            Console.WriteLine("Noe Tajhizat:");
            string noetajhizat = Console.ReadLine();

            Console.WriteLine("Part Number (001-005):");
            int partNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Vaziat (Jadid, Kharab, Dar Estefade):");
            string status = Console.ReadLine();

            Console.WriteLine("Shomare Daneshjoo:");
            int daneshjoNumber = int.Parse(Console.ReadLine());

            
            var malek = FindDaneshjoo(daneshjoNumber);
            if (malek == null)
            {
                Console.WriteLine("Daneshjoo yaft nashod.");
                return;
            }

            var otagh = malek.Otagh;
            if (otagh == null)
            {
                Console.WriteLine("Daneshjoo otagh nadarad.");
                return;
            }

            Tajhizat t = new Tajhizat(noetajhizat, otagh, malek, partNumber, status);
            tajhizatList.Add(t);
            Console.WriteLine($"Tajhizat ba shomare amval {t.ShomareAmval} ba movafaghiat sabt shod.");
        }

        public void ShowAllTajhizat()
        {
            if (tajhizatList.Count == 0)
            {
                Console.WriteLine("Hich tajhizati sabt nashode ast.");
                return;
            }

            foreach (var t in tajhizatList)
            {
                Console.WriteLine($"Shomare Amval: {t.ShomareAmval}, Noe: {t.NoeTajhizat}, Vaziat: {t.Status}, Daneshjoo: {t.Malek.Name} {t.Malek.Lastname}, Otagh: {(t.OtaghMarbote != null ? t.OtaghMarbote.RoomNumber : "Nashenas")}");
            }
        }

        public void DeleteTajhizat()
        {
            Console.WriteLine("Shomare Amval ra vared konid:");
            string shomareAmval = Console.ReadLine();

            var item = tajhizatList.FirstOrDefault(t => t.ShomareAmval == shomareAmval);
            if (item == null)
            {
                Console.WriteLine("Tajhizat yaft nashod.");
                return;
            }

            tajhizatList.Remove(item);
            Console.WriteLine("Tajhizat hazf shod.");
        }

        public void SearchByStudentNumber()
        {
            Console.WriteLine("Shomare Daneshjooei ra vared konid:");
            int number = int.Parse(Console.ReadLine());

            var list = tajhizatList.Where(t => t.Malek.Daneshjonumber == number).ToList();

            if (list.Count == 0)
            {
                Console.WriteLine("Tajhizati baraye in daneshjoo yaft nashod.");
                return;
            }

            foreach (var t in list)
            {
                Console.WriteLine($"Shomare Amval: {t.ShomareAmval}, Noe: {t.NoeTajhizat}, Vaziat: {t.Status}");
            }
        }
        private Daneshjoo FindDaneshjoo(int daneshjoNumber)
        {
            return ashkhasManager.FindDaneshjooByNumber(daneshjoNumber);
        }
        
public void ShowAssetsByRoom(int roomNumber)
{
    
    var assetsInRoom = tajhizatList.Where(t => t.OtaghMarbote != null && t.OtaghMarbote.RoomNumber == roomNumber).ToList();
    if (!assetsInRoom.Any())
    {
        Console.WriteLine($"tajhizi baraye shomare otagh {roomNumber} yaft nashod.");
        return;
    }

    foreach (var t in assetsInRoom)
    {
        Console.WriteLine($"ShomareAmval: {t.ShomareAmval}, NoeTajhizat: {t.NoeTajhizat}, vaziat: {t.Status}");
    }
}

public void ShowDefectiveAssets()
{
   
    var defectiveAssets = tajhizatList.Where(t => t.Status.ToLower() == "kharab" || t.Status.ToLower() == "dar tamir").ToList();
    if (!defectiveAssets.Any())
    {
        Console.WriteLine("هیچ تجهیز معیوب یا در حال تعمیری یافت نشد.");
        return;
    }

    foreach (var t in defectiveAssets)
    {
        Console.WriteLine($"ShomareAmval: {t.ShomareAmval}, NoeTajhizat: {t.NoeTajhizat}, vaziat: {t.Status}, otagh: {t.OtaghMarbote?.RoomNumber}, Daneshjoo: {t.Malek?.Name}");
    }
}

    }
}
