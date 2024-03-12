using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCart
{  //Order ID	Customer ID	ProductID	TotalPrice	Purchase Date	Quantity Purchased	Order Status •	OrderID (Auto Increment – OID1001)

    public enum OrderStatus{Default, Ordered, Cancelled}
    public class OrderDetails
    {
        public static int s_orderID = 1000;
        public string CustomerID {get;set;}
        public string ProductID{get;set;}
        public string OrderID {get;set;}
       
        public double TotalPrice{get;set;}
        public DateTime PurchasedDate {get;set;}
        public int Quantity{get;set;}
        public OrderStatus OrderStatus{get;set;}

        public OrderDetails( string customerID, String productID, double totalprice, DateTime purchaseDate, int quantity, OrderStatus orderstatus)
        {
            s_orderID++;
            OrderID = "OID" +s_orderID;
            CustomerID=customerID;
            ProductID=productID;
            TotalPrice = totalprice;
            PurchasedDate=purchaseDate;
            Quantity=quantity;
            OrderStatus=orderstatus;

        }
        


    }
}