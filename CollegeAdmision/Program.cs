using System;
using System.Collections.Generic;
namespace CollegeAdmision;
class Program{
    public static void Main(string[] args)
    {

        List<StudentDetails> studentList= new List<StudentDetails>();  // file to hold application forms.

        string choice = " ";
        do
        {

            Console.Write("Enter your Name: ");
            string name=Console.ReadLine();

            Console.Write("Enter your Age: ");
            int age= int.Parse(Console.ReadLine());

            Console.Write("Enter your Gender: ");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);    //enum

            Console.Write("Enter your Date of Birth: ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy", null);

            Console.Write("Enter your Physics Mark: ");
            int physics = int.Parse(Console.ReadLine());

            Console.Write("Enter your Chemistry Mark: ");
            int chemistry = int.Parse(Console.ReadLine());

            Console.Write("Enter your Math Mark: ");
            int math= int.Parse(Console.ReadLine());


            StudentDetails student = new StudentDetails(name,age,gender,dob,math,physics,chemistry);  //copy   new ==> creates new copies 

            studentList.Add(student);
            System.Console.WriteLine($"Student added successfully. \n Student ID: {student.StudentID}");
            System.Console.WriteLine($"Average : {student.Average()}");
            bool flag =student.CheckEligiblity(50.0);
            if(flag)
            {
                System.Console.WriteLine("Eligible");
            }
            else{
                System.Console.WriteLine("Not Eligible");
            }





            System.Console.WriteLine("Do you want to add another user?");
            choice= Console.ReadLine().ToLower();
            
        } while (choice=="yes");


        
   

       


        // need to check the user
        System.Console.WriteLine("Enter your StudentID: ");
        string searchID = Console.ReadLine().ToUpper();



        foreach (StudentDetails student4 in studentList)  //to open the forms from the file
        {
            if(searchID.Equals(student4.StudentID)){
                System.Console.WriteLine($"Name is: {student4.Name} \n Age: {student4.Age} \n Gender: {student4.Gender} \n Date of Birth: {student4.DOB.ToString("dd/MM/yyyy")} \n  Physics mark: {student4.Physics} \n Chemistry Mark: {student4.Chemistry}  \n Math Mark: {student4.Maths} ");       

            }
        }





   


    }
    static void Default(){


    }
}