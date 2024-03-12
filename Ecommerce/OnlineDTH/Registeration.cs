using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDTH
{
    public class Registeration
    {

        //Field
        public static int s_userID=1000;
        private double _walletBalance;

        //Property
        public string UserID{get;set;}
        public string UserName{get;set;}
        public long Phone{get;set;}
        public string MailID{get;set;}
        public double WalletBalance{get{return _walletBalance;}}



        //Constructor

        public Registeration(string name, long phonenumber, string mailid, double walletBalance)
        {
            UserID="UID"+ ++s_userID;
            UserName=name;
            Phone=phonenumber;
            MailID=mailid;
            _walletBalance=walletBalance;
        }
        
        public void WalletRecharge(double rechargeCount)
        {
            _walletBalance +=rechargeCount;
        }


        
    }
}