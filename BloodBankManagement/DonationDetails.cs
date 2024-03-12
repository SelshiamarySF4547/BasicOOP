using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBankManagement
{
    public enum BloodGroup{A_Positive, B_Positive, O_Positive, AB_Positive }

    public class DonationDetails
    {

        //Field
        public static int s_donationID=1000;
        public string DonationID{get;set;}

        //Property
     
        public string DonorID{get;set;}
        public DateTime DonationDate{get;set;}
        public double Weight{get;set;}
        public double BloodPressure{get;set;}
        public double HBCount{get;set;}
         public BloodGroup BloodGroup{get;set;}

        //constructor
        public DonationDetails(string donorid, DateTime donationdate, double weight, double bloodpressure, double hbcount, BloodGroup bloodgroup)
        {
            DonationID="DID"+s_donationID;
            DonorID=donorid;
            DonationDate=DateTime.Now;
            Weight=weight;
            BloodPressure=bloodpressure;
            HBCount=hbcount;
            BloodGroup=bloodgroup;
        }
        
    }
}