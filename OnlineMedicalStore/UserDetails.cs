using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class UserDetails
    {
        //Field
        public static int s_userID = 1000;
        private double _walletbalance;

        //Property
        public double WalletBalance{get{return _walletbalance;}}
        public string UserID { get; set; }

        public string Username { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public long PhoneNumber { get; set; }
        public double Balance { get; set; }


        public UserDetails(string username, int age, string city, long phonenumber, double balance)
        {
            UserID="UID" + ++s_userID;
            Username = username;
            Age = age;
            City = city;
            PhoneNumber = phonenumber;
            Balance = balance;
        }



        public void WalletRecharge(double rechargeCount)
        {
            _walletbalance += rechargeCount;
        }

        public  void DeductBalance(double deductBalance)
        {
            _walletbalance -= deductBalance;
        }
    }

}