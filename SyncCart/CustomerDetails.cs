using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCart
{

    public class CustomerDetails
    {
        
        public static int s_customerID =1000;
        private double _walletBalance;  //field    should be created in private

        public string CustomerName{get; set;}
        public string City{get; set;}

        public string MailID{get;set;}
        
        public string CustomerID{get;set;}
        public long PhoneNumber{get;set;}
        public double WalletBalance{get{return _walletBalance; }}  //property

         public CustomerDetails(string name, string city, string mail,double balance,long phonenumber)
        {
            s_customerID++;
            CustomerID="CID" +s_customerID;
            CustomerName=name;
            City=city;
            MailID=mail;
            _walletBalance = balance;
            PhoneNumber=phonenumber;
            
        }

        public void WalletRecharge(double rechargeCount)
        {
            _walletBalance +=rechargeCount;
        }

        public void DeductBalance(double deductBalance){
            _walletBalance -=deductBalance;
        }

    }
}