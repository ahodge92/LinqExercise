using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            var sum = numbers.Sum();
            var avg = numbers.Average();

            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Average: {avg}");


            //Order numbers in ascending order and decsending order. Print each to console.
            var numascending = numbers.OrderBy(x => x);
            var numdecsending = numbers.OrderByDescending(y => y);

            Console.WriteLine("\nAscending:");
            foreach (var num in numascending)
            {
                Console.Write(num + ",");
            }

            Console.WriteLine("\n\nDescending:");
            foreach (var num in numdecsending)
            {
                Console.Write(num+ ",");
            }

            //Print to the console only the numbers greater than 6
            var greaterThenSix = numbers.Where(num => num > 6);

            Console.WriteLine("\n\nGreater then 6:");
            foreach (var num in greaterThenSix)
            {
                Console.Write(num + ",");
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("\n\nFirst 4 acsending");
            foreach (var num in numascending.Take(4))
            {
                Console.Write(num + ",");
            }

            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("\n\nWith my age:");
            numbers[4] = 28;

            foreach (var num in numbers.OrderByDescending(num => num))
            {
                Console.Write(num + ",");
            }

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            Console.WriteLine("\n\nFirst name starts with C or S:");
            var filtered = employees.Where(person => person.FirstName[0] == 'C' || person.FirstName[0] == 'S').OrderBy(person => person.FirstName);

            foreach (var employee in filtered)
            {
                Console.WriteLine(employee.FullName);
            }

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("\nOver the Age of 26:");
            var overTwentySix = employees.Where(person => person.Age > 26).OrderBy(person => person.Age).ThenBy(person => person.FirstName);

            foreach (var employee in overTwentySix)
            {
                Console.WriteLine($"Age: {employee.Age} Name: {employee.FullName}");
            }

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            Console.WriteLine("\nYears of experience less then 10 and age greater than 35");

            var yoeEmployees = employees.Where(person => person.YearsOfExperience <= 10 && person.Age >35);
            var sumofYoe = yoeEmployees.Sum(person => person.YearsOfExperience);
            var avgofYoe = yoeEmployees.Average(person => person.YearsOfExperience);

            Console.WriteLine($"Sum: {sumofYoe} Avg: {avgofYoe}");


            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("first", "lastName", 98, 1)).ToList();

            foreach (var person in employees)
            {
                Console.WriteLine($"{person.FullName} {person.Age}");
            }
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
