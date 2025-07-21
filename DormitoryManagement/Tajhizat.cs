using System;
namespace DormitoryManagement {
public class Tajhizat
{
    public string NoeTajhizat { get; set; }
    public int PartNumber { get; set; } 
    public string ShomareAmval { get; set; }
    public string Status { get; set; }
    public Otagh OtaghMarbote { get; set; }
    public Daneshjoo Malek { get; set; }

        public Tajhizat(string noetajhizat,Otagh otaghMarbote, Daneshjoo malek, int partNumber,string status)
        {
            NoeTajhizat = noetajhizat;
            PartNumber = partNumber;
            Status = status;
            Malek = malek;
            OtaghMarbote = otaghMarbote;
            ShomareAmval = SakhtPartNumber(partNumber); 

        }
    private string SakhtPartNumber(int PartNumber)
        {
            if (PartNumber < 1 || PartNumber > 5)
            {
                throw new Exception("Part Number Bayad bein 001 ta 005 bashad !");
            }
            string pishVand = PartNumber.ToString("D3"); 
            string pasVand = new Random().Next(100000, 999999).ToString(); 
            return pishVand + pasVand;
        }

    }
}