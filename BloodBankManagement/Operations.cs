using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBankManagement
{
    public class Operations
    {
        static List<RegisterationDetails> registerlist = new List<RegisterationDetails>();
        static List<DonationDetails> donationDetailslist = new List<DonationDetails>();
        static RegisterationDetails currentuser;

        static string line = "----------------------------------------------------------------------------------------";
        public static void MainMenu()
        {
            string choice = "yes";
            do
            {
                //dispalay main menu choice
                System.Console.WriteLine("\n MAIN-MENU");
                System.Console.WriteLine("1.User Registeration");
                System.Console.WriteLine("2.User Login");
                System.Console.WriteLine("3.Fetch Donor Details");
                System.Console.WriteLine("4.Exit");

                //ask the user to select the mainmenu choice

                System.Console.WriteLine("Enter your choice: ");
                int mainmenuchoice = int.Parse(Console.ReadLine());

                switch (mainmenuchoice)
                {
                    case 1:
                        {
                            //if user select 1 case 1 Registeration method is called
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
                            FetchDonorDetails();
                            break;
                        }
                    case 4:
                        {
                            Exit();
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("Invalid Main-menu choice. Please Enter the valid choice.");
                            break;
                        }
                }
            } while (choice == "yes");


        }
        /*a.	Donor Name
        b.	Mobile Number
        c.	Blood Group
        d.	Age
        e.	Last Donation
        */
        public static void Registeration()
        {


            //Ask the user to give details

            System.Console.WriteLine("Registeration method has been called!!!!");
            System.Console.WriteLine(line);

            System.Console.WriteLine("Enter Donor Name: ");
            string name = Console.ReadLine();

            System.Console.WriteLine("Enter Phone Number: ");
            long phonenumber = long.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter Donor Blood Group: ");
            string bloodgroup = Console.ReadLine();

            System.Console.WriteLine("Enter Age: ");
            int age = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter Last Donation Date: ");
            DateTime lastdonationdate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            //Create obj in registeration class & add to the list
            RegisterationDetails donor = new RegisterationDetails(name, phonenumber, bloodgroup, age, lastdonationdate);
            registerlist.Add(donor);
            System.Console.WriteLine(line);

            //display registeration successfull & donor ID
            System.Console.WriteLine("User Registeration has been successful.");
            System.Console.WriteLine($"Donor ID is:{donor.DonorID}");
        }
        public static void Login()
        {
            System.Console.WriteLine("Login method has been called");
            System.Console.WriteLine(line);

            //ask user donr ID
            System.Console.WriteLine("Enter your Registered Donor ID");
            string searchID = Console.ReadLine().ToUpper();

            bool flag = true;

            //check donor ID is in the registerlist by  traversing the registerlist
            foreach (RegisterationDetails registered in registerlist)
            {
                //if present ...
                if (searchID.Equals(registered.DonorID))
                {
                    //show sub-menu

                    currentuser = registered;
                    flag = false;
                    System.Console.WriteLine("Login Successfully!");
                    System.Console.WriteLine(line);
                    SubMenu();
                    break;

                }
            }
            //if not present , show invalid User ID
            if (flag)
            {
                System.Console.WriteLine("Invalid Donor ID, Please Enter Valid Donor ID.");
            }



        }
        public static void FetchDonorDetails()
        {
            System.Console.WriteLine("Fetch Donor Details has been called");

            //1.	Ask for “Blood Group”  
            System.Console.WriteLine("Enter your Name: ");
            string name=Console.ReadLine();

            System.Console.WriteLine("Enter Blood Group: ");
            string searchBloodGroup = Console.ReadLine();

            System.Console.WriteLine("Enter your native place");
            string native=Console.ReadLine();
            BloodGroup bloodgroup;
            if (Enum.TryParse(searchBloodGroup, true, out bloodgroup))
            {
                BloodGroup blood = bloodgroup;
                foreach (RegisterationDetails item in registerlist)
                {
                    //and check blood group in the Donation details
                    if (item.BloodGroup.Equals(blood))
                    {
                        //and it should display the donor’s name and phone number and native place.
                        System.Console.WriteLine($"Donor Name: {currentuser.Name} Phone Number: {currentuser.Phone} Native Number: {native}");
                    }
                }
            }



        }
        public static void Exit()
        {
            System.Console.WriteLine("Exit method has been called");
        }
        public static void DefaultDetails()
        {
            RegisterationDetails register1 = new RegisterationDetails("Ravichandran", 8484848, "O_Positive", 30, new DateTime(25 / 08 / 2022));
            RegisterationDetails register2 = new RegisterationDetails("Baskaran", 4747447, "AB_Positive", 30, new DateTime(30 / 09 / 2022));
            registerlist.Add(register1);
            registerlist.Add(register2);

            DonationDetails donation1 = new DonationDetails("UID1001", new DateTime(10 / 06 / 2022), 73, 120, 14, BloodGroup.O_Positive);
            DonationDetails donation2 = new DonationDetails("UID1002", new DateTime(10 / 10 / 2022), 74, 120, 14, BloodGroup.O_Positive);
            DonationDetails donation3 = new DonationDetails("UID1003", new DateTime(11 / 07 / 2022), 74, 120, 14, BloodGroup.AB_Positive);
            donationDetailslist.Add(donation1);
            donationDetailslist.Add(donation2);
            donationDetailslist.Add(donation3);
        }

        public static void SubMenu()
        {
            //sub-menu
            string choice = "yes";

            do
            {
                System.Console.WriteLine("sub-menu method has been called!!!");
                System.Console.WriteLine(line);
                System.Console.WriteLine("SUB-MENU");
                System.Console.WriteLine("1.Donate Blood");
                System.Console.WriteLine("2.Donation History");
                System.Console.WriteLine("3.Next Eligible Date");
                System.Console.WriteLine("4.Exit");

                // Select sub-menu
                System.Console.WriteLine("Enter the Sub-Menu Choice: ");
                int submenuchoice = int.Parse(Console.ReadLine());

                switch (submenuchoice)
                {
                    case 1:
                        {
                            DonateBlood();
                            break;
                        }
                    case 2:
                        {
                            DonationHistory();
                            break;
                        }
                    case 3:
                        {
                            NextEligibleDate();
                            break;
                        }
                    case 4:
                        {
                            //exit from sub-menu and return to main-menu
                            choice = "no";
                            MainMenu();
                            break;
                        }

                    default:
                        {
                            System.Console.WriteLine("Invalid Choice. Please Enter valid sub-menu choice.");
                            break;
                        }
                }
            } while (choice == "yes");

        }

        public static void DonateBlood()
        {
            System.Console.WriteLine(line);
            System.Console.WriteLine("donate blood method has been called");

            //•	Get the weight, blood pressure, hemoglobin count from the user

            System.Console.WriteLine("Enter Weight: ");
            double weight = double.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter Blood Pressure: ");
            double bloodpressure = double.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter Hemoglobin Count: ");
            double hemoglobincount = double.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter Blood Group: ");
            BloodGroup bloodgroup = (BloodGroup)Enum.Parse(typeof(BloodGroup), Console.ReadLine());

            foreach (RegisterationDetails registerdetails in registerlist)
            {
                foreach (DonationDetails donationdetails in donationDetailslist)
                {
                    //check Weight is above 50, bp is below 130 hemoglobin count is above 13.
                    if (weight > 50 && bloodpressure < 130 && hemoglobincount > 30)
                    {
                        //•	Check whether the person’s completed 6 months after donating the blood.
                        if (DateTime.Today > registerdetails.LastDonationDate.AddMonths(6))
                        {
                            //•	If both the conditions met, then add the details to the “Donation Details” object and finally add to the list.
                            DonationDetails newdonation = new DonationDetails(registerdetails.DonorID, DateTime.Now, weight, bloodpressure, hemoglobincount, bloodgroup);
                            donationDetailslist.Add(newdonation);

                            //•	Finally show Blood donated successfully, Show the donation ID And print the next eligible date of donation

                            System.Console.WriteLine($"Blood donated successfully.Your donotion ID is {donationdetails.DonationID}");

                            //•	Next eligible date of donation is after 6 months from last time donor donate the blood.
                            System.Console.WriteLine($"Next eligible date of donation is: {registerdetails.LastDonationDate.AddMonths(6).Date}");
                            break;
                        }
                        break;
                    }
                    break;
                }
                break;
            }
        }
        public static void DonationHistory()
        {
            System.Console.WriteLine(line);
            System.Console.WriteLine("donation history method has been called");
            System.Console.WriteLine(line);

            //Show the donation details of the current user using the method by traversing the donation history list.
            foreach (DonationDetails item in donationDetailslist)
            {
                System.Console.WriteLine($"Donor ID :{item.DonorID} Date :{item.DonationDate} Weight : {item.Weight} Blood Pressure :{item.BloodPressure} Hemoglobin Count :{item.HBCount} Blood Group: {item.BloodGroup}");
            }



        }
        public static void NextEligibleDate()
        {
            System.Console.WriteLine(line);
            System.Console.WriteLine("next eligible date method has been called");
            System.Console.WriteLine(line);
            foreach (RegisterationDetails register in registerlist)
            {
                DateTime nexteligibility = register.LastDonationDate.AddMonths(6);
                System.Console.WriteLine($"Next eligibilty date is: {nexteligibility.ToString("dd/MM/yyyy")}");

            }
            //  DateTime nexteligibility=DateTime.Now.AddMonths(6).Date;
        }
    }
}