using DormitoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;

public class ClassModiriyatBlook
{
    private List<Blook> blocks = new List<Blook>();
    private ModriyatKhahbgah dormManager;

    public ClassModiriyatBlook(ModriyatKhahbgah dormManager)
    {
        this.dormManager = dormManager;
    }
    private ModiriyatAshkhas ashkhasManager;

    public ClassModiriyatBlook(ModriyatKhahbgah dormManager, ModiriyatAshkhas ashkhasManager)
    {
        this.dormManager = dormManager;
        this.ashkhasManager = ashkhasManager;
    }


    public ClassModiriyatBlook() { }

    public void AddBlock()
    {
        Console.WriteLine("Name block ra vared konid:");
        string name = Console.ReadLine();

        Console.WriteLine("Tedad tabaghat ra vared konid:");
        int floors = int.Parse(Console.ReadLine());

        Console.WriteLine("Tedad otagh-ha ra vared konid:");
        int rooms = int.Parse(Console.ReadLine());

        Console.WriteLine("List khabgah-ha:");
        var dormitories = dormManager.GetDormitoryList();
        for (int i = 0; i < dormitories.Count; i++)
            Console.WriteLine($"{i + 1}. {dormitories[i].Namekhabgah}");

        Console.WriteLine("Lotfan shomare khabgah ra entekhab konid:");
        int selectedIndex = int.Parse(Console.ReadLine()) - 1;

        if (selectedIndex < 0 || selectedIndex >= dormitories.Count)
        {
            Console.WriteLine("Entekhab na motabar ast.");
            return;
        }

        string dormitoryName = dormitories[selectedIndex].Namekhabgah;

        if (blocks.Any(b => b.BlockName == name && b.DormitoryName == dormitoryName))
        {
            Console.WriteLine("Block ba in name dar in khabgah ghablan sabt shode.\n");
            return;
        }
        var students = ashkhasManager.GetAllStudents();
        if (students.Count == 0)
        {
            Console.WriteLine("Hich daneshjooei sabt nashode ast.");
            return;
        }

        Console.WriteLine("List daneshjooyan:");
        for (int i = 0; i < students.Count; i++)
        {
            var s = students[i];
            Console.WriteLine($"{i + 1}. {s.Name} {s.Lastname} - {s.Daneshjonumber}");
        }

        Console.WriteLine("Shomare daneshjoo ra baraye masoul entekhab konid:");
        int stuIndex = int.Parse(Console.ReadLine()) - 1;
        if (stuIndex < 0 || stuIndex >= students.Count)
        {
            Console.WriteLine("Entekhab namotabar.");
            return;
        }

        var selected = students[stuIndex];

        blocks.Add(new Blook
        {
            BlockName = name,
            DormitoryName = dormitoryName,
            NumberOfFloors = floors,
            NumberOfRooms = rooms,
            BlockManager = new Masoulblook("Masoul Block", name, selected.Daneshjonumber,
                selected.Otagh, selected.Blook, selected.Khabgah, selected.Tajhizat,
                selected.Name, selected.Lastname, selected.Nationalnumber, selected.Phonenumber, selected.Adress)
        });

        Console.WriteLine($"Block '{name}' baraye khabgah '{dormitoryName}' ba movafaghiat ezafe shod.\n");
    }

    public void EditBlock()
    {
        Console.WriteLine("Name block ra vared konid:");
        string name = Console.ReadLine();

        Console.WriteLine("Name khabgah marboot ra vared konid:");
        string dormitoryName = Console.ReadLine();

        var block = blocks.FirstOrDefault(b => b.BlockName == name && b.DormitoryName == dormitoryName);
        if (block != null)
        {
            Console.WriteLine("Name jadid block:");
            block.BlockName = Console.ReadLine();

            Console.WriteLine("Tedad tabaghat jadid:");
            block.NumberOfFloors = int.Parse(Console.ReadLine());

            Console.WriteLine("Tedad otagh jadid:");
            block.NumberOfRooms = int.Parse(Console.ReadLine());

            Console.WriteLine("Aya mikhahid masoul block ra taghir dahid? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                var students = ashkhasManager.GetAllStudents();
                if (students.Count == 0)
                {
                    Console.WriteLine("Hich daneshjooei vojood nadarad.");
                    return;
                }

                Console.WriteLine("List daneshjooyan:");
                for (int i = 0; i < students.Count; i++)
                {
                    var s = students[i];
                    Console.WriteLine($"{i + 1}. {s.Name} {s.Lastname} - {s.Daneshjonumber}");
                }

                Console.WriteLine("Shomare daneshjoo ra entekhab konid:");
                int stuIndex = int.Parse(Console.ReadLine()) - 1;
                if (stuIndex < 0 || stuIndex >= students.Count)
                {
                    Console.WriteLine("Entekhab namotabar.");
                    return;
                }

                var selected = students[stuIndex];

                block.BlockManager = new Masoulblook("Masoul Block", block.BlockName, selected.Daneshjonumber,
                    selected.Otagh, selected.Blook, selected.Khabgah, selected.Tajhizat,
                    selected.Name, selected.Lastname, selected.Nationalnumber, selected.Phonenumber, selected.Adress);
            }

            Console.WriteLine("Name jadid khabgah:");
            block.DormitoryName = Console.ReadLine();

            Console.WriteLine("Etela'at block ba movafaghiat virayesh shod.\n");
        }
        else
        {
            Console.WriteLine("Block peyda nashod.\n");
        }
    }


    public void RemoveBlock()
    {
        Console.WriteLine("Name block ra vared konid:");
        string name = Console.ReadLine();

        Console.WriteLine("Name khabgah marboot ra vared konid:");
        string dormitoryName = Console.ReadLine();

        var block = blocks.FirstOrDefault(b => b.BlockName == name && b.DormitoryName == dormitoryName);
        if (block != null)
        {
            blocks.Remove(block);
            Console.WriteLine("Block ba movafaghiat hazf shod.\n");
        }
        else
        {
            Console.WriteLine("Block peyda nashod.\n");
        }
    }

    public void ShowBlocks()
    {
        Console.WriteLine("List block-ha:");
        foreach (var block in blocks)
        {
            Console.WriteLine($"Block: {block.BlockName} | Floors: {block.NumberOfFloors} | Rooms: {block.NumberOfRooms} | Manager: {block.BlockManager.Name} | Dormitory: {block.DormitoryName}");
        }
        Console.WriteLine();
    }

    public void ShowBlocksByDormitory()
    {
        Console.WriteLine("Name khabgah ra vared konid baraye namayesh block-ha:");
        string dormName = Console.ReadLine();

        var filtered = blocks.Where(b => b.DormitoryName == dormName).ToList();
        if (filtered.Count == 0)
        {
            Console.WriteLine("Hich blocki baraye in khabgah peyda nashod.\n");
        }
        else
        {
            foreach (var block in filtered)
            {
                Console.WriteLine($"Block: {block.BlockName} | Floors: {block.NumberOfFloors} | Rooms: {block.NumberOfRooms} | Manager: {block.BlockManager.Name}");
            }
            Console.WriteLine();
        }
    }

    public List<Blook> GetAllBlocks()
    {
        return blocks;
    }
}
