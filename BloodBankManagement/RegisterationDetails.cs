using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBankManagement
{
    
    
    public class RegisterationDetails
    {
        //Field
        public static int s_donorID=1000;

        //Property
        public string DonorID{get;}
        public string Name{get;set;}
        public long Phone{get;set;}
        public string BloodGroup{get;set;}
        public int Age{get;set;}
        public DateTime LastDonationDate {get; set;}


        //Constructor
        public RegisterationDetails(string name,long phonenumber, string bloodgroup, int age, DateTime lastdonationdate)
        {
            DonorID="DID" + ++s_donorID;
            Name=name;
            Phone=phonenumber;
            BloodGroup=bloodgroup;
            Age=age;
            LastDonationDate=lastdonationdate;
        }
    }

}