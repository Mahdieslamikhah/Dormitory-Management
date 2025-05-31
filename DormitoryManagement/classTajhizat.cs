using System;
namespace DormitoryManagement {
class Tajhizat
{
    public string NoeTajhizat { get; set; }
    public int PartNumber { get; set; } // 001-005
    public string ShomareAmval { get; set; }
    public string Status { get; set; } // وضعیت (سالم، معیوب، در حال تعمیر)
    public Otagh OtaghMarbote { get; set; } // اتاق مربوطه
    public Daneshjoo Malek { get; set; } // دانشجو مالک (تجهیزات شخصی)

        public Tajhizat(string noetajhizat,Otagh otaghMarbote, Daneshjoo malek, int partNumber,string status)
        {
            NoeTajhizat = noetajhizat;
            PartNumber = partNumber;
            Status = status;
            Malek = malek;
            OtaghMarbote = otaghMarbote;
            ShomareAmval = SakhtPartNumber(partNumber); // ساخت شماره اموال 

        }






    private string SakhtPartNumber(int PartNumber)
        {
            if (PartNumber < 1 || PartNumber > 5)
            {
                throw new Exception("Part Number Bayad bein 001 ta 005 bashad !");
            }
            string pishVand = PartNumber.ToString("D3"); // سه رقم ثابت که نوع تجهیز رو مشخص میکنه 
            string pasVand = new Random().Next(100000, 999999).ToString(); // تولید رقم تصادفی
            return pishVand + pasVand;
        }

    }
}