using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Reflection.Metadata;

namespace OnlineMedicalStore
{


    public class Operations
    {
        static List<UserDetails> userdetailslist = new List<UserDetails>();
        static List<MedicineDetails> medicinedetailslist = new List<MedicineDetails>();
        static List<OrderDetails> orderdetailslist = new List<OrderDetails>();
        static UserDetails currentuser;
        static MedicineDetails currentmedicineid;

        /*a.	Username
        b.	Age
        c.	City
        d.	PhoneNumber
        e.	Balance
        */
        public static void MainMenu()
        {
            string choice = "yes";
            do
            {
                System.Console.WriteLine("Main-Menu");
                System.Console.WriteLine("1.UserRegisteration");
                System.Console.WriteLine("2.UserLogin");
                System.Console.WriteLine("3.Exit");

                System.Console.WriteLine("Enter Your Choice:");
                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        {
                            UserRegisteration();  //done
                            break;
                        }
                    case 2:
                        {
                            UserLogin();
                            break;
                        }
                    case 3:
                        {
                            choice = "no";
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("Invalid input. Enter valid input.");
                            break;
                        }
                }
            } while (choice == "yes");

        }
        public static void UserRegisteration()
        {
            // 1.	Get the below details from the user to create a new user account.

            System.Console.WriteLine("Enter your Name: ");
            string username = Console.ReadLine();

            System.Console.WriteLine("Enter your Age: ");
            int age = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter your City: ");
            string city = Console.ReadLine();

            System.Console.WriteLine("Enter PhoneNumber: ");
            long phonenumber = long.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter your Balance: ");
            double balance = double.Parse(Console.ReadLine());

            UserDetails user = new UserDetails(username, age, city, phonenumber, balance);
            userdetailslist.Add(user);

            //  foreach (UserDetails item in userdetailslist)
            //  {
            System.Console.WriteLine($"Successfully Registered. Your ID is {user.UserID}");
            //  }


        }
        public static void UserLogin()
        {
            System.Console.WriteLine("Enter User ID: ");
            string searchuserid = Console.ReadLine().ToUpper();

            string choice = "yes";
            do
            {
                //   bool temp = true; /////
                //1.	Ask for the “User ID” of the user. 
                bool flag = true;
                foreach (UserDetails user in userdetailslist)
                {


                    //Check the “User ID” in the user list.
                    if (searchuserid.Equals(user.UserID))
                    {

                        currentuser = user;
                        System.Console.WriteLine("Login Successfully!");


                        //3.	If “User ID” exists, then show the below sub menu 
                        System.Console.WriteLine("Sub-Menu");
                        System.Console.WriteLine("a.Show medicine list");
                        System.Console.WriteLine("b.Purchase medicine");
                        System.Console.WriteLine("c.Cancel purchase");
                        System.Console.WriteLine("d.Show purchase history");
                        System.Console.WriteLine("e.Recharge");
                        System.Console.WriteLine("f.Show WalletBalance");
                        System.Console.WriteLine("g.Exit");

                        System.Console.WriteLine("Enter Your Choice:");
                        string input = Console.ReadLine();
                        switch (input)
                        {
                            case "a":
                                {
                                    ShowMedicineList();
                                    break;
                                }
                            case "b":
                                {
                                    PurchaseMedicine();
                                    break;
                                }
                            case "c":
                                {
                                    CancelPurchase();
                                    break;
                                }
                            case "d":
                                {
                                    ShowPurchaseHistory();
                                    break;
                                }
                            case "e":
                                {
                                    Recharge();
                                    break;
                                }
                            case "f":
                                {
                                    ShowWalletBalance();
                                    break;
                                }
                            case "g":
                                {
                                    choice = "no";
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }
                        flag = false;
                        break;

                    }
                    //  temp = false;  /////
                }
                if (flag)
                {
                    //2.	If the user ID does not exist means, show “Invalid User ID. Please enter a valid one”.
                    System.Console.WriteLine("Invalid User ID. Please enter a valid one");
                }
            } while (choice == "yes");
        }

        public static void ShowMedicineList()
        {
            //1.	Show the list of available medicine details in the store by traversing the medicine details list 
            foreach (MedicineDetails medicinedetails in medicinedetailslist)
            {
                System.Console.WriteLine($"MedicineID: {medicinedetails.MedicineID} MedicineName: {medicinedetails.MedicineName} AvailableCount: {medicinedetails.AvailableCount} Price: {medicinedetails.Price} Date of Expiry: {medicinedetails.DateOfExpiry}");
            }
        }
        public static void PurchaseMedicine()
        {
            //1.	Show the List of medicine details by traversing the medicine details list.
            ShowMedicineList();

            //2.	Ask the user to select the medicine using MedicineID.
            System.Console.WriteLine("Select the Medicine with MedicineID");
            string searchmedicineid = Console.ReadLine().ToUpper();

            //3.	Ask the number of counts of that medicine he wants to buy.

            System.Console.WriteLine("Enter Number of Count of medicine you want to buy");
            int searchmedicinecount = int.Parse(Console.ReadLine().ToUpper());

            bool flag = true;

            foreach (MedicineDetails medicinedetais in medicinedetailslist)
            {
                //4.	Check the Medicine list whether the MedicineID was available. If it is available, then 

                if (searchmedicineid.Equals(medicinedetais.MedicineID) && searchmedicinecount <= medicinedetais.AvailableCount)
                {
                    //b.Check the medicine was not expired. If it is expired or not available, then show the user “Medicine is not available”.

                    if (medicinedetais.DateOfExpiry < DateTime.Now)
                    {
                        //then check User has enough balance to purchase that medicine. 
                        foreach (UserDetails userdetails in userdetailslist)
                        {
                            if (userdetails.Balance > medicinedetais.Price)
                            {
                                //5.Reduce the number of AvailableCount of that medicine in MedicineDetails. 
                                medicinedetais.AvailableCount -= searchmedicinecount;
                                System.Console.WriteLine($"Availble count after purchasing is:{medicinedetais.AvailableCount}");

                                //6.	Deduct the total amount from user’s balance amount.

                                userdetails.Balance -= medicinedetais.Price;
                                System.Console.WriteLine($"Available User balance after purchasing: {userdetails.Balance}");


                                //7.If all the conditions specified in step 4 are true then calculate the total amount of purchased medicines,
                                // OrderDate is Now, Put OrderStatus as “Purchased” and 
                                //create object for OrderDetails class and add it to the list. 

                                medicinedetais.Price *= searchmedicinecount;
                                System.Console.WriteLine($"Total amount of the purchased medicine: {medicinedetais.Price}");
                                OrderDetails order = new OrderDetails(userdetails.UserID, medicinedetais.MedicineID, searchmedicinecount, medicinedetais.Price, DateTime.Now, OrderStatus.Purchased);
                                orderdetailslist.Add(order);

                                //8.	Finally show the message “Medicine was purchased successfully”.
                                System.Console.WriteLine("Medicine was purchased successfully");


                                break;
                            }
                        }
                    }
                    flag = false;
                }

            }
            if (flag)
            {
                //b.If it is expired or not available, then show the user “Medicine is not available”.
                System.Console.WriteLine("Medicine is not available");
            }
        }
        public static void CancelPurchase()
        {
            //1.	Show the order details of the currently logged in user whose order status is “Purchased”.
            foreach (OrderDetails orderdetails in orderdetailslist)
            {
                if (orderdetails.UserID.Equals(currentuser.UserID) && orderdetails.OrderStatus == OrderStatus.Purchased)
                {
                    System.Console.WriteLine($"Order Id: {orderdetails.OrderID} UserID: {currentuser.UserID} Medicine ID: {orderdetails.MedicineID} Medicine Count: {orderdetails.MedicineCount} Total Price: {orderdetails.TotalPrice} DateofPurchase: {DateTime.Now} OrderStatus: {orderdetails.OrderStatus}");
                }
            }
            //2.	Get the OrderID information from the user and check the OrderID present in the list and check its OrderStatus is Purchased.
            System.Console.WriteLine("Enter Order ID");
            string searchorderid = Console.ReadLine();
            foreach (OrderDetails orderdetails in orderdetailslist)
            {
                foreach (UserDetails user in userdetailslist)
                {
                    if (searchorderid.Equals(orderdetails.OrderID) && orderdetails.OrderStatus == OrderStatus.Purchased)
                    {
                        //If the OrderID matches increase the count of that Medicine in the medicine details, Return the amount to the user.  
                        orderdetails.MedicineCount += orderdetails.MedicineCount;
                        System.Console.WriteLine($"medicine count: {orderdetails.MedicineCount}");

                        user.Balance += orderdetails.TotalPrice;
                        System.Console.WriteLine($"user balance: {user.Balance}");

                        //3.	
                        //Change the Status of the order to “Cancelled”.
                        orderdetails.OrderStatus = OrderStatus.Cancelled;
                        //4.	Show the user that the “OrderID XXX was cancelled successfully”. 

                        System.Console.WriteLine($"{orderdetails.OrderID},was cancelled successfully");
                    }
                }

            }
        }

        public static void ShowPurchaseHistory()
        {
           foreach (OrderDetails orderdetails in orderdetailslist)
            {
                if (orderdetails.UserID.Equals(currentuser.UserID) && orderdetails.OrderStatus == OrderStatus.Purchased)
                {
                    System.Console.WriteLine($"Order Id: {orderdetails.OrderID} UserID: {currentuser.UserID} Medicine ID: {orderdetails.MedicineID} Medicine Count: {orderdetails.MedicineCount} Total Price: {orderdetails.TotalPrice} DateofPurchase: {DateTime.Now} OrderStatus: {orderdetails.OrderStatus}");
                }
            }
        }
        public static void Recharge()
        {
            //Get the amount to be recharged from the current logged in user and update the balance information on his property.

            System.Console.WriteLine("Enter amount to be recharged.");
            double amount=double.Parse(Console.ReadLine());

            if(amount>0)
            {
                currentuser.DeductBalance(amount);
                ShowWalletBalance();

            }
            else
            {
                System.Console.WriteLine("Invalid Recharge Amount.");
            }
        }
        public static void ShowWalletBalance()
        {
            System.Console.WriteLine($"Your Wallet Balance: {currentuser.WalletRecharge}");
        }
        public static void Exit()
        {

        }


        public static void AddDefaultDetails()
        {
            UserDetails user1 = new UserDetails("Ravi", 33, "Theni", 9877774440, 400);
            UserDetails user2 = new UserDetails("Baskaran", 33, "Chennai", 8847757470, 500);
            userdetailslist.Add(user1);
            userdetailslist.Add(user2);

            MedicineDetails medicine1 = new MedicineDetails("Paracitamol", 40, 5, new DateTime(30 / 12 / 2023));
            MedicineDetails medicine2 = new MedicineDetails("Calpol", 10, 5, new DateTime(30 / 11 / 2023));
            MedicineDetails medicine3 = new MedicineDetails("Gelucil", 3, 40, new DateTime(30 / 04 / 2024));
            MedicineDetails medicine4 = new MedicineDetails("Metrogel", 5, 50, new DateTime(30 / 12 / 2024));
            MedicineDetails medicine5 = new MedicineDetails("Povidin Iodin", 10, 50, new DateTime(30 / 10 / 2026));
            medicinedetailslist.Add(medicine1);
            medicinedetailslist.Add(medicine2);
            medicinedetailslist.Add(medicine3);
            medicinedetailslist.Add(medicine4);
            medicinedetailslist.Add(medicine5);


            OrderDetails order1 = new OrderDetails("UID1001", "MD2001", 3, 15, new DateTime(13 / 11 / 2023), OrderStatus.Purchased);
            OrderDetails order2 = new OrderDetails("UID1001", "MD2002", 2, 10, new DateTime(13 / 11 / 2023), OrderStatus.Cancelled);
            OrderDetails order3 = new OrderDetails("UID1001", "MD2004", 2, 100, new DateTime(13 / 11 / 2023), OrderStatus.Purchased);
            OrderDetails order4 = new OrderDetails("UID1002", "MD2003", 3, 120, new DateTime(15 / 01 / 2024), OrderStatus.Cancelled);
            OrderDetails order5 = new OrderDetails("UID1002", "MD2005", 5, 250, new DateTime(15 / 01 / 2024), OrderStatus.Purchased);
            OrderDetails order6 = new OrderDetails("UID1002", "MD2002", 3, 15, new DateTime(15 / 01 / 2024), OrderStatus.Purchased);
            orderdetailslist.Add(order1);
            orderdetailslist.Add(order2);
            orderdetailslist.Add(order3);
            orderdetailslist.Add(order4);
            orderdetailslist.Add(order5);
            orderdetailslist.Add(order6);
        }
    }
}