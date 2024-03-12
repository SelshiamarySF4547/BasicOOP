using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnlineDTH
{

    public class Operations
    {
        static List<Registeration> registerationlist = new List<Registeration>();
        static List<PackDetails> packDetailslist = new List<PackDetails>();
        static List<RechargeHistory> rechargehistorylist = new List<RechargeHistory>();

        static Registeration currentuser;
        static string line = "--------------------------------------------------------------------------";

        public static void DefaultDetails()
        {
            Registeration register1 = new Registeration("John", 9746646466, "john@gmail.com", 500);
            Registeration register2 = new Registeration("Merlin", 9782136543, "merlin@gmail.com", 150);
            registerationlist.Add(register1);
            registerationlist.Add(register2);

            PackDetails pack1 = new PackDetails("RC150", "Pack1", 150, 28, 50);
            PackDetails pack2 = new PackDetails("RC300", "Pack2", 300, 56, 75);
            PackDetails pack3 = new PackDetails("RC500", "Pack3", 500, 28, 200);
            PackDetails pack4 = new PackDetails("RC1500", "Pack4", 1500, 365, 200);
            packDetailslist.Add(pack1);
            packDetailslist.Add(pack2);
            packDetailslist.Add(pack3);
            packDetailslist.Add(pack4);

            RechargeHistory history1 = new RechargeHistory("UID1001", "RC150", new DateTime(30 / 11 / 2011), 150, new DateTime(27 / 12 / 2021), 50);
            RechargeHistory history2 = new RechargeHistory("UID1002", "RC150", new DateTime(01 / 01 / 2022), 150, new DateTime(28 / 01 / 2022), 50);
            rechargehistorylist.Add(history1);
            rechargehistorylist.Add(history2);
        }

        public static void MainMenu()
        {
            string choice1 = "yes";
            do
            {
                System.Console.WriteLine("Main-Menu");
                System.Console.WriteLine("1.User Registeration");
                System.Console.WriteLine("2.User Login");
                System.Console.WriteLine("3.Exit");

                System.Console.WriteLine("Enter your Main-Menu choice: ");
                int mainmenuchoice = int.Parse(Console.ReadLine());

                switch (mainmenuchoice)
                {
                    case 1:
                        {
                            Registeration();
                            break;
                        }
                    case 2:
                        {
                            Login();
                            break;
                        }
                    case 3:
                        {
                            Exit();
                            choice1 = "no";
                            break;
                        }

                    default:
                        {
                            System.Console.WriteLine("Invalid MainMenu choice. Please Enter Valid choice: ");
                            break;
                        }
                }


            } while (choice1 == "yes");
        }


        public static void Registeration()
        {
            System.Console.WriteLine(line);

            System.Console.WriteLine("Enter Your Name: ");
            string name = Console.ReadLine();

            System.Console.WriteLine("Enter Mobile Number: ");
            long phonenumber = long.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter MailID: ");
            string mailid = Console.ReadLine();

            System.Console.WriteLine("Enter Wallet Balance: ");
            double walletbalance = double.Parse(Console.ReadLine());

            Registeration register = new Registeration(name, phonenumber, mailid, walletbalance);
            registerationlist.Add(register);

            System.Console.WriteLine(line);

            System.Console.WriteLine($"Your Registeration has been successful. Your User ID is, {register.UserID}");

        }
        public static void Login()
        {
            //Ask for the “User ID” of the user.
            System.Console.WriteLine("Enter User ID: ");
            string searchid = Console.ReadLine().ToUpper();


            bool flag = true;
            // Check the “User ID” in the user list.
            foreach (Registeration register in registerationlist)
            {


                if (searchid == register.UserID)
                {
                    flag = false;
                    System.Console.WriteLine("Login Successful!");
                    currentuser = register;
                    //If User ID exist show the Sub- menu 
                    SubMenu();
                    break;
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid User ID. Please enter Valid User ID.");
            }
        }
        public static void Exit()
        {
            
        }

        public static void SubMenu()
        {
            string choice = "yes";
            do
            {
                System.Console.WriteLine(line);

                System.Console.WriteLine("SUB-MENU");
                System.Console.WriteLine("1.Current Pack");
                System.Console.WriteLine("2.Pack Recharge");
                System.Console.WriteLine("3.Wallet Recharge");
                System.Console.WriteLine("4.View Pack Recharge History");
                System.Console.WriteLine("5.Show Wallet balance");
                System.Console.WriteLine("6.Exit");

                System.Console.WriteLine(line);
                int submenuchoice = int.Parse(Console.ReadLine());

                switch (submenuchoice)
                {
                    case 1:
                        {
                            CurrentPack();
                            break;
                        }
                    case 2:
                        {
                            PackRecharge();
                            break;
                        }
                    case 3:
                        {
                            WalletRecharge();
                            break;
                        }
                    case 4:
                        {
                            ViewPackRechargeHistory();
                            break;
                        }
                    case 5:
                        {
                            ShowWalletBalance();
                            break;
                        }
                    case 6:
                        {
                            // Exit();
                            choice = "no";
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("Invalid Sub-Menu Choice.");
                            break;
                        }
                }


            } while (choice == "yes");
        }
        public static void CurrentPack()
        {
            foreach (Registeration registeritem in registerationlist)
            {
                foreach (RechargeHistory rechargeitem in rechargehistorylist)
                {
                    System.Console.WriteLine($"UserId: {rechargeitem.UserID},Pack ID: {rechargeitem.PackID},Recharge Amount: {rechargeitem.RechargeAmount},Recharge Validity: {rechargeitem.ValidTill},Number od Channels: {rechargeitem.NumberOfChannels}");
                    break;
                }
                break;
            }

        }
        public static void PackRecharge()
        {
            string choice = "yes";
            do
            {
                //1.	List the available pack details and ask the user to choose a pack and recharge.
                foreach (PackDetails item in packDetailslist)
                {
                    System.Console.WriteLine($"Available Pack Details are: 1.Pack ID: {item.PackID} 2.PackName: {item.PackName} 3.Price: {item.Price} 4.Validity: {item.Validity} 5.NumberOfChannels: {item.NoOfChannels}");
                }
                foreach (PackDetails packdetails in packDetailslist)
                {
                    foreach (Registeration register in registerationlist)
                    {
                        bool temp = true;
                        foreach (RechargeHistory recharge in rechargehistorylist)
                        {
                            System.Console.WriteLine("Enter your PackID:");
                            string searchid = Console.ReadLine().ToUpper();
                            bool flag = true;
                            if (packdetails.PackID.Equals(searchid))
                            {

                                //2.Based on the pack choose, check the wallet balance.
                                if (register.WalletBalance >= packdetails.Price)
                                {
                                    //4.If the user has sufficient balance, then permit and do recharge.
                                    System.Console.WriteLine("You have successfully recharged this Pack.");
                                    System.Console.WriteLine($"Your RechargeID: {recharge.RechargeID} Recharge Date: {recharge.RechargeDate} User ID: {recharge.UserID} Recharge Amount: {recharge.RechargeAmount} Recharge Amount Valid Till: {recharge.ValidTill} NumberOfChannels: {recharge.NumberOfChannels}");
                                    break;
                                }
                                flag = false;

                            }
                            temp = false;
                            if (flag)
                            {
                                //3.	If insufficient balance in wallet, ask them to recharge his wallet.
                                System.Console.WriteLine("Insufficient Balance. Please Recharge your Wallet.");
                            }
                            break;

                        }
                        if (temp)
                        {
                            System.Console.WriteLine("PackID does not match. Please enter valid packId.");
                        }
                    }
                }
                SubMenu();

                choice = "no";

            } while (choice == "yes");
        }
        public static void WalletRecharge()
        {
            //Ask for the amount to be recharged from the user and update the wallet balance.

            System.Console.WriteLine("Enter amount to be recharged.");
            int amount = int.Parse(Console.ReadLine());   //200
            if(amount>0)
            {
              //  currentuser.WalletRecharge(amount);
                    currentuser.WalletRecharge(amount);
                    System.Console.WriteLine($"current wallet balance of this user is: {currentuser.WalletBalance}");
            }

            /*foreach (Registeration item in registerationlist)
            {
                if (item.UserID.Equals(currentuser.UserID))
                {
                    //currentuser.WalletBalance += amount;
                 
                    System.Console.WriteLine($"current wallet balance of this user is: {currentuser.WalletBalance}");
                    break;
                }

            }*/
            
        }
        public static void ViewPackRechargeHistory()
        {
            foreach (RechargeHistory rechargeitem in rechargehistorylist)
            {
                if (rechargeitem.UserID.Equals(currentuser.UserID))
                {
                    System.Console.WriteLine($"UserId: {rechargeitem.UserID},Pack ID: {rechargeitem.PackID},Recharge Amount: {rechargeitem.RechargeAmount},Recharge Validity: {rechargeitem.ValidTill},Number od Channels: {rechargeitem.NumberOfChannels}");
                    break;
                }

            }
        }
        public static void ShowWalletBalance()
        {
            foreach (Registeration register in registerationlist)
            {
                if(register.UserID.Equals(currentuser.UserID))
                {
                    System.Console.WriteLine($"WalletBalance of Current User is: {currentuser.WalletBalance}");
                }
            }
        }
    }
}