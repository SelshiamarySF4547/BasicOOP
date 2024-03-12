using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmissionApplication
{



    /*AdmissionID
	StudentID
	DepartmentID
	AdmissionDate
	AdmissionStatus
*/
    public enum AdmissionStatus{Select,Admitted,Cancelled}
    public class AdmissionDetails
    {
        public static int s_admissionID=1000;

        public string AdmissionID{get;set;}
        public string DepartmentID{get;set;}
        public DateTime AdmissionDate{get;set;} 
        

        public string StudentID{get;set;}


        public AdmissionStatus AdmissionStatus{get;set;}

        public AdmissionDetails(string studentid, string departmentid, DateTime admissiondate, string admissionstatus){
            s_admissionID++;
            AdmissionID = "SF" + s_admissionID;
            StudentID=studentid;
            DepartmentID=departmentid;
            AdmissionDate=admissiondate;
            //AdmissionStatus=admissionstatus;
            
        
            //date
            //status
            





        }


    }
}