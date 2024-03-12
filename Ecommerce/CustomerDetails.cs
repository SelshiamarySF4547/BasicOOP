using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce
{
/*a. CustomerName
b.	City
c.	PhoneNumber
d.	MailID
e.	WalletBalance
f.	CustomerID (Auto generated)
*/
    public class CustomerDetails
    {
        public static int s_customerID =1000;
        public string CustomerName{get; set;}
        public string City{get; set;}

        public string MailID{get;set;}
        public int Balance{get;set;}
        public string CustomerID{get;set;}
        public long PhoneNumber{get;set;}



        public CustomerDetails(string name, string city, string mail,int balance,long phonenumber)
        {
            s_customerID++;
            CustomerID="CID" +s_customerID;
            CustomerName=name;
            City=city;
            MailID=mail;
            Balance = balance;
            PhoneNumber=phonenumber;
            
        }
    }
}