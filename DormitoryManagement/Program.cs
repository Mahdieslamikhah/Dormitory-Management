using System;
using System.Data;
using System.Security.AccessControl;
using DormitoryManagement; // مطمئن شوید که فضای نام ReportGenerator در اینجا نیز باشد

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
        
        // ایجاد نمونه ReportGenerator در اینجا
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
                // اگر کاربر فعلی وجود دارد، به منوی اصلی بروید
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
                        currentUser = userManager.Login(username, password); // ورود کاربر
                        if (currentUser != null)
                        {
                            Console.WriteLine($"Welcome {currentUser.Username}");
                        }
                        else
                        {
                            Console.WriteLine("نام کاربری یا رمز عبور اشتباه است.");
                            continue; // بازگشت به حلقه اصلی
                        }
                    }
                    else
                    {
                        Console.WriteLine("User vojod nadard jahate sabte nam 1 ra vared konid : ");
                        string answer = Console.ReadLine();

                        if (answer == "1") // ثبت‌نام
                        {
                            Console.Write("Password : ");
                            string password = Console.ReadLine();

                            // نمایش منوی انتخاب نقش
                            Console.WriteLine(">> Naghshe Shoma : ");
                            Console.WriteLine("1.Masol Khabgah");
                            Console.WriteLine("2.Masol Blook");
                            Console.WriteLine("3.Daneshjoo");
                            string naghshChoice = Console.ReadLine();
                            string role = "";

                            // تعیین نقش بر اساس ورودی کاربر
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
                                    role = "دانشجو"; // پیش‌فرض
                                    break;
                            }

                            try
                            {
                                userManager.Register(username, password, role);
                                // کاربر جدید ثبت‌نام شده را به عنوان کاربر فعلی تنظیم کنید
                                currentUser = new User(username, password, role); // فرض می‌کنیم که کلاس User سازنده‌ای دارد
                                Console.WriteLine($"Sabte Nam Movafagh Bod !{currentUser.Username}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else if (answer == "2")
                        {
                            Console.WriteLine("شما از ثبت‌نام صرف‌نظر کردید.");
                        }
                        else
                        {
                            Console.WriteLine("گزینه نامعتبر است.");
                        }
                    }
                }
                // حلقه منوی اصلی برنامه
                while (true)
                {
                    Console.Clear(); // پاک کردن صفحه برای نمایش منوی اصلی
                    Console.WriteLine($"Menu Asli - User: {currentUser?.Username ?? "Guest"}"); // نمایش نام کاربر یا مهمان
                    Console.WriteLine("1. Modriyat Khabgah");
                    Console.WriteLine("2. Modriyat Block");
                    Console.WriteLine("3. Modriyat Ashkhas");
                    Console.WriteLine("4. Modriyat Amval");
                    Console.WriteLine("5. Gozaresh Giri"); // منوی گزارش
                    Console.WriteLine("0. Khoroj");
                    Console.Write("Entekhab Shoma: ");
                    string input2 = Console.ReadLine();

                    switch (input2)
                    {
                        case "1":
                            // مدیریت خوابگاه
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
                                Console.ReadKey(); // انتظار برای ادامه
                            }
                            break;
                        case "2":
                            // مدیریت بلاک
                            bool runningBlock = true;
                            while (runningBlock)
                            {
                                Console.Clear(); // پاک کردن صفحه برای منوی بلاک
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
                                Console.ReadKey(); // انتظار برای ادامه
                            }
                            break;
                        case "3":
                            // مدیریت اشخاص (دانشجو و مسئولین)
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
                                Console.WriteLine("0. Khorooj az in menu"); // تغییر متن برای بازگشت به منوی اصلی
                                Console.Write("Entekhab shoma: ");

                                string choiceAshkhas = Console.ReadLine();

                                Console.Clear(); // پاک کردن صفحه بعد از دریافت ورودی
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
                                        backToMainMenuAshkhas = true; // خروج از حلقه مدیریت اشخاص
                                        break;
                                    default:
                                        Console.WriteLine("Gozine na motabar.");
                                        break;
                                }
                                if (!backToMainMenuAshkhas) // اگر از حلقه خارج نشده‌ایم، منتظر کلید باش
                                {
                                    Console.WriteLine("\nBaraye edame ENTER bezanid...");
                                    Console.ReadKey(); 
                                }
                            }
                            break;
                        case "4":
                            // مدیریت اموال
                            bool returnToMainMenuAmval = false;
                            while (!returnToMainMenuAmval)
                            {
                                Console.Clear();
                                Console.WriteLine("Menu Modiriyat Amval:");
                                Console.WriteLine("1. Afzoodan Tajhizat");
                                Console.WriteLine("2. Namayesh hame Tajhizat");
                                Console.WriteLine("3. Hazf Tajhizat");
                                Console.WriteLine("4. Jostejoo bar asas shomare daneshjoo");
                                Console.WriteLine("5. Namayesh amval dar har otagh"); // اضافه شده
                                Console.WriteLine("6. Namayesh amval mayoob va dar hale tamir"); // اضافه شده
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
                                        // نیاز به ورودی شماره اتاق برای این تابع
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
                                if (!returnToMainMenuAmval) // اگر از حلقه خارج نشده‌ایم، منتظر کلید باش
                                {
                                    Console.WriteLine("\nBaraye edame ENTER bezanid...");
                                    Console.ReadKey();
                                }
                            }
                            break;

                        // منوی گزارش گیری
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
                                        backToMain = true; // خروج از حلقه منوی گزارش
                                        break;
                                    default:
                                        Console.WriteLine("Gozine na motabar.");
                                        break;
                                }

                                if (!backToMain) // اگر از حلقه خارج نشده‌ایم، منتظر کلید باش
                                {
                                    Console.WriteLine("\nBaraye edame ENTER bezanid...");
                                    Console.ReadKey();
                                }
                            }
                            break;

                        case "0":
                            Console.WriteLine("khoroj...");
                            return; // خروج از برنامه
                        default:
                            Console.WriteLine("Gozine na motabar. Lotfan dobare talash konid.");
                            break;
                    }
                    // بعد از انتخاب هر گزینه اصلی (غیر از خروج)، دوباره منتظر کلید بمانید تا منوی اصلی دوباره نمایش داده شود
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
                return; // خروج از برنام
            }
        }
    }
}

// برای اینکه کد بالا کامپایل شود، نیاز به کلاس‌های User، UserManager، ModiriyatAshkhas، ModriyatKhahbgah، ClassModiriyatBlook و ClassModiriyatAmval داریم.
// اگر این کلاس‌ها را ندارید، لطفاً آنها را نیز ارسال کنید.

// فرض بر این است که کلاس User دارای سازنده‌ای مشابه زیر است:
/*
public class User
{
    public string Username { get; }
    public string Password { get; } // معمولا رمز عبور به صورت هش شده ذخیره می‌شود
    public string Role { get; }

    public User(string username, string password, string role)
    {
        Username = username;
        Password = password;
        Role = role;
    }
}
*/

// فرض بر این است که کلاس UserManager دارای متدهای UserExists، Login و Register است.
// و کلاس‌های ModiriyatAshkhas، ModriyatKhahbgah، ClassModiriyatBlook و ClassModiriyatAmval نیز متدهای مورد نیاز را دارند.
