using LINQ_Example;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace linqprog
{
    class stud
    {
        public  int studid;
        public string studnm;
        public  string email;
    }
    class Program
    { 
        static public List<string> names = new List<string>();
        static public List<stud> stdlst = new List<stud>();
        public static void createlst()
        {
              names.Add("Ruby");
            names.Add("Lily");
            names.Add("Sweety");
            names.Add("Rita");
            names.Add("Ramya");
            names.Add("Ramesh");
                


        }
        public static void lcontains()
        {                 

            createlst();
          //  var filnam = names.Where(n => n.Contains("R"));

            //foreach (string nm in filnam)
              //  Console.WriteLine("Name containing alphabet U(contains)  is : " + nm + "\n");

            

              var filnam1 = from n in names
                            where n.Contains("R")                                                    
                            select n;
           

foreach (string nm in filnam1)
  Console.WriteLine(nm + "\n");

//this into lamda expression

           /* IEnumerable<string> query = names.Where(n => n.Contains("a"))
                                         .OrderBy(n => n.Length)
                                         .Select(n => n.ToUpper());*/
        }
        public static void lLength()
        {

            createlst();
            IEnumerable<string> filnam = names.Where(n => n.Length >= 5).OrderBy(n=>n.Length).Select(n=>n.ToUpper());

          /*  foreach (string nm in filnam)
                Console.WriteLine("Length Example : " + nm + "\n");*/

            var filnam1 = from n in names
                         where n.Length>=5
                         orderby n.Length
                         select n.ToUpper();


            foreach (string nm in filnam1)
                Console.WriteLine(nm + "\n");
        }
       
        public static void Lmethods()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
           
            IEnumerable<int> firstthree = numbers.Take(3);
            Console.WriteLine("first threenumbers using (Take)");
            foreach (int num in firstthree)
                Console.WriteLine("\t" + num + "\n");

            IEnumerable<int> lasttwo = numbers.Skip(3);
            Console.WriteLine("(Skip) first 3 numbers ");
            foreach (int num in lasttwo)
                Console.WriteLine("\t" + num + "\n");

            IEnumerable<int> reversed = numbers.Reverse();
            Console.WriteLine("(Reverse) numbers : ");
            foreach (int num in reversed)
                Console.WriteLine("\t" + num + "\n");

            int firstnum = numbers.First();
            int lastnum = numbers.Last();
            int secondnum = numbers.ElementAt(1);
            int lowestnum = numbers.OrderBy(n => n).First();

            //aggregate operators
            
            int count = numbers.Count();
            int min = numbers.Min();

            Console.WriteLine("(Count) of numbers : " + count);
            Console.WriteLine("(Min) number : " + min);

            //quantifiers return bool value

            bool hasnum = numbers.Contains(2);
            bool hasmorethanzeroelements = numbers.Any();


            bool hasanoddelement = numbers.Any(n => n % 2 == 1);

            Console.WriteLine("(contains) true or false : " + hasnum);
            Console.WriteLine("(Any) returns true if it contains numbers : " + hasmorethanzeroelements);
            Console.WriteLine("(Any) Finds odd numbers : " + hasanoddelement);

            int[] IntArray = { 11, 22, 33, 44, 55 };

            var v = IntArray.Where(n => n % 2 == 1).Select(n => n);

            var Result = IntArray.All(x => x > 10);
            Console.WriteLine("Is All Numbers are greater than 10 : " + Result);

            //Using Method Syntax
            var ResultMS = IntArray.Any();

            //Using Query Syntax
            var ResultQS = (from num in IntArray
                            select num).Any();

            Console.WriteLine("Is there any element in the collection : " + ResultMS);
            
            //Handson 

            string[] stringArray = { "James", "Sachin", "Sourav", "Pam", "Sara" };
            //Method Syntax
            var ResultMS1 = stringArray.All(name => name.Length > 5);
            Console.WriteLine("Is All name with length  greater than 5 Characters : " + ResultMS1);
            //Query Syntax

            var ResultQS1 = (from name in stringArray
                            select name).Any(name => name.Length > 5);
            Console.WriteLine("Is Any name with length  greater than 5 Characters : " + ResultQS1);

        }
        

        public static void LGroupby()
        {
            // select count(*),dept_name from dept groupby dept_name


            var employeeGroup = from employee in Employee.GetAllEmployees()
                                group employee by employee.Department;

            foreach (var group in employeeGroup)
            {
                Console.WriteLine("{0} - {1}", group.Key, group.Count());
            }
        }

        public static void Lmultiply()
        {
            var numbers = new List<int>();
            numbers.Add(5);

           double query = numbers.Select(n => n * 10).Average(n=>n);
            double query1 =Employee.GetAllEmployees().Select(n => n.Salary).Average(n => n);
            numbers.Add(6);

          //  foreach (int n in query)
                Console.WriteLine("salary results " + query1 );


        }

        public static void LSubquery()
        {
            string[] names = { "Ruby", "Lily", "Sweety", "Angela", "Anne" };
            int shortest = names.Min(n => n.Length);
            IEnumerable<string> query = from n in names
                                        where n.Length == shortest 
                                        select n;
            Console.WriteLine("Subquery Results");
            foreach (string q in query)
                Console.WriteLine(q);

        }

        public static void LClear()
        {
            var numbers = new List<int>() { 5, 6 };

            IEnumerable<int> query = numbers.Select(n => n * 10);
            foreach (int n in query)
                Console.WriteLine(n + "\n");

            numbers.Clear();
            foreach (int n in query)
                Console.WriteLine("nnm" + n + "\n");

            //we can defeat reevaluation by calling a conversion operator suchas ToArray or ToList
            //ToArray copies the output of a query to an array
            //ToList copies to a generic List<>

            /*   var numbers = new List<int>() { 5, 6 };
               List<int> timesTen = numbers
                   .Select(n => n * 10)
                   .ToList();

               numbers.Clear();
                Console.WriteLine("count=" + timesTen.Count);*/
        }

        public static void LReplace()
        {
            string[] names = { "Ruby", "Lily", "Sweety", "Angela", "Anne" };
            IEnumerable<string> query = from n in names
                                        where n.Length > 3
                                        orderby n
                                        select n.Replace("a", "").Replace("e", "").Replace("i", "")
                                        .Replace("o", "").Replace("u", "");
            foreach (string n in query)
                Console.WriteLine(n);

        }
        public static void lSelect()
        {

            string[] names = { "Ruby", "Lily", "Sweety", "Angela", "Anne" };
                 
            IEnumerable<string> filnam = from n in names
                                         select n;

            foreach (string nm in filnam)
                Console.WriteLine("\t" + nm);
        }
        static void Main(string[] args)
        {
          
          char ch = 'y';

            while (ch == 'y')
            {
                Console.WriteLine("Enter the keyword you want to check\n 1.contains \n 2.Length \n 3.Methods \n 4.Multiply \n 5.Subquery \n 6.Clear \n 7.Replace \n 8.Select \n 9.GroupBy");
                int word = int.Parse(Console.ReadLine());
                switch (word)
                {
                    case 1:
                        Program.lcontains();
                        break;
                    case 2:
                        Program.lLength();
                        break;
                    case 3:
                        Program.Lmethods();
                        break;
                    case 4:
                        Program.Lmultiply();
                        break;
                    case 5:
                        Program.LSubquery();
                        break;
                    case 6:
                        Program.LClear();
                        break;
                    case 7:
                        Program.LReplace();
                        break;
                    case 8:
                        Program.lSelect();
                        break;
                    case 9:
                        Program.LGroupby() ;
                        break;

                    default:
                        break;


                }
                Console.WriteLine("Do you want to continue y/n");
                ch = Convert.ToChar(Console.ReadLine());
                if (ch == 'n')
                {
                    System.Environment.Exit(0);
                }
            }

            Console.ReadKey();
        }
    }
}
