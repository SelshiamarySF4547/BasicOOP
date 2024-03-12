using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeAdmision;

namespace CollegeAdmision
{

       /**
           class
          enum types
	   delegates
	   structures
	   records

       */

       /// <summary>
       /// DataType Gender used to select a instance of <see cref="StudentDetails" /> Gender Information
       /// </summary> 
    public enum  Gender{Select, Male, Female};    //0,1,2   Select=11,Male,Female  ===> 11,12,13

       /// <summary>
       /// Class StudentsDetails used to create an instance of students <see cref="StudentsDetails />"
       /// </summary> <summary>
       /// Refer documentaation on <see href ="www.syncfusion.com" /> 
       /// </summary>
    public class StudentDetails
    {
       /* private string _name; //field   ===> _fieldname   attributes/characteristics of class     FAB

                     // public string {get; set;}


       public string Name              //properties
       {  
        get {return _name;}   //read from field
        set {_name = value;}   // write to field

         //auto property = have both field and property indside it

       }*/



       //Field  : provided
       //Static Field
       private static int s_studentID = 1000;  //   triggers first ( static field)    //private int _studentID  (non-static field)
  

       /// <summary>
       /// Student ID property used to hold the Student's ID  of the instance of <see cref="StudentDetails"/> 
       /// </summary>
          
       public string StudentID {get;}  //readonly


       /// <summary>
       /// Name property used to hold the Name of a instance of <see cref="StudentDetails"/> 
       /// </summary> 
       public string Name{get; set;}  //attributes


       /// <summary>
       /// Age property used to hold the Age of a instance of <see cref="StudentDetails"/> 
       /// </summary>
       public int  Age { get; set; }


       /// <summary>
       /// Gender property used to hold the Gender of a instance of <see cref="StudentDetails"/> 
       /// </summary> 
       public Gender Gender { get; set; }


       /// <summary>
       /// DOB property used to hold the Date of Birth of a instance of <see cref="StudentDetails"/> 
       /// </summary> 
       public DateTime DOB { get; set; }


       /// <summary>
       /// Physics property used to hold the Physics Marks of a instance of <see cref="StudentDetails"/> 
       /// </summary> 
       /// <value> 0 to 100 </value>
       public int  Physics { get; set; }


       /// <summary>
       /// Chemistry property is used to hold the Chemistry Marks of a instance of <see cref="StudentDetails"/> 
       /// </summary>
       /// <value> 0 to 100 </value>

       public int Chemistry { get; set; }

       /// <summary>
       /// Maths property is used to hold the Maths Marks of a instance of <see cref="StudentDetails"/> 
       /// </summary>
       ///<value> 0 to 100 </value>
       public int Maths { get; set; }





       // default constructor:  it constructs using attributes

       /// <summary>
       /// Constructor StudentDetails used to initialize default values to its properties.
       /// </summary> 
       public StudentDetails()
       {
        Name="enter name";
       }


       //Parametrized constructor:  we can assign values here , constructor gives OBJECT 

       /// <summary>
       /// Constructor StudentDetails used to assigned parameter values to its properties.
       /// </summary>
       /// <param name="name">name parameter is used to assign its name to associated property</param>
       /// <param name="age">age age parameter is used to assign its name to associated property </param>
       /// <param name="gender">gender parameter is used to assign its name to associated property</param>
       /// <param name="dob">dob parameter is used to assign its name to associated property</param>
       /// <param name="math">math parameter is used to assign its name to associated property</param>
       /// <param name="physics">physics parameter is used to assign its name to associated property</param>
       /// <param name="chemistry">math parameter is used to assign its name to associated property</param>
       public StudentDetails(string name, int age, Gender gender, DateTime dob, int math, int physics, int chemistry)  //pass parameters
       {
              s_studentID++;
              StudentID ="SF" +s_studentID;         // StudentID ="SF" + ++s_studentID;

              
              Name=name;
              Age=age;
              Gender=gender;
              DOB=dob;
              Physics=physics;
              Maths=math;
              Chemistry=chemistry;      
       }
       public StudentDetails(string name, int age, Gender gender, int math, int physics, int chemistry)
       {
              Name=name;
              Age=age ;
              Gender=gender;
              Maths=math;
              Physics=physics;
              Chemistry=chemistry;
       }

       //   Method
       /// <summary>
       /// Method Average used to calculate average mark score of of instance of <see cref="StudentDetails"/> 
       /// </summary>
       /// <returns>Returns average of Physics, Chemistry and Maths marks</returns> 
       public double Average()
       {
              int total = Physics+Chemistry+Maths;

              double average = (double)total/3;

              return average;
       }


       /// <summary>
       /// Method CheckEligibility used to check whether the instance of <see cref="StudentDetails"/> 
       /// is eligible for admission based on cutOff
       /// </summary>
       /// <param name="cutOff"> cutOff limit to find eligibility</param>
       /// <returns>Returns true if eligible, else false.</returns> 
       public bool CheckEligiblity(double cutOff)
       {
              double average = Average();
              if(average>= cutOff)
              {
              return true;
              }
              
              return false;     
       }

       

  

    }}

    
