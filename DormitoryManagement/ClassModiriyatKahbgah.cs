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
        public void AddKhabgah()
        {
            Console.WriteLine("Name Khabgah Ra Vared Konid: ");
        string name = Console.ReadLine();
        
        Console.WriteLine("Address Khabgah Ra Vared Konid: ");
        string loc = Console.ReadLine();
        
        Console.WriteLine("Zarfiyat Khabgah Ra Vared Konid: ");
        int zarfiyat = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Lotfan Shomare Masoal Khabgah Ra Entekhab Konid: ");
            Classashkhas masol = new Classashkhas();
            masol.ShowMasoulinKhabgah();
        
        int somareMasoulKhabgah = int.Parse(Console.ReadLine());

            Console.WriteLine($"Khabgah {name} Ezafe Shood!  ");
        }
       
    }
}