using System;
using System.Collections.Generic;
using System.Linq;

namespace DormitoryManagement
{
    public class ModiriyatAshkhas
    {
        private ClassModiriyatBlook blookManager;
        private ModriyatKhahbgah dormitoryManager;
        private List<Daneshjoo> students = new List<Daneshjoo>();
        public ModiriyatAshkhas(ClassModiriyatBlook blookManager, ModriyatKhahbgah dormitoryManager)
        {
            this.blookManager = blookManager;
            this.dormitoryManager = dormitoryManager;
        }
        public ClassModiriyatBlook BlookManager
        {
            set { blookManager = value; }
        }

        public ModriyatKhahbgah DormitoryManager
        {
            set { dormitoryManager = value; }
        }

        public void AddDormitoryManager()
        {
            var dorms = dormitoryManager.GetDormitoryList();
            if (dorms.Count == 0)
            {
                Console.WriteLine("Hich khabgahi vojood nadarad.");
                return;
            }

            Console.WriteLine("List khabgah-ha:");
            for (int i = 0; i < dorms.Count; i++)
                Console.WriteLine($"{i + 1}. {dorms[i].Namekhabgah}");

            Console.WriteLine("Shomare khabgah ra baraye afzoodan masoul vared konid:");
            int selectedIndex = int.Parse(Console.ReadLine()) - 1;
            if (selectedIndex < 0 || selectedIndex >= dorms.Count)
            {
                Console.WriteLine("Entekhab namotabar.");
                return;
            }

            var selectedDorm = dorms[selectedIndex];

            Console.WriteLine("Nam masoul:");
            string name = Console.ReadLine();
            Console.WriteLine("Nam khanevadegi:");
            string lastname = Console.ReadLine();
            Console.WriteLine("Code Melli:");
            int nationalCode = int.Parse(Console.ReadLine());
            Console.WriteLine("Shomare tamas:");
            int phone = int.Parse(Console.ReadLine());
            Console.WriteLine("Adres:");
            string address = Console.ReadLine();

            selectedDorm.Masoulkhabgah = new Masoulkhabgah(name, lastname, nationalCode, phone, address,"Masoul Khabgah", selectedDorm.Namekhabgah);

            Console.WriteLine("Masoul khabgah ba movafaghiat afzode shod.");
        }

        public void EditDormitoryManager()
        {
            var dorms = dormitoryManager.GetDormitoryList();
            if (dorms.Count == 0)
            {
                Console.WriteLine("Hich khabgahi vojood nadarad.");
                return;
            }

            Console.WriteLine("List khabgah-ha:");
            for (int i = 0; i < dorms.Count; i++)
                Console.WriteLine($"{i + 1}. {dorms[i].Namekhabgah}");

            Console.WriteLine("Shomare khabgah ra baraye virayesh masoul vared konid:");
            int index = int.Parse(Console.ReadLine()) - 1;
            if (index < 0 || index >= dorms.Count)
            {
                Console.WriteLine("Shomare namotabar.");
                return;
            }

            Console.WriteLine("Aya mikhahid etelaat masoul ra virayesh konid? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
                AddDormitoryManager();
        }
        public void AddBlockManager()
        {
            Console.WriteLine("Nam khabgah ra vared konid:");
            string dormName = Console.ReadLine();

            Console.WriteLine("Nam block ra vared konid:");
            string blockName = Console.ReadLine();

            var block = blookManager.GetAllBlocks().FirstOrDefault(b => b.BlockName == blockName && b.DormitoryName == dormName);
            if (block == null)
            {
                Console.WriteLine("Block yaft nashod.");
                return;
            }

            if (students.Count == 0)
            {
                Console.WriteLine("Hich daneshjooei sabt nashode ast.");
                return;
            }

            Console.WriteLine("List daneshjooyan:");
            for (int i = 0; i < students.Count; i++)
            {
                var s = students[i];
                Console.WriteLine($"{i + 1}. {s.Name} {s.Lastname} - Shomare: {s.Daneshjonumber}");
            }

            Console.WriteLine("Shomare daneshjoo ra entekhab konid:");
            int selectedIndex = int.Parse(Console.ReadLine()) - 1;
            if (selectedIndex < 0 || selectedIndex >= students.Count)
            {
                Console.WriteLine("Entekhab namotabar.");
                return;
            }

            var selected = students[selectedIndex];
            block.BlockManager = new Masoulblook("Masoul Block", block.BlockName, selected.Daneshjonumber,
                selected.Otagh, selected.Blook, selected.Khabgah, selected.Tajhizat,
                selected.Name, selected.Lastname, selected.Nationalnumber, selected.Phonenumber, selected.Adress);

            Console.WriteLine("Masoul block entekhab shod.");
        }
        public void RegisterStudentInDorm()
        {
            Console.WriteLine("lotfan Enter Bezanid..");
            ShowStudents();
            Console.WriteLine("Shomare daneshjoo ra vared konid:");
            int id = int.Parse(Console.ReadLine());
            var student = students.FirstOrDefault(s => s.Daneshjonumber == id);
            if (student == null)
            {
                Console.WriteLine("Daneshjoo yaft nashod.");
                return;
            }
            Console.ReadKey();
            var dorms = dormitoryManager.GetDormitoryList();
            if (dorms.Count == 0)
            {
                Console.WriteLine("Hich khabgahi vojood nadarad.");
                return;
            }

            Console.WriteLine("List khabgah-ha:");
            for (int i = 0; i < dorms.Count; i++)
                Console.WriteLine($"{i + 1}. {dorms[i].Namekhabgah}");
            Console.WriteLine("Entekhab khabgah:");
            int dormIndex = int.Parse(Console.ReadLine()) - 1;

            var selectedDorm = dorms[dormIndex];
            var blocks = blookManager.GetAllBlocks().Where(b => b.DormitoryName == selectedDorm.Namekhabgah).ToList();

            if (blocks.Count == 0)
            {
                Console.WriteLine("Block vojood nadarad.");
                return;
            }

            Console.WriteLine("List block-ha:");
            for (int i = 0; i < blocks.Count; i++)
                Console.WriteLine($"{i + 1}. {blocks[i].BlockName}");
            Console.WriteLine("Entekhab block:");
            int blockIndex = int.Parse(Console.ReadLine()) - 1;

            var selectedBlock = blocks[blockIndex];

            Console.WriteLine("Shomare otagh:");
            int roomNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Tabaghe otagh:");
            int floor = int.Parse(Console.ReadLine());
            Otagh otagh = new Otagh(roomNumber, floor, selectedBlock);
            student.Otagh = otagh;

            student.Khabgah = selectedDorm;
            student.Blook = selectedBlock;
            otagh.DaneshjoosMarbote.Add(student);

            Console.WriteLine("Sabt naam anjam shod.");
        }


        public void MoveStudent()
        {
            ShowStudents();
            Console.WriteLine("Shomare daneshjoo ra vared konid:");
            int id = int.Parse(Console.ReadLine());
            var student = students.FirstOrDefault(s => s.Daneshjonumber == id);
            if (student == null)
            {
                Console.WriteLine("Daneshjoo yaft nashod.");
                return;
            }

            Console.WriteLine("Gozaresh makan ghabli: ");
            Console.WriteLine($"Khabgah: {student.Khabgah}, Blook: {student.Blook}, Otagh: {student.Otagh}");

            RegisterStudentInDorm();
        }

        public void EditBlockManager()
        {
            Console.WriteLine("Nam khabgah ra vared konid:");
            string dormName = Console.ReadLine();

            Console.WriteLine("Nam block ra vared konid:");
            string blockName = Console.ReadLine();

            var block = blookManager.GetAllBlocks().FirstOrDefault(b => b.BlockName == blockName && b.DormitoryName == dormName);
            if (block == null)
            {
                Console.WriteLine("Block yaft nashod.");
                return;
            }

            Console.WriteLine("Masoul feli:");
            Console.WriteLine(block.BlockManager != null ? $"{block.BlockManager.Name}" : "Masouli sabt nashode.");

            Console.WriteLine("Aya mikhahid taghir dahid? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
                AddBlockManager();
        }
        public void AddStudent()
        {
            Console.WriteLine("Nam:");
            string name = Console.ReadLine();
            Console.WriteLine("Nam khanevadegi:");
            string lastname = Console.ReadLine();
            Console.WriteLine("Code melli:");
            int national = int.Parse(Console.ReadLine());
            Console.WriteLine("Shomare tamas:");
            int phone = int.Parse(Console.ReadLine());
            Console.WriteLine("Adres:");
            string address = Console.ReadLine();
            Console.WriteLine("Shomare daneshjooei:");
            int studentNum = int.Parse(Console.ReadLine());
            Daneshjoo newStudent = new Daneshjoo(studentNum, null, null, null, new List<Tajhizat>(), name, lastname, national, phone, address);
            students.Add(newStudent);
            Console.WriteLine("Daneshjoo ezafe shod.");
        }

        public void EditStudent()
        {
            ShowStudents();

            Console.WriteLine("Shomare daneshjooei ra vared konid:");
            int id = int.Parse(Console.ReadLine());

            var student = students.FirstOrDefault(s => s.Daneshjonumber == id);
            if (student == null)
            {
                Console.WriteLine("Daneshjoo yaft nashod.");
                return;
            }

            Console.WriteLine("Nam jadid:");
            student.Name = Console.ReadLine();
            Console.WriteLine("Nam khanevadegi jadid:");
            student.Lastname = Console.ReadLine();
            Console.WriteLine("Shomare tamas jadid:");
            student.Phonenumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Adres jadid:");
            student.Adress = Console.ReadLine();

            Console.WriteLine("Daneshjoo virayesh shod.");
        }

        public void DeleteStudent()
        {
            ShowStudents();
            Console.WriteLine("Shomare daneshjooei ra baraye hazf vared konid:");
            int id = int.Parse(Console.ReadLine());

            var student = students.FirstOrDefault(s => s.Daneshjonumber == id);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine("Daneshjoo hazf shod.");
            }
            else
            {
                Console.WriteLine("Daneshjoo yaft nashod.");
            }
        }

        public void ShowStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Hich daneshjooei vojood nadarad.");
                return;
            }

            Console.WriteLine("List daneshjooyan:");
            foreach (var s in students)
            {
                Console.WriteLine($"{s.Name} {s.Lastname} - {s.Daneshjonumber}");
            }
            Console.ReadKey();
        }
        public void DeleteDormitoryManager()
        {
            var dorms = dormitoryManager.GetDormitoryList();
            if (dorms.Count == 0)
            {
                Console.WriteLine("Hich khabgahi vojood nadarad.");
                return;
            }

            Console.WriteLine("List khabgah-ha:");
            for (int i = 0; i < dorms.Count; i++)
                Console.WriteLine($"{i + 1}. {dorms[i].Namekhabgah}");

            Console.WriteLine("Shomare khabgah ra baraye hazf masoul vared konid:");
            int index = int.Parse(Console.ReadLine()) - 1;
            if (index < 0 || index >= dorms.Count)
            {
                Console.WriteLine("Shomare namotabar.");
                return;
            }

            var selectedDorm = dorms[index];
            if (selectedDorm.Masoulkhabgah == null)
            {
                Console.WriteLine("Masoul khabgah baraye in khabgah sabt nashode ast.");
                return;
            }

            selectedDorm.Masoulkhabgah = null;
            Console.WriteLine("Masoul khabgah hazf shod.");
        }
        public void ShowDormitoryManagers()
        {
            var dorms = dormitoryManager.GetDormitoryList();
            if (dorms.Count == 0)
            {
                Console.WriteLine("Hich khabgahi vojood nadarad.");
                return;
            }

            Console.WriteLine("List masoul khabgah-ha:");
            foreach (var dorm in dorms)
            {
                if (dorm.Masoulkhabgah != null)
                    Console.WriteLine($"{dorm.Namekhabgah}: {dorm.Masoulkhabgah.Name} {dorm.Masoulkhabgah.Lastname}");
                else
                    Console.WriteLine($"{dorm.Namekhabgah}: Masoul sabt nashode ast.");
            }
            Console.ReadKey();
        }
        public void DeleteBlockManager()
        {
            Console.WriteLine("Nam khabgah ra vared konid:");
            string dormName = Console.ReadLine();

            Console.WriteLine("Nam block ra vared konid:");
            string blockName = Console.ReadLine();

            var block = blookManager.GetAllBlocks().FirstOrDefault(b => b.BlockName == blockName && b.DormitoryName == dormName);
            if (block == null)
            {
                Console.WriteLine("Block yaft nashod.");
                return;
            }

            if (block.BlockManager == null)
            {
                Console.WriteLine("Masoul block baraye in block sabt nashode ast.");
                return;
            }

            block.BlockManager = null;
            Console.WriteLine("Masoul block hazf shod.");
        }
        public void ShowBlockManagers()
        {
            Console.WriteLine("Nam khabgah ra vared konid:");
            string dormName = Console.ReadLine();

            var blocks = blookManager.GetAllBlocks()
            .Where(b => b.DormitoryName == dormName)
            .ToList();


            Console.WriteLine("List masoul block-ha:");
            foreach (var block in blocks)
            {
                if (block.BlockManager != null)
                    Console.WriteLine($"{block.BlockName} ({block.DormitoryName}): {block.BlockManager.Name} {block.BlockManager.Lastname}");
                else
                    Console.WriteLine($"{block.BlockName} ({block.DormitoryName}): Masoul sabt nashode ast.");
            }
            Console.ReadKey();
        }
        public Daneshjoo FindDaneshjooByNumber(int number)
        {
            return students.FirstOrDefault(d => d.Daneshjonumber == number);
        }
        public List<Daneshjoo> GetAllStudents()
        {
            return students;
        }
    }
}
