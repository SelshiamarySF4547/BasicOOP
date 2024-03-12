using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCart
{
    public class Operations
    {

        static List<CustomerDetails> customerlist = new List<CustomerDetails>();
        static List<OrderDetails> orderlist = new List<OrderDetails>();
        static List<ProductDetails> productlist = new List<ProductDetails>();

        static CustomerDetails currentCustomer;
        public static void AddDefaultDetails()   //method
        {
            //Adding default data of customers
            CustomerDetails customer1 = new CustomerDetails("Ravi", "Chennai", "ravi@mail.com", 50000, 9885858588);
            CustomerDetails customer2 = new CustomerDetails("Baskaran", "Chennai", "baskaran@mail.com", 60000, 9888475757);

            customerlist.Add(customer1);
            customerlist.Add(customer2);

            //Adding default data of order
            OrderDetails order1 = new OrderDetails("CID1001", "PID101", 20000, DateTime.Now, 2, OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails("CID1001", "PID101", 20000, DateTime.Now, 2, OrderStatus.Ordered);

            orderlist.Add(order1);
            orderlist.Add(order2);

            //Adding default data of product
            ProductDetails product1 = new ProductDetails("Mobile (Samsung)", 10, 10000, 3);
            ProductDetails product2 = new ProductDetails("Tablet (Lenovo)", 5, 15000, 2);
            ProductDetails product3 = new ProductDetails("Camara (Sony)", 3, 20000, 4);
            ProductDetails product4 = new ProductDetails("iPhone", 5, 50000, 6);
            ProductDetails product5 = new ProductDetails("Laptop (Lenovo I3)", 3, 40000, 3);
            ProductDetails product6 = new ProductDetails("HeadPhone (Boat)", 5, 1000, 2);
            ProductDetails product7 = new ProductDetails("Speakers (Boat)", 4, 500, 2);

            productlist.Add(product1);
            productlist.Add(product2);
            productlist.Add(product3);
            productlist.Add(product4);
            productlist.Add(product5);
            productlist.Add(product6);
            productlist.Add(product7);


        }
        
        static string line = "---------------------------------------------------------------------------";

        public static void DisplayDefaultDetails()
        {
            System.Console.WriteLine($"{"Customer ID",-9} | {"Customer Name",-11}| {"City",-11} | {"Mobile Number",-10}|{"Balance",-7}| {"Mail",-10}");
            Console.WriteLine(line);
            foreach (CustomerDetails customer in customerlist)
            {
                System.Console.WriteLine($"{customer.CustomerID,-11} | {customer.CustomerName,-13}| {customer.City,-12}|{customer.PhoneNumber,-13}|{customer.WalletRecharge,-8}|{customer.MailID,-10}");
            }
            System.Console.WriteLine(line);
            System.Console.WriteLine(line);

            foreach (OrderDetails order in orderlist)
            {
                System.Console.WriteLine();
            }
            foreach (ProductDetails productDetails in productlist)
            {
                System.Console.WriteLine();
            }
        }
///////////////////////////////////////////////////////////////////////
        public static void MainMenu()
        {
            string option = "yes";
            do
            {
                //Display Main menu
                System.Console.WriteLine("SyncCart");
                System.Console.WriteLine("\n Main Menu :");

                //Ask the user input

                System.Console.WriteLine("1.Customer Registeration");
                System.Console.WriteLine("2.Login");
                System.Console.WriteLine("3.Exit");

                int mainmenuChoice = int.Parse(Console.ReadLine());
                System.Console.WriteLine(mainmenuChoice);

                switch (mainmenuChoice)
                {
                    case 1:
                        {
                            System.Console.WriteLine("you have selected Customer registration");
                            CustomerRegisteration();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("you have selected customer login");
                            Login();
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("you have selected exit");
                            option = "no";
                            break;
                        }

                    default:
                        {
                            System.Console.WriteLine("Invalid option. Enter a valid option");

                            break;
                        }
                }
            } while (option == "yes");


        }

        public static void CustomerRegisteration()
        {
            System.Console.WriteLine("Customer registeration method called: ");
            //get details from customer/user
            System.Console.WriteLine("Enter your Name: ");
            string name = Console.ReadLine();

            System.Console.WriteLine("Enter your City: ");
            string city = Console.ReadLine();

            System.Console.WriteLine("Enter your Phone Number: ");
            long phonenumber = long.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter your Mail ID: ");
            string mailid = Console.ReadLine();

            System.Console.WriteLine("Enter your Wallet Balance: ");
            double walletbalance = double.Parse(Console.ReadLine());

            //create the object for the customer details class
            CustomerDetails customer = new CustomerDetails(name, city, mailid, walletbalance, phonenumber);

            //add the customer details object to the customer details list
            customerlist.Add(customer);

            //display customer ID to the user
            System.Console.WriteLine("Registeration is successful");
            System.Console.WriteLine($"Your customer ID is : {customer.CustomerID}");

        }
        public static void Login()
        {
            System.Console.WriteLine("Login method called: ");
            //ask the customer ID
            System.Console.WriteLine("Enter your Customer ID");
            string searchID = Console.ReadLine().ToUpper();

            bool flag = true;

            //traverse the customer details list
            foreach (CustomerDetails customer in customerlist)
            {
                //Check the customer ID is in the list
                if (searchID.Equals(customer.CustomerID))
                {
                    //If customer ID is valid, Show login successful and navigate to submenu
                    flag = false;
                    System.Console.WriteLine("Login Succeffully!");
                    currentCustomer = customer;      // assign this customer as current custome after login
                    Submenu();
                    break;
                }
            }
            //else , show invalid customer ID
            if (flag)
            {
                System.Console.WriteLine("Invalid Customer ID. Please enter a valid customer ID)");
            }
        }
        public static void Submenu()
        {
            System.Console.WriteLine("Sub-menu called");
            string option = "yes";
            do
            {
                System.Console.WriteLine("/n Sub Menu :");

                //Ask the user input

                System.Console.WriteLine("1.Purchase");
                System.Console.WriteLine("2.Order history");
                System.Console.WriteLine("3.Cancel Order");
                System.Console.WriteLine("4.Wallet Balance");
                System.Console.WriteLine("5.Wallet Recharge");
                System.Console.WriteLine("6.Exit");

                int submenuChoice = int.Parse(Console.ReadLine());
                System.Console.WriteLine(submenuChoice);

                switch (submenuChoice)
                {
                    case 1:
                        {
                            System.Console.WriteLine("you have selected Customer Purchase");
                            Purchase();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("you have selected customer Order history");
                            OrderHistory();
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("you have selected Cancel Order");
                            CancelOrder();
                            break;
                        }
                    case 4:
                        {
                            System.Console.WriteLine("you have selected Wallet Balance");
                            WalletBalance();
                            break;
                        }
                    case 5:
                        {
                            System.Console.WriteLine("you have selected Wallet Recharge");
                            WalletRecharge();
                            break;
                        }
                    case 6:
                        {
                            System.Console.WriteLine("you have selected Exit");
                            Exit();
                            option = "no";
                            break;
                        }

                    default:
                        {
                            System.Console.WriteLine("Invalid option. Enter a valid option");
                            break;
                        }
                }
            } while (option == "yes");
        }
        public static void Purchase()
        {
            System.Console.WriteLine("Purchase method has been called");

            //Display the product details
            System.Console.WriteLine($"{"Customer ID",-9} | {"Customer Name",-11}| {"City",-11} | {"Mobile Number",-10}|{"Balance",-7}| {"Mail",-10}");
            Console.WriteLine(line);
            foreach (CustomerDetails customer in customerlist)
            {
                System.Console.WriteLine($"{customer.CustomerID,-11} | {customer.CustomerName,-13}| {customer.City,-12}|{customer.PhoneNumber,-13}|{customer.WalletRecharge,-8}|{customer.MailID,-10}");
            }
            System.Console.WriteLine(line);

            //ask the customer to enter the product ID

            System.Console.WriteLine("Enter the Product ID");
            string searchProductid = Console.ReadLine().ToUpper();

            //check the product ID is valid or not
            bool isValidProductID = true;
            foreach (ProductDetails product in productlist)
            {
                if (searchProductid.Equals(product.ProductID))
                {
                    //if valid , ask the minimum order quantity of the product
                    System.Console.WriteLine("Enter product count to be ordered:");
                    int quantity = int.Parse(Console.ReadLine());
                    isValidProductID = false;

                    //check the required quantity is available in the stock
                    if (quantity <= product.Stock && quantity > 0)                //we should not enter -ve quantity and the quantity should be within the stock limit
                    {
                        System.Console.WriteLine("Product quantity is available");

                        //Calculate total amount
                        double totalamount = (quantity * product.PricePerQuantity) + 50;

                        //check the current loggin user's wallet balance is greater than or equal to total price
                        if (totalamount <= currentCustomer.WalletBalance)
                        {
                            //if yes, deduct the total prize from the current customer's wallet balance
                            currentCustomer.DeductBalance(totalamount);
                            System.Console.WriteLine($"totalamount is: {totalamount} and available balance is: {currentCustomer.WalletRecharge}");


                            //reduce the quantity from the product stock 
                            product.Stock -= quantity;

                            //create the object for order details class
                            OrderDetails orderdetails = new OrderDetails(currentCustomer.CustomerID, product.ProductID, totalamount, DateTime.Now, quantity, OrderStatus.Ordered);
                            orderlist.Add(orderdetails);

                            //display  the order ID to the customer
                            System.Console.WriteLine($"Order Placed Successfully. Your Order ID is: {orderdetails.OrderID}");

                            //Calculate the shipping duration
                            DateTime deliverydate = DateTime.Now.AddDays(product.Duration);

                            //display the delivery date to the customer
                            System.Console.WriteLine($"Your Delivery Date is: {deliverydate}");

                        }
                        else
                        {
                            //else, show insufficient balance
                            System.Console.WriteLine("Insufficient Wallent Balance. Please recharge your wallet and do purchase again");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine($"Required count is not available.Current available is , {product.Stock}");
                    }
                }
            }
            //if invalid product product ID , show invalid product ID
            if (isValidProductID)
            {
                System.Console.WriteLine("Invalid Product ID.");
            }
        }
        public static void OrderHistory()
        {
            System.Console.WriteLine("Order History method has been called");

            //traverse the order detailslist
            bool flag = true;
            foreach (OrderDetails orderDetails in orderlist)
            {
                //check customer ID in the orderdetails list  == current logged in customer's customerID
                if (orderDetails.CustomerID.Equals(currentCustomer.CustomerID))
                {
                    //If exsist , show the order details of the current customer
                    flag = false;
                    System.Console.WriteLine($"Order ID is: {orderDetails.CustomerID} \n Product ID is: {orderDetails.ProductID} \n Total Price is: {orderDetails.TotalPrice} \n Purchased Date is: {orderDetails.PurchasedDate}  \n Quantity : {orderDetails.Quantity} \n Order Status is: {orderDetails.OrderStatus}");
                }
            }
            //If not exist , show no orders found
            if (flag)
            {
                System.Console.WriteLine("No Orders found");
            }
        }
        public static void CancelOrder()
        {
            System.Console.WriteLine("Cancel order has been called");

            //traverse the orderlist 
            bool flag = true;
            foreach (OrderDetails orderDetails in orderlist)
            {
                //check customer ID in the orderdetails list  == current logged in customer's customerID  && check whether the order is current's order and the order status is ordered
                if (orderDetails.CustomerID.Equals(currentCustomer.CustomerID) && orderDetails.OrderStatus.Equals(OrderStatus.Ordered))
                {
                    //If exsist , show the order details of the current customer
                    flag = false;
                    System.Console.WriteLine($"Order ID is: {orderDetails.CustomerID} \n Product ID is: {orderDetails.ProductID} \n Total Price is: {orderDetails.TotalPrice} \n Purchased Date is: {orderDetails.PurchasedDate}  \n Quantity : {orderDetails.Quantity} \n Order Status is: {orderDetails.OrderStatus}");
                }
            }

            if (!flag)
            {
                //if order exsist, ask orderId to be cancelled 
                System.Console.WriteLine("Enter the orderID to be cancelled:");
                string cancelorderid = Console.ReadLine().ToUpper();

              

                foreach (OrderDetails orderDetails in orderlist)
                {
                      //check whether the orderID is valid by traversing the orderlist

                    //check customer ID in the orderdetails list  == current logged in customer's customerID  && check whether the order is current's order and the order status is ordered
                    if (orderDetails.CustomerID.Equals(currentCustomer.CustomerID) && orderDetails.OrderStatus.Equals(OrderStatus.Ordered) && orderDetails.OrderID.Equals(cancelorderid))
                    {
                          //if orderID is valid, traverse the productdetailslist and check fo the productID = productID in the order

                        foreach (ProductDetails product in productlist)
                        {
                            if(orderDetails.ProductID.Equals(orderDetails.OrderID))
                            {
                                //if product exsist , increase the product stock in the product details  
                                product.Stock += orderDetails.Quantity;

                                 //then refund the total amount to the customer's wallet
                                 currentCustomer.WalletRecharge(orderDetails.TotalPrice-50);

                                  //change the order status as Cancelled
                                 orderDetails.OrderStatus=OrderStatus.Cancelled;

                                  //display the order cancelled message

                                System.Console.WriteLine($"orderID :{orderDetails.OrderID} cancelled successfully");
                         }
                        }
                    }
                }
            }


            //If not exist , show no orders found
            if (flag)
            {
                System.Console.WriteLine("No Orders found");
            }
            //if not show the no orders found message

        }
        public static void WalletBalance()
        {
            System.Console.WriteLine("Wallet balance method has been called");
            //display the wallet balance of the current logged in customer
            System.Console.WriteLine($"your wallet balance is {currentCustomer.WalletRecharge}");
        }
        public static void WalletRecharge()
        {
            System.Console.WriteLine("Wallet Recharge method has been called");
            //ask the user he wish to recharge or not
            System.Console.WriteLine("Do you want to recharge?");
            string askrecharge = Console.ReadLine().ToLower();

            //check whether he wished to recharged

            if (askrecharge == "yes")
            {
                //if user wish to recharge ask the recharge amount
                System.Console.WriteLine("Enter the recharge amount.");
                double rechargeamount = double.Parse(Console.ReadLine());

                //pass the recharge amount to the currentCustomer's wallet recharge method()
                if (rechargeamount > 0)
                {
                    currentCustomer.WalletRecharge(rechargeamount);
                   
                    WalletBalance();
                }
                else
                {
                    System.Console.WriteLine("Invalid Amount");
                }
                //display the updated wallet balance to the customer
            }


        }
        public static void Exit()
        {
            System.Console.WriteLine("Exit method has been called");
        }
    }
}
