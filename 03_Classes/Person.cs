using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Classes
{
    public class Person
    {
        public string FirstName { get; set; }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public DateTime DateOfBirth { get; set; }

        public Vehicle Transport { get; set; }

        //example of a method without a return type (readonly)
        //first and last name are already established in the above methods, and will be filled in, in this medthod, when it is called
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public int Age
        {
            get
            {
                TimeSpan ageSpan = DateTime.Now - DateOfBirth;
                double totalAgeInYears = ageSpan.TotalDays / 365.25;
                int yearsOfAge = Convert.ToInt32(Math.Floor(totalAgeInYears));
                return yearsOfAge; 
            }
        }
        //Empty Constructor
        public Person() { }
        //Overloaded Constructor 
        public Person(string firstName, string lastname, DateTime dob, Vehicle transport)
        {
            FirstName = firstName;
            LastName = lastname;
            DateOfBirth = dob;
            Transport = transport;
        }


    }
}
