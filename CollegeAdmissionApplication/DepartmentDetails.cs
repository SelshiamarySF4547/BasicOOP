using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmissionApplication
{
/*a.	DepartmentID – (AutoIncrement - DID101)
b.	DepartmentName
c.	NumberOfSeats
*/
    public class DepartmentDetails
    {
        public static int s_departmentID=100;
        public string DepartmentName {get;set;}

        public string DepartmentID{get;set;}
       // public string StudentID{get;set;}

        public int NumberOfSeats{get;set;}


        public DepartmentDetails(string departmentname, int numberofseats)
        {
            s_departmentID++;
            DepartmentID = "DID"+s_departmentID;
            DepartmentName=departmentname;
            NumberOfSeats=numberofseats;
        }


        /* public double Average()   //constructor
        {
            int total = Physics+Chemistry+Math;

            double average =(double)total/300;

            return average*100;
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
*/

        public bool CheckAvailableSeats(){
            if(NumberOfSeats > 0){
                return true;
            }
            return false;
        }



    }

}