namespace DormitoryManagement;

public class ModriyatKhahbgah
{
    private List<Khabgah> dormitories = new List<Khabgah>();

    public void AddKhabgah()
    {
        Console.WriteLine(" Name khabgah ra vared konid:");
        string name = Console.ReadLine();

        Console.WriteLine(" Address khabgah ra vared konid:");
        string address = Console.ReadLine();

        Console.WriteLine(" Zarfiyat khabgah ra vared konid:");
        int capacity = int.Parse(Console.ReadLine());

        Console.WriteLine(" Name masoul khabgah ra vared konid:");
        string managerName = Console.ReadLine();

        var manager = new Masoulkhabgah("", "", 0, 0, "", "", "")
        {
            Name = managerName
        };

        dormitories.Add(new Khabgah
        {
            Namekhabgah = name,
            Adress = address,
            Zarfiyatkol = capacity,
            Masoulkhabgah = manager
        });

        Console.WriteLine($" Khabgah {name} ba movafaghiat ezafe shod.\n");
    }

    public void RemoveDormitory()
    {
        Console.WriteLine(" Name khabgah ra baraye hazf vared konid:");
        string name = Console.ReadLine();

        var dorm = dormitories.FirstOrDefault(d => d.Namekhabgah == name);
        if (dorm != null)
        {
            dormitories.Remove(dorm);
            Console.WriteLine(" Khabgah ba movafaghiat hazf shod.\n");
        }
        else
        {
            Console.WriteLine(" Khabgah peyda nashod.\n");
        }
    }

    public void EditDormitory()
    {
        Console.WriteLine(" Name khabgah baraye virayesh ra vared konid:");
        string name = Console.ReadLine();

        var dorm = dormitories.FirstOrDefault(d => d.Namekhabgah == name);
        if (dorm != null)
        {
            Console.WriteLine(" Name jadid:");
            dorm.Namekhabgah = Console.ReadLine();

            Console.WriteLine(" Address jadid:");
            dorm.Adress = Console.ReadLine();

            Console.WriteLine(" Zarfiyat jadid:");
            dorm.Zarfiyatkol = int.Parse(Console.ReadLine());

            Console.WriteLine(" Name masoul jadid:");
            string managerName = Console.ReadLine();
            dorm.Masoulkhabgah.Name = managerName;

            Console.WriteLine(" Etela'at khabgah update shod.\n");
        }
        else
        {
            Console.WriteLine(" Khabgah peyda nashod.\n");
        }
    }

    public void ShowDormitories()
    {
        Console.WriteLine(" List khabgah-ha:");
        foreach (var dorm in dormitories)
        {
            Console.WriteLine($"Name: {dorm.Namekhabgah} | Address: {dorm.Adress} | Zarfiyat: {dorm.Zarfiyatkol} | Masoul: {dorm.Masoulkhabgah?.Name}");
        }
        Console.WriteLine();
        Console.ReadKey();
    }
    public List<Khabgah> GetDormitoryList()
    {
        return dormitories;
    }
}