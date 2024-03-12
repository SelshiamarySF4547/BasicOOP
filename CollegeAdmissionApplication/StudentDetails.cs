using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*Properties: 
a.	StudentID – (AutoGeneration ID – SF3000)
b.	StudentName
c.	FatherName
d.	DOB
e.	Gender – Enum (Male, Female, Transgender)
f.	Physics
g.	Chemistry
h.	Maths*/

namespace CollegeAdmissionApplication
{
   public enum Gender{Select,Male,Female}  //either one ==>enum
    public class StudentDetails
    {
        public static int s_studentID = 3000;   //static field
        public string StudentID{get;set;}
        public string Name{get;set;} 
        public string FatherName{get;set;} 
        public DateTime DOB{get;set;} 
        public Gender Gender{get; set;}
        public int Physics{get;set;} 
        public int Chemistry{get;set;}
        public int Math{get;set;}
        /// <summary>
        /// Creates an instance to add in a class StudentDetails
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fathername"></param>
        /// <param name="dob"></param>
        /// <param name="gender"></param>
        /// <param name="physics"></param>
        /// <param name="chemistry"></param>
        /// <param name="math"></param> <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fathername"></param>
        /// <param name="dob"></param>
        /// <param name="gender"></param>
        /// <param name="physics"></param>
        /// <param name="chemistry"></param>
        /// <param name="math"></param>


        public StudentDetails(string name, string fathername, DateTime dob, Gender gender, int physics, int chemistry, int math){ //constructor
            s_studentID++;
            StudentID ="SF" + s_studentID;   
            Name=name;
            FatherName=fathername;
            DOB=dob;
            Gender=gender;
            Physics=physics;
            Chemistry=chemistry;
            Math=math;
        }
        
        public double Average()   //method
        {
            int total = Physics+Chemistry+Math;

            double average =(double)total/3;

            return average;
        }
        public bool CheckEligibility(double cutOff)
        {
            double average = Average();

            if(average>=cutOff)
            {
                return true;
            }
            return false;
        }

    }
}