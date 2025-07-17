using System;
using System.Data;
using DormitoryManagement;

class Program
{
    static void Main()
    {
        ModriyatKhahbgah khahbgah = new ModriyatKhahbgah();
        UserManager userManager = new UserManager();
        User currentUser = null; // متغیری برای نگهداری کاربر فعلی
        ClassModiriyatBlook sharedBlockManager = new ClassModiriyatBlook(khahbgah);
        ModiriyatAshkhas manager = new ModiriyatAshkhas(sharedBlockManager, khahbgah);
        ClassModiriyatAmval amvalManager = new ClassModiriyatAmval(manager);


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
                            Console.WriteLine("Naghshe Shoma : ");
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

                // نمایش منوی اصلی
                while (true)
                {
                    Console.WriteLine($"Menu Asli");
                    Console.WriteLine("1. Modriyat Khabgah");
                    Console.WriteLine("2. Modriyat Block");
                    Console.WriteLine("3. Modriyat Ashkhas");
                    Console.WriteLine("4. Modriyat Amval");
                    Console.WriteLine("0. خروج");
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
                                Console.WriteLine("0.Menu Asli");
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
                                    default:
                                        Console.WriteLine("گزینه نامعتبر است.");
                                        break;
                                }
                            }
                            break;
                        case "2":
                            bool running = true;
                            while (running)
                            {
                                Console.WriteLine("\nmodiriyat blook");
                                Console.WriteLine("1. Add blook");
                                Console.WriteLine("2. Hazf blook");
                                Console.WriteLine("3. Virayesh blook");
                                Console.WriteLine("4. Namayesh list hameblookha");
                                Console.WriteLine("5.Menu Asli");

                                Console.Write("Entakhab shoma: ");
                                int choice = int.Parse(Console.ReadLine());

                                switch (choice)
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
                                        running = false;
                                        break;
                                    default:
                                        Console.WriteLine("گزینه نامعتبر است.");
                                        break;
                                }
                            }
                            break;
                        case "3":
                            bool backToMainMenu = false;
                            while (!backToMainMenu)
                            {
                                Console.Clear();
                                Console.WriteLine("===== Samane Modiriyat Khabgah =====");
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
                                Console.WriteLine("0. Khorooj");
                                Console.Write("Entekhab shoma: ");

                                string choice = Console.ReadLine();

                                Console.Clear();
                                    switch (choice)
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
                                    }
                                }
                            break;
                        case "4":
                            bool returnToMainMenu = false;
                            while (!returnToMainMenu)
                            {
                                Console.Clear();
                                Console.WriteLine("Menu Modiriyat Amval:");
                                Console.WriteLine("1. Afzoodan Tajhizat");
                                Console.WriteLine("2. Namayesh hame Tajhizat");
                                Console.WriteLine("3. Hazf Tajhizat");
                                Console.WriteLine("4. Jostejoo bar asas shomare daneshjoo");
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
                                    case "0":
                                        returnToMainMenu = true;
                                        break;
                                    default:
                                        Console.WriteLine("Gozine na motabar.");
                                        break;
                                }

                                Console.WriteLine("\nBaraye edame ENTER bezanid...");
                                Console.ReadKey();
                            }
                            Console.WriteLine("\nBaraye edame kelidi bezanid...");
                            Console.ReadKey();
                            break;
                            
                        case "0":
                            Console.WriteLine("khoroj...");
                            return; // خروج از برنامه
                    }
                }
            }
            else if (input == 2)
            {
                Console.WriteLine("khoroj...");
                return; // خروج از برنامه
            }
        }
    }
}