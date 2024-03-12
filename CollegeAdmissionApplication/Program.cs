using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
namespace CollegeAdmissionApplication;


class Program
{
      static  List<StudentDetails> studentDetailslist=new List<StudentDetails>();
      static List<DepartmentDetails> departmentDetailslist=new List<DepartmentDetails>();
      static  List<AdmissionDetails> admissionDetailslist=new List<AdmissionDetails>();
      static StudentDetails currentuser;  //currentuser of class studentdetails
      
    public static void Main(string[] args)
    {  
        Default();
        Registration();
        Login();

        
    }    
        static void Registration()
        {
                    Console.WriteLine("Enter Name: ");
                    string name=Console.ReadLine();

                    Console.WriteLine("Enter Father Name: ");
                    string fathername=Console.ReadLine();

                    System.Console.WriteLine("Enter Date of Birth: ");
                    DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

                    System.Console.WriteLine("Enter Gender: ");
                    Gender gender=Enum.Parse<Gender>(Console.ReadLine(), true);   //true for ignore case

                    System.Console.WriteLine("Enter Physics Mark: ");
                    int physics =int.Parse(Console.ReadLine());

                    System.Console.WriteLine("Enter Chemistry Mark: ");
                    int chemistry = int.Parse(Console.ReadLine());

                    System.Console.WriteLine("Enter Math Mark: ");
                    int math=int.Parse(Console.ReadLine());

                    StudentDetails student = new StudentDetails(name,fathername,dob,gender,physics,chemistry,math);
                    studentDetailslist.Add(student);

                    System.Console.WriteLine($"Student Registered Successfully and StudentID is: {student.StudentID}");
        }
        static void Login()
        {
            string temp =" ";
         
            System.Console.WriteLine("Enter your StudentID: ");
                    string searchID = Console.ReadLine().ToUpper();
            do
            {     
                   
                    char option;

                    foreach (StudentDetails  student in studentDetailslist)  
                    {
                        if(searchID.Equals(student.StudentID))
                        {
                            currentuser=student;   
                                
                            System.Console.WriteLine("\n Submenu: ");
                            System.Console.WriteLine("a. Check Eligibility");
                            System.Console.WriteLine("b. Show Details");
                            System.Console.WriteLine("c. Take Admission");
                            System.Console.WriteLine("d. Cancel Admission");
                            System.Console.WriteLine("e. Show Admission Details");
                            System.Console.WriteLine("f. Exit");

                            Console.WriteLine("Enter your choice: ");
                            option = char.Parse(Console.ReadLine());

                            switch (option)
                            {
                                case 'a':
                                {
                                    CheckEligibility();                                  
                                    break;
                                }
                                case 'b':{
                                    ShowDetails();                                  
                                    break;
                                }
                               
                                case 'c':{                                   
                                    TakeAdmission();
                                    break;
                                } 
                                case 'd':{
                                    CancelAdmission();
                                    break;
                                }
                                case 'e':{
                                    ShowAdmissionDetails();
                                    break;
                                }
                                case 'f':{  //main menu
                                    Exit();
                                    break;
                                }
                                
                                default:{
                                    System.Console.WriteLine("Invalid choice");
                                    break;
                                }                    
                            } 
                           }                   
                        }
                       
                  System.Console.WriteLine("Do you want to view the Sub menu?");    
                  temp = Console.ReadLine().ToLower();  
            }
             while (temp=="yes"); 
        

        /// <summary>
        /// methods for login
        /// </summary>
    
                    static void CheckEligibility()
                    {
                        System.Console.WriteLine($"Average : {currentuser.Average()}");
                        bool flag = currentuser.CheckEligibility(75.0);
                        if(flag)
                        {
                            System.Console.WriteLine("Student is eligible ");
                        }
                        else
                        {
                            System.Console.WriteLine("Student is not eligible");
                        } 
                    }
                    static void ShowDetails()
                    {                                                      
                        System.Console.WriteLine($" Name is: {currentuser.Name}\nFather Name: {currentuser.FatherName}\nDate of Birth: {currentuser.DOB.ToString("dd/MM/yyyy")}\n Gender:{currentuser.Gender}\n Physics mark: {currentuser.Physics}\n Chemistry Mark: {currentuser.Chemistry}\n Math Mark: {currentuser.Math}");                                     
                    }
                    static void TakeAdmission()
                    {
                        foreach (DepartmentDetails details in departmentDetailslist)
                        {
                            System.Console.WriteLine($"Department Name: {details.DepartmentName} \tDepartment ID: {details.DepartmentID}\t Available seats: {details.NumberOfSeats}"); 
                                                                                  
                        }
                        
                        System.Console.WriteLine("Pick one Department ID:");
                        string departmentID = Console.ReadLine().ToUpper();

                        foreach (DepartmentDetails department in departmentDetailslist)
                        {
                            if(departmentID.Equals(department.DepartmentID) && currentuser.CheckEligibility(75.0)) //multiple if
                            {  //dbt   no=>break and show submenu
                                if(department.NumberOfSeats>0)
                                {
                                    System.Console.WriteLine("Enter the Admission Date:");
                                    DateTime admissionDate= DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null); 
                                   // bool temp = false;
                                    foreach (AdmissionDetails admission in admissionDetailslist)
                                    {
                                        if(!admission.StudentID.Contains(currentuser.StudentID) && admission.AdmissionStatus!=AdmissionStatus.Admitted)
                                        {
                                          //  temp=true;
                                            department.NumberOfSeats--;
                                            AdmissionDetails admissionDetails=new AdmissionDetails(currentuser.StudentID, departmentID,admissionDate,admissionstatus:"Booked");
                                            admissionDetailslist.Add(admissionDetails);
                                            Console.WriteLine($"Admission took successfully. Your admissionID {admission.AdmissionID}");
                                        }
                                        break;
                                    }                  
                                }                                           
                            }
                        }
                    }
                    static void CancelAdmission()
                    {
                        foreach (AdmissionDetails admission in admissionDetailslist)
                        {
                            foreach (DepartmentDetails department in departmentDetailslist)
                            {
                                if(admission.StudentID==currentuser.StudentID)
                                {
                                    if(admission.AdmissionStatus!=AdmissionStatus.Cancelled)
                                    {
                                        department.NumberOfSeats +=1;
                                        admission.AdmissionStatus=AdmissionStatus.Cancelled;
                                        System.Console.WriteLine("Admission cancelled successfully.");
                                    }
                                }
                               
                            }
                           
                        }
                    }
                        static void ShowAdmissionDetails()
                        {
                            foreach (AdmissionDetails admission in admissionDetailslist)
                            {
                                if(admission.AdmissionStatus==AdmissionStatus.Cancelled)
                                {
                                    System.Console.WriteLine($"Admission Date :{admission.AdmissionDate.ToString("dd/MM/yyyy")}, Student ID :{admission.StudentID}, Admission Status: {admission.AdmissionStatus}, Department ID: {admission.DepartmentID}");
                                }
                            }
                        }
                        static void Exit()
                        {

                           
                        }


        }

          static void Default()
          {
            StudentDetails student1=new StudentDetails("Ravichandran E","Ettapparajan",new DateTime(1999,11,11), Gender.Male, 95,95,95);
            StudentDetails student2=new StudentDetails("Baskaran S","Sethurajan",new DateTime(1999,11,11), Gender.Male, 95,95,95);

            studentDetailslist.Add(student1);
            studentDetailslist.Add(student2);


            DepartmentDetails details1=new DepartmentDetails("EEE",29);
            DepartmentDetails details2=new DepartmentDetails("CSE",29);
            DepartmentDetails details3=new DepartmentDetails("MECH",29);
            DepartmentDetails details4=new DepartmentDetails("ECE",29);
            departmentDetailslist.Add(details1);       
            departmentDetailslist.Add(details2);
            departmentDetailslist.Add(details3);
            departmentDetailslist.Add(details4);

            AdmissionDetails admissiondetails1 = new AdmissionDetails("SF3001","DID101",new DateTime(11/05/2022),"Booked");
            AdmissionDetails admissiondetails2 = new AdmissionDetails("SF3002","DID101",new DateTime(11/05/2022),"Booked");

            admissionDetailslist.Add(admissiondetails1);
            admissionDetailslist.Add(admissiondetails2);



                int choice;          
                do
                {
                    System.Console.WriteLine("\n Menu");
                    System.Console.WriteLine("1. Registration");
                    System.Console.WriteLine("2. Student Login");
                    System.Console.WriteLine("3. Department wise seat availability");
                    System.Console.WriteLine("4. Exit");

                    Console.Write("Enter your choice: ");
                    choice=int.Parse(Console.ReadLine());

                    

                    switch (choice)
                    {  
                        case 1:
                        { 
                            Registration();                   
                            break;
                        }
                        case 2:
                        {
                            Login();
                            break;                  
                        }
                        case 3:
                        {
                        // DepartmentWiseSetAvailability();
                            break;
                        }
                        case 4:
                        {
                            break;
                        }
                        default:
                        {
                            System.Console.WriteLine("Invalid choice");
                            break;
                        }               
                    }              
                } 
                while (choice!=4);
    }
}     
