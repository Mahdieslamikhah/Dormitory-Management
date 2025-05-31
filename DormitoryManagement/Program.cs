using System;
using System.Data;
using DormitoryManagement;
    class Program
    {
        static void Main()
        {
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
                Console.WriteLine("User Name : ");
                string username = Console.ReadLine();
                if (userManager.UserExists(username))
                {
                    Console.WriteLine("Password :");
                    string password = Console.ReadLine();
                    User user = userManager.Login(username, password);
                    if (user != null)
                    {

                        Console.WriteLine($"به سیستم خوش آمدید، {user.Username} - نقش: {user.Naghsh}");
                        Console.WriteLine("1. Modriyat Khabgah");
                        Console.WriteLine("2. Modriyat Block");
                        Console.WriteLine("1. Modriyat Ashkhas");
                        Console.WriteLine("1. Modriyat Danshjoyan");
                    }
                    else
                    {
                        Console.WriteLine("نام کاربری یا رمز عبور اشتباه است.");
                    }
                }

            else
            {
                
                Console.Write("این نام کاربری وجود ندارد. آیا می‌خواهید ثبت‌نام کنید؟ (1: بله / 2: خیر): ");
                string answer = Console.ReadLine();

                if (answer == "1") // ثبت‌نام
                {
                    Console.Write("رمز عبور: ");
                    string password = Console.ReadLine();

                    // نمایش منوی انتخاب نقش
                    Console.WriteLine("نقش خود را انتخاب کنید:");
                    Console.WriteLine("1. مسئول خوابگاه");
                    Console.WriteLine("2. مسئول بلوک");
                    Console.WriteLine("3. دانشجو");
                    Console.Write("عدد مربوط به نقش خود را وارد کنید: ");
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

    
