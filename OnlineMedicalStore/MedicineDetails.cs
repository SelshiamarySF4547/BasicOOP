using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class MedicineDetails
    {
        //Field
        public static int s_medicineID=2000;

        //Property
        public string MedicineID{get;set;}
        public string MedicineName{get;set;}
        public int AvailableCount{get;set;}
        public double Price{get;set;}
        public DateTime DateOfExpiry{get;set;}

        public MedicineDetails(string medicinename, int availablecount, double price, DateTime dateofexpiry)
        {
            MedicineID="MD"+ ++s_medicineID;
            MedicineName=medicinename;
            AvailableCount=availablecount;
            Price=price;
            DateOfExpiry=dateofexpiry;

        }
        
    }
}