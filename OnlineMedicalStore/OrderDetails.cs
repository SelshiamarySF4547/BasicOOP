using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{

    public enum OrderStatus { Purchased, Cancelled }
    public class OrderDetails
    {
        public static int s_orderid = 3000;
        public string OrderID { get; set; }

        public string UserID{get;set;}
        public string MedicineID { get; set; }
        public int MedicineCount { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }

        public OrderStatus OrderStatus{get;set;}


        public OrderDetails(string userid,string medicineid, int medicinecount, double totalprice, DateTime orderdate, OrderStatus orderstatus)
        {
            OrderID="OID" + ++ s_orderid;
            UserID=userid; 
            MedicineID=medicineid;
            MedicineCount=medicinecount;
            TotalPrice=totalprice;
            OrderDate=orderdate;
            OrderStatus=orderstatus;
        }

    }
}