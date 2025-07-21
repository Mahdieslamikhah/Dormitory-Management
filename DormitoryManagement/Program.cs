using System;
using System.Data;
using System.Security.AccessControl;
using DormitoryManagement; 

class Program
{
    static void Main()
    {
        ModriyatKhahbgah khahbgah = new ModriyatKhahbgah();
        UserManager userManager = new UserManager();
        User currentUser = null; 
        ClassModiriyatBlook sharedBlockManager = new ClassModiriyatBlook(khahbgah);
        ModiriyatAshkhas manager = new ModiriyatAshkhas(sharedBlockManager, khahbgah);
        ClassModiriyatAmval amvalManager = new ClassModiriyatAmval(manager);
        
        
        ReportGenerator reportGenerator = new ReportGenerator(manager, khahbgah, amvalManager);

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Welcome To Dormitory Management..");
            Console.WriteLine();
            Console.WriteLine("1. Signup / Signin");
            Console.WriteLine("2. Exit");
            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
            
                if (currentUser != null)
                {
                    Console.WriteLine($"Welcome {currentUser.Username}");
                }
                else
                {
                    Console.Write("User Name : ");
                    string username = Console.ReadLine();
                    if (userManager.UserExists(username))
                    {
                        Console.Write("Password : ");
                        string password = Console.ReadLine();
                        currentUser = userManager.Login(username, password); 
                        if (currentUser != null)
                        {
                            Console.WriteLine($"Welcome {currentUser.Username}");
                        }
                        else
                        {
                            Console.WriteLine("name karbari ya pass eshtebahe...");
                            continue; 
                        }
                    }
                    else
                    {
                        Console.WriteLine("User vojod nadard jahate sabte nam 1 ra vared konid : ");
                        string answer = Console.ReadLine();

                        if (answer == "1") 
                        {
                            Console.Write("Password : ");
                            string password = Console.ReadLine();

                            
                            Console.WriteLine(">> Naghshe Shoma : ");
                            Console.WriteLine("1.Masol Khabgah");
                            Console.WriteLine("2.Masol Blook");
                            Console.WriteLine("3.Daneshjoo");
                            string naghshChoice = Console.ReadLine();
                            string role = "";

                            
                            switch (naghshChoice)
                            {
                                case "1":
                                    role = "Masol Khabgah";
                                    break;
                                case "2":
                                    role = "Masol Blook";
                                    break;
                                case "3":
                                    role = "Daneshjoo";
                                    break;
                                default:
                                    Console.WriteLine("نقش نامعتبر است. به عنوان دانشجو ثبت‌نام می‌کنید.");
                                    role = "دانشجو"; 
                                    break;
                            }

                            try
                            {
                                userManager.Register(username, password, role);
                                
                                currentUser = new User(username, password, role); 
                                Console.WriteLine($"Sabte Nam Movafagh Bod !{currentUser.Username}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else if (answer == "2")
                        {
                            Console.WriteLine("shoma sarfe nazar kardin..");
                        }
                        else
                        {
                            Console.WriteLine("opsss....");
                        }
                    }
                }
                
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"Menu Asli - User: {currentUser?.Username ?? "Guest"}"); 
                    Console.WriteLine("1. Modriyat Khabgah");
                    Console.WriteLine("2. Modriyat Block");
                    Console.WriteLine("3. Modriyat Ashkhas");
                    Console.WriteLine("4. Modriyat Amval");
                    Console.WriteLine("5. Gozaresh Giri"); 
                    Console.WriteLine("0. Khoroj");
                    Console.Write("Entekhab Shoma: ");
                    string input2 = Console.ReadLine();

                    switch (input2)
                    {
                        case "1":
                            
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Menu Khabgah");
                                Console.WriteLine("1. Afzodan Khabgah");
                                Console.WriteLine("2. Virayesh Khabgah");
                                Console.WriteLine("3. Hazfe Khabgah");
                                Console.WriteLine("4. Namayesh Khabgah ha");
                                Console.WriteLine("0. Menu Asli");
                                Console.Write("Entekhab Shoma : ");
                                string khabgahInput = Console.ReadLine();
                                if (khabgahInput == "0") break;

                                switch (khabgahInput)
                                {
                                    case "1":
                                        khahbgah.AddKhabgah();
                                        break;
                                    case "2":
                                        khahbgah.EditDormitory();
                                        break;
                                    case "3":
                                        khahbgah.RemoveDormitory();
                                        break;
                                    case "4":
                                        khahbgah.ShowDormitories();
                                        break;
                                }
                                Console.WriteLine("\nBaraye edame ENTER bezanid...");
                                Console.ReadKey(); 
                            }
                            break;
                        case "2":
                            
                            bool runningBlock = true;
                            while (runningBlock)
                            {
                                Console.Clear(); 
                                Console.WriteLine("Menu Modiriyat Block");
                                Console.WriteLine("1. Add blook");
                                Console.WriteLine("2. Hazf blook");
                                Console.WriteLine("3. Virayesh blook");
                                Console.WriteLine("4. Namayesh list hame blookha");
                                Console.WriteLine("5. Menu Asli");

                                Console.Write("Entakhab shoma: ");
                                int choiceBlock = int.Parse(Console.ReadLine());

                                switch (choiceBlock)
                                {
                                    case 1:
                                        sharedBlockManager.AddBlock();
                                        break;
                                    case 2:
                                        sharedBlockManager.RemoveBlock();
                                        break;
                                    case 3:
                                        sharedBlockManager.EditBlock();
                                        break;
                                    case 4:
                                        sharedBlockManager.ShowBlocksByDormitory();
                                        break;
                                    case 5:
                                        runningBlock = false;
                                        break;
                                }
                                Console.WriteLine("\nBaraye edame ENTER bezanid...");
                                Console.ReadKey();
                            }
                            break;
                        case "3":
                            
                            bool backToMainMenuAshkhas = false;
                            while (!backToMainMenuAshkhas)
                            {
                                Console.Clear();
                                Console.WriteLine("Menu Modiriyat Ashkhas");
                                Console.WriteLine("1. Ezafe kardan daneshjoo");
                                Console.WriteLine("2. Namayesh daneshjooyan");
                                Console.WriteLine("3. Virayesh daneshjoo");
                                Console.WriteLine("4. Hazf daneshjoo");
                                Console.WriteLine("5. Sabt nam daneshjoo dar khabgah");
                                Console.WriteLine("6. Jabejaei daneshjoo");
                                Console.WriteLine("7. Ezafe kardan masoul khabgah");
                                Console.WriteLine("8. Virayesh masoul khabgah");
                                Console.WriteLine("9. Hazf masoul khabgah");
                                Console.WriteLine("10. Namayesh masoulan khabgah");
                                Console.WriteLine("11. Ezafe kardan masoul block");
                                Console.WriteLine("12. Virayesh masoul block");
                                Console.WriteLine("13. Hazf masoul block");
                                Console.WriteLine("14. Namayesh masoulan block");
                                Console.WriteLine("0. Khorooj az in menu");
                                Console.Write("Entekhab shoma: ");

                                string choiceAshkhas = Console.ReadLine();

                                Console.Clear(); 
                                switch (choiceAshkhas)
                                {
                                    case "1":
                                        manager.AddStudent();
                                        break;
                                    case "2":
                                        manager.ShowStudents();
                                        break;
                                    case "3":
                                        manager.EditStudent();
                                        break;
                                    case "4":
                                        manager.DeleteStudent();
                                        break;
                                    case "5":
                                        manager.RegisterStudentInDorm();
                                        break;
                                    case "6":
                                        manager.MoveStudent();
                                        break;
                                    case "7":
                                        manager.AddDormitoryManager();
                                        break;
                                    case "8":
                                        manager.EditDormitoryManager();
                                        break;
                                    case "9":
                                        manager.DeleteDormitoryManager();
                                        break;
                                    case "10":
                                        manager.ShowDormitoryManagers();
                                        break;
                                    case "11":
                                        manager.AddBlockManager();
                                        break;
                                    case "12":
                                        manager.EditBlockManager();
                                        break;
                                    case "13":
                                        manager.DeleteBlockManager();
                                        break;
                                    case "14":
                                        manager.ShowBlockManagers();
                                        break;
                                    case "0":
                                        backToMainMenuAshkhas = true; 
                                        break;
                                    default:
                                        Console.WriteLine("Gozine na motabar.");
                                        break;
                                }
                                if (!backToMainMenuAshkhas) 
                                {
                                    Console.WriteLine("\nBaraye edame ENTER bezanid...");
                                    Console.ReadKey(); 
                                }
                            }
                            break;
                        case "4":
                            
                            bool returnToMainMenuAmval = false;
                            while (!returnToMainMenuAmval)
                            {
                                Console.Clear();
                                Console.WriteLine("Menu Modiriyat Amval:");
                                Console.WriteLine("1. Afzoodan Tajhizat");
                                Console.WriteLine("2. Namayesh hame Tajhizat");
                                Console.WriteLine("3. Hazf Tajhizat");
                                Console.WriteLine("4. Jostejoo bar asas shomare daneshjoo");
                                Console.WriteLine("5. Namayesh amval dar har otagh");
                                Console.WriteLine("6. Namayesh amval mayoob va dar hale tamir"); 
                                Console.WriteLine("0. Bargasht be Menu Asli");

                                Console.Write("Entekhab shoma: ");
                                string amvalInput = Console.ReadLine();

                                switch (amvalInput)
                                {
                                    case "1":
                                        amvalManager.AddTajhizat();
                                        break;
                                    case "2":
                                        amvalManager.ShowAllTajhizat();
                                        break;
                                    case "3":
                                        amvalManager.DeleteTajhizat();
                                        break;
                                    case "4":
                                        amvalManager.SearchByStudentNumber();
                                        break;
                                    case "5":
                                       
                                        Console.Write("Lotfan shomareh otaghe mored nazar ra vared konid: ");
                                        if(int.TryParse(Console.ReadLine(), out int roomNum))
                                        {
                                            amvalManager.ShowAssetsByRoom(roomNum);
                                        } else {
                                            Console.WriteLine("Shomareh otagh namotabar ast.");
                                        }
                                        break;
                                    case "6":
                                        amvalManager.ShowDefectiveAssets();
                                        break;
                                    case "0":
                                        returnToMainMenuAmval = true;
                                        break;
                                    default:
                                        Console.WriteLine("Gozine na motabar.");
                                        break;
                                }
                                if (!returnToMainMenuAmval) 
                                {
                                    Console.WriteLine("\nBaraye edame ENTER bezanid...");
                                    Console.ReadKey();
                                }
                            }
                            break;

                        
                        case "5":
                            bool backToMain = false;
                            while (!backToMain)
                            {
                                Console.Clear();
                                Console.WriteLine("--- Menu-ye Gozaresh-giri ---");
                                Console.WriteLine("\n-- Gozaresh-e Vaziat-e Eskan --");
                                Console.WriteLine("1. Amar-e Kolli-e Eskan-e Daneshjooyan");
                                Console.WriteLine("2. List-e Otagh-haye Khali va Por");
                                Console.WriteLine("3. Zarfiat-e Baghimandeh-ye Har Khabgah va Block");
                                Console.WriteLine("\n-- Gozaresh-e Amval --");
                                Console.WriteLine("4. List-e Kamel-e Amval");
                                Console.WriteLine("5. Amval-e Takhsis dadeh shodeh be har Otagh");
                                Console.WriteLine("6. Amval-e Takhsis dadeh shodeh be har Daneshjoo");
                                Console.WriteLine("7. Amval-e Mayoob va dar hal-e Tamir");
                                Console.WriteLine("\n-- Gozaresh-haye Takhasosi --");
                                Console.WriteLine("8. Gozaresh-e Darkhast-haye Tamirat");
                                Console.WriteLine("9. Gozaresh-e Tarikhche-ye Eskan-e Daneshjooyan");
                                Console.WriteLine("0. Bazgasht be Menu-ye Asli");
                                Console.Write("\nEntekhab-e Shoma: ");
                                string choiceGozaresh = Console.ReadLine();

                                switch (choiceGozaresh)
                                {
                                    case "1":
                                        reportGenerator.ShowOverallAccommodationStats();
                                        break;
                                    case "2":
                                        reportGenerator.ShowRoomOccupancyList();
                                        break;
                                    case "3":
                                        reportGenerator.ShowDormAndBlockCapacity();
                                        break;
                                    case "4":
                                        reportGenerator.ShowFullAssetList();
                                        break;
                                    case "5":
                                        reportGenerator.ShowAssetsByRoom();
                                        break;
                                    case "6":
                                        reportGenerator.ShowAssetsByStudent();
                                        break;
                                    case "7":
                                        reportGenerator.ShowDefectiveAssets();
                                        break;
                                    case "8":
                                        reportGenerator.ShowRepairRequestsReport();
                                        break;
                                    case "9":
                                        reportGenerator.ShowStudentAccommodationHistory();
                                        break;
                                    case "0":
                                        backToMain = true; 
                                        break;
                                    default:
                                        Console.WriteLine("Gozine na motabar.");
                                        break;
                                }

                                if (!backToMain) 
                                {
                                    Console.WriteLine("\nBaraye edame ENTER bezanid...");
                                    Console.ReadKey();
                                }
                            }
                            break;

                        case "0":
                            Console.WriteLine("khoroj...");
                            return; 
                        default:
                            Console.WriteLine("Gozine na motabar. Lotfan dobare talash konid.");
                            break;
                    }
                   
                    if (input2 != "0")
                    {
                        Console.WriteLine("\nBaraye bazgasht be Menu Asli ENTER bezanid...");
                        Console.ReadKey();
                    }
                }
            }
            else if (input == 2)
            {
                Console.WriteLine("khoroj...");
                return; 
            }
        }
    }
}