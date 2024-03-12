using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCart
{
    public class ProductDetails
    {
        public static int s_productID= 100;
        public string ProductID ="PID"+s_productID;
        public string ProductName{get;set;}
        public int Stock{get;set;}

        public double PricePerQuantity{get;set;}
        public int Duration{get;set;}

        public ProductDetails(string productname, int stock, double priceperquantity,int duration)
        {
            s_productID++;
            ProductID = "PID" + s_productID;
            ProductName = productname;
            Stock=stock;
            PricePerQuantity = priceperquantity;
            Duration=duration;
        }


    }
}