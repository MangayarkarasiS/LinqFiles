using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Projection
{/* Select
  * SelectMany
  
  Select clause in SQL allows to specify what columns we want to retrieve. 
    In a similar fashion LINQ SELECT standard query operator allows us 
    to specify what properties we want to retrieve. 
    It also allows us to perform calculations.

    property(empnm),calculation(salary+1000),more than 1 property(empnm,age) 
    - can be retrieved by select
*/
    class Program
    {
        static void Main(string[] args)
        {

            //Example 1: Retrieves just the EmployeeID property of all employees
            /*
            IEnumerable<int> employeeIds =Employee.GetAllEmployees()
                                          .Select(emp => emp.EmployeeID);
              foreach (int id in employeeIds)
              {
                  Console.WriteLine(id);
              }*/

            //Example 2:  Projects FirstName & Gender properties of all employees into anonymous type.
            
            var result1 = Employee.GetAllEmployees() 
                         .Select(emp => new
                              {
                                 FirstName = emp.FirstName,
                                 Gender = emp.Gender
                              });
              foreach (var v in result1)
              {
                  Console.WriteLine(v.FirstName + " - " + v.Gender);
              }

            //Example 3: Computes FullName and MonthlySalay of all employees and 
            //projects these 2 new computed properties into anonymous type.
            /*
            var result = Employee.GetAllEmployees().Select(emp => new
            {
                FullName = emp.FirstName + " " + emp.LastName,
                MonthlySalary = emp.AnnualSalary / 12
            });

            foreach (var v in result)
            {
                Console.WriteLine(v.FullName + " - " + v.MonthlySalary);
            }
            */
            //Example 4: Give 10% bonus to all employees whose 
            //annual salary is greater than 50000 and project all 
            //such employee's FirstName, AnnualSalay and Bonus into anonymous type.

            var result = Employee.GetAllEmployees()
                            .Where(emp => emp.AnnualSalary > 50000)
                            .Select(emp => new
                            {
                                Name = emp.FirstName,
                                Salary = emp.AnnualSalary,
                                Bonus = emp.AnnualSalary * .1
                            });

            foreach (var v in result)
            {
                Console.WriteLine(v.Name + " : " + v.Salary + " - " + v.Bonus);
            }
            Console.ReadKey();
        }
    }
}
