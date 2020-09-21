using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Remoting;
using _06_Inheritance_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06_Inheritance_Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void SetName_ShouldSetCorrectly()
        {
            Person martha = new Person();
            martha.SetFirstName("Martha");
            martha.SetLastName("Vineyard");
            Console.WriteLine(martha.Name);

            Customer bob = new Customer();
            bob.SetFirstName("Robert");
            bob.SetLastName("Boss");

            SalaryEmployee tedEmployee = new SalaryEmployee
            {
                PhoneNumber = "1800-fake",
                Salary = 80000000,
                HireDate = new DateTime(1304, 01, 01),
                EmployeeNumber = 394
            };
            Console.WriteLine(tedEmployee.YearsWithCompany);
        }

        [TestMethod]
        public void EmployeeTests()
        {
            Employee jarvis = new Employee();
            HourlyEmployee tony = new HourlyEmployee();
            SalaryEmployee pepper = new SalaryEmployee();
            tony.HourlyWage = 3000;
            pepper.Salary = 2000000;
            HourlyEmployee peter = new HourlyEmployee();
            SalaryEmployee happy = new SalaryEmployee();
            happy.Salary = 150000;
            List<Employee> allEmployess = new List<Employee>();
            jarvis.SetFirstName("jarvis");
            tony.SetFirstName("tony");
            pepper.SetFirstName("pepper");
            peter.SetFirstName("peter");
            happy.SetFirstName("happy");
            allEmployess.Add(jarvis);
            allEmployess.Add(tony);
            allEmployess.Add(pepper);
            allEmployess.Add(peter);
            allEmployess.Add(happy);

            foreach (Employee worker in allEmployess)
            {
                if (worker.GetType() == typeof(SalaryEmployee))
                {
                    SalaryEmployee sEmployee = (SalaryEmployee)worker;
                    Console.WriteLine($"This is a salary employee that makes {sEmployee.Salary}");
                }
                else if (worker is HourlyEmployee hourlyWorker)
                {
                    Console.WriteLine($"{worker.Name} has worked {hourlyWorker.HoursWorked} hours!");
                }
            }
        }
    }
}
