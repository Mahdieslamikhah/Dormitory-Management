using System;
using System.Data;
using DormitoryManagement;

class Program
{
    static void Main()
    {
        ModriyatKhahbgah khahbgah = new ModriyatKhahbgah();
        khahbgah.AddMasoulKhabgah(new Masoulkhabgah("mahdi", "eslami", 3040, 0913, "kerman", "modir", "sq"));
        UserManager userManager = new UserManager();
        
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Welcom To Dormitory Management..");
            Console.WriteLine();
            Console.WriteLine("1. Singup / Singin");
            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                Console.Write("User Name : ");
                string username = Console.ReadLine();
                if (userManager.UserExists(username))
                {
                    Console.Write("Password :");
                    string password = Console.ReadLine();
                    User user = userManager.Login(username, password);
                    if (user != null)
                    {
                        Console.WriteLine($"welcome {user.Username}");
                        Console.WriteLine("1. Modriyat Khabgah");
                        Console.WriteLine("2. Modriyat Block");
                        Console.WriteLine("3. Modriyat Ashkhas");
                        Console.WriteLine("4. Modriyat Danshjoyan");
                        string input2 = Console.ReadLine();
                        switch (input2)
                        {
                            case "1":
                                while (true) // حلقه برای منوی مدیریت خوابگاه
                                {
                                    Console.WriteLine("1. Namayesh Khabgah ha");
                                    Console.WriteLine("2. Afzodan Khabgah");
                                    Console.WriteLine("3. Virayesh Khabgah");
                                    Console.WriteLine("4. Hazfe Khabgah");
                                    Console.WriteLine("0. bargasht");
                                    
                                    string khabgahInput = Console.ReadLine();
                                    if (khabgahInput == "0") break; // اگر کاربر 0 را وارد کرد، به منوی اصلی برگردد

                                    switch (khabgahInput)
                                    {
                                        case "1":
                                        // کد نمایش خوابگاها
                                            break;
                                        case "2":
                                            Console.WriteLine("NameKhabgah Ra Vared Konid : ");
                                            string name = Console.ReadLine();
                                            Console.WriteLine("Address Khabgah Ra Vared Konid : ");
                                            string loc = Console.ReadLine();
                                            Console.WriteLine("Zarfiyat Khabgah Ra Vared Konid : ");
                                            int zarfiyat = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Lotfan Shomare Masoal Khabgah Ra Entekhab Konid : ");
                                            khahbgah.ListMasoulhayekhabgah();
                                            int somareMasoulKhabgah = int.Parse(Console.ReadLine());
                                            khahbgah.AddKhabgah(new Khabgah(name, loc, zarfiyat, null, null));
                                            break;
                                        case "3":
                                            // کد برای ویرایش خوابگاه
                                            break;
                                        case "4":
                                            // کد برای حذف خوابگاه
                                            break;
                                        default:
                                            Console.WriteLine("گزینه نامعتبر است.");
                                            break;
                                    }
                                }
                                break;
                            case "2":
                                ClassModiriyatBlook blookManager = new ClassModiriyatBlook();

                                bool running = true;
                                while (running)
                                {
                                    Console.WriteLine("\nmodiriyat blook");
                                    Console.WriteLine("1.Add blook");
                                    Console.WriteLine("2. hazf bllok");
                                    Console.WriteLine("3. virayesh blook");
                                    Console.WriteLine("4. namayesh list hameblookha");
                                    Console.WriteLine("5. khorooj");

                                    Console.Write(" entekhab shoma: ");
                                    int choice = int.Parse(Console.ReadLine());

                                    switch (choice)
                                    {
                                        case 1:
                                            blookManager.AddBlook();
                                            break;
                                        case 2:
                                            blookManager.DeleteBlook();
                                            break;
                                        case 3:
                                            blookManager.EditBlook();
                                            break;
                                        case 4:
                                            blookManager.ShowAllBlooks();
                                            break;
                                        case 5:
                                            running = false;
                                            break;
                                        default:
                                            Console.WriteLine(" گزینه نامعتبر است.");
                                            break;
                                    }
                                }
                                break;

                                // سایر گزینه‌ها...
                        }
                    }
                    else
                    {
                        Console.WriteLine("نام کاربری یا رمز عبور اشتباه است.");
                    }
                }
                else
                {
                    Console.WriteLine("In username vojod nadarad jahat sabtenam 1 ra vared konid : ");
                    string answer = Console.ReadLine();

                    if (answer == "1") // ثبت‌نام
                    {
                        Console.Write("password : ");
                        string password = Console.ReadLine();

                        // نمایش منوی انتخاب نقش
                        Console.WriteLine("Naghshe khod ra Entekhab Konid");
                        Console.WriteLine("1.Masoul Khabgah");
                        Console.WriteLine("2.Masoul Blook");
                        Console.WriteLine("3.Daneshjoo");
                        string naghshChoice = Console.ReadLine();
                        string role = "";

                        // تعیین نقش بر اساس ورودی کاربر
                        switch (naghshChoice)
                        {
                            case "1":
                                role = "مسئول خوابگاه";
                                break;
                            case "2":
                                role = "مسئول بلوک";
                                break;
                            case "3":
                                role = "دانشجو";
                                break;
                            default:
                                Console.WriteLine("نقش نامعتبر است. به عنوان دانشجو ثبت‌نام می‌کنید.");
                                role = "دانشجو"; // پیش‌فرض
                                break;
                        }

                        try
                        {
                            userManager.Rigister(username, password, role);
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
                Console.WriteLine();
            }
        }
        return;
    }
}