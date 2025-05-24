// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
class person
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public long PersonalID { get; set; }
    public string Phonenumber { get; set; }
    public string Adress { get; set; }
    public person(string name, string lastname, long personalID, string phonenumber, string adress)
    {
        Name = name;
        Lastname = lastname;
        PersonalID = personalID;
        Phonenumber = phonenumber;
        Adress = adress;
    }
}