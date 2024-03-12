using System;
using System.Collections.Generic;
namespace Ecommerce;
class Program{
      public static  List<CustomerDetails> customerDetailslist = new List<CustomerDetails>();
    public static void Main(string[] args)
    {
        int choice;
        do
        {
            
            System.Console.WriteLine("\n Menu");
            System.Console.WriteLine("1.Registration");
            System.Console.WriteLine("2.Login");
            System.Console.WriteLine("3.Exit");

            Console.WriteLine("Enter your choice");
             choice =int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                {
                    Registration();
                    break;
                }
                case 2:
                {
                    //Login();
                    break;
                }
                
                default:
                {
                    break;
                }
            }
            
        } while (choice !=3);      
    }
    static void Registration()
    {
        System.Console.WriteLine("Enter Name:");
        string name = Console.ReadLine();

        System.Console.WriteLine("Enter City");
        string city=Console.ReadLine();

        System.Console.WriteLine("Enter Phone Number");
        long phonenumber=int.Parse(Console.ReadLine());

        System.Console.WriteLine("Enter Balance");
        int balance = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Enter Mail");
        string mail = Console.ReadLine();

        CustomerDetails customer = new CustomerDetails(name,city,mail,balance,phonenumber);
        customerDetailslist.Add(customer);
    }
    static void Default()
    {
        CustomerDetails customer1 = new CustomerDetails("Ravi","Chennai","ravi@mail.com",50000,9885858588);
        CustomerDetails customer2 = new CustomerDetails("Baskaran","Chennai","baskaran@mail.com",60000,9888475757);

        customerDetailslist.Add(customer1);
        customerDetailslist.Add(customer2);
    }
}