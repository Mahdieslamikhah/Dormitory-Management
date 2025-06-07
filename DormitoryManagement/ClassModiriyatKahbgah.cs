using DormitoryManagement;
namespace DormitoryManagement
{
    class ModriyatKhahbgah
    {
        private List<Khabgah> khabgahha;
        private List<Masoulkhabgah> masoalha;
        public ModriyatKhahbgah()
        {
            khabgahha = new List<Khabgah>();
            masoalha = new List<Masoulkhabgah>();
        }
        public void AddKhabgah(Khabgah x)
        {
            khabgahha.Add(x);
            Console.WriteLine($"Khabgah {x.Namekhabgah} Ezafe Shood!  ");
        }
        public void AddMasoulKhabgah(Masoulkhabgah y)
        {
            masoalha.Add(y);
            Console.WriteLine($"{y.Name} Ezafe Shood!  ");
        }
      public void ListMasoulhayekhabgah()
       {
    Console.WriteLine("List masoulin Khabgah: ");
    for (int i = 0; i < masoalha.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {masoalha[i]}");
    }
       }
    }
}