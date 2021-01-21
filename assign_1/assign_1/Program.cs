using assig_1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace assign_1
{
    /// <summary>
    /// Author: Zhiping Yu  Student number: 000822513   Sep 24,2020
    /// This class is the main class. It display the information user is requiring 
    /// and control the whole process.
    /// 
    /// I, Zhiping Yu, 000822513 certify that this material is my original work.  
    /// No other person's work has been used without due acknowledgement.
    /// </summary>
    class Program

    {
        /// <summary>
        /// Check if employees array is null. If it is null, exit the program. Otherwise, 
        /// continue to execute based on user's choice
        /// based on user's selection
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)

        {
            Employee[] employees = Read();
            if (employees != null)
            {
                processUserSelection(employees);
            }
            else
            {
                Console.WriteLine("\nProgram is terminated due to exception, Click any key to close.");
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Ask user to make a seletion at a specific range and respond to any requests.
        /// </summary>
        /// <param name="employees"></param>
        private static void processUserSelection(Employee[] employees)
        {
            DisplayEmployees(employees);
            Console.WriteLine("\n\nOperation starts from here:\n");
            DisplayMenu();
            while (true)
            {
                string choice = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("\nYou selected : " + choice);
                if (int.TryParse(choice, out int option) == false || option < 1 || option > 6)
                {
                    Console.WriteLine("\nPlease enter an integer beween 1 and 6");
                    Console.WriteLine("Enter choice:\n ");
                    continue;
                }
                if (option == 6)
                {
                    break;
                }
                else
                {
                    Sort(option, employees);
                }
                Console.WriteLine("\n**********************************************");
                DisplayMenu();
            }
        }
        /// <summary>
        /// Sort the employee's properties based on user's different selections
        /// </summary>
        /// <param name="option"></param>
        /// <param name="employees"></param>
        private static void Sort(int option, Employee[] employees)
        {
            if (option == 1)
            {
                SortName(employees);
            }
            else if (option == 2)
            {
                SortNumber(employees);
            }
            else if (option == 3)
            {
                SortRate(employees);
            }
            else if (option == 4)
            {
                SortHours(employees);
            }
            else
            {
                SortGrossPay(employees);
            }

        }
        /// <summary>
        /// Sort each employee's gross pay(descending) based on selection algorithm
        /// cite from : https://www.tutorialspoint.com/selection-sort-program-in-chash
        /// </summary>
        /// <param name="employees"></param>
        private static void SortGrossPay(Employee[] employees)
        {
            Employee temp;
            int max_index;
            for (int i = 0; i < employees.Length - 1; i++)
            {
                max_index = i;
                for (int j = i + 1; j < employees.Length; j++)
                {
                    if (employees[j].GetGross() > employees[max_index].GetGross())
                    {
                        max_index = j;
                    }
                }
                temp = employees[max_index];
                employees[max_index] = employees[i];
                employees[i] = temp;
            }
            Console.WriteLine("\nThis option is to descend employee's gross pay:");
            DisplayEmployees(employees);

        }
        /// <summary>
        /// Descending the employees' hours worked by using selection algorithm
        /// cite from : https://www.tutorialspoint.com/selection-sort-program-in-chash
        /// </summary>
        /// <param name="employees"></param>

        private static void SortHours(Employee[] employees)
        {
            Employee temp;
            int max_index;
            for (int i = 0; i < employees.Length - 1; i++)
            {
                max_index = i;
                for (int j = i + 1; j < employees.Length; j++)
                {
                    if (employees[j].GetHours() > employees[max_index].GetHours())
                    {
                        max_index = j;
                    }
                }
                temp = employees[max_index];
                employees[max_index] = employees[i];
                employees[i] = temp;
            }
            Console.WriteLine("\nThis option is to descend employee's hours:");
            DisplayEmployees(employees);
        }
        /// <summary>
        /// Descending employees' rate of pay via using insertion algorithm
        /// cite from:
        /// https://simplesnippets.tech/insertion-sort-algorithm-with-program-data-structures-algorithms/
        /// </summary>
        /// <param name="employees"></param>
        private static void SortRate(Employee[] employees)
        {
            Employee temp;
            for (int j = 1; j < employees.Length; j++)
            {
                temp = employees[j];
                int k = j - 1;
                while (k >= 0 && employees[k].GetRate() < temp.GetRate())
                {
                    employees[k + 1] = employees[k];
                    k -= 1;
                }
                employees[k + 1] = temp;
            }
            Console.WriteLine("\nThis option is to descend employee's rate");
            DisplayEmployees(employees);
        }
        /// <summary>
        /// Ascending employees' numbers via using selection algorithm
        /// cite from : https://www.tutorialspoint.com/selection-sort-program-in-chash
        /// </summary>
        /// <param name="employees"></param>
        private static void SortNumber(Employee[] employees)
        {
            Employee temp;
            int min_index;
            for (int i = 0; i < employees.Length - 1; i++)
            {
                min_index = i;
                for (int j = i + 1; j < employees.Length; j++)
                {
                    if (employees[j].GetNumber() < employees[min_index].GetNumber())
                    {
                        min_index = j;
                    }
                }
                temp = employees[min_index];
                employees[min_index] = employees[i];
                employees[i] = temp;
            }
            Console.WriteLine("\nThis option is to ascend employee's number:");
            DisplayEmployees(employees);
        }
        /// <summary>
        /// Ascending employees' names based on selection algorithm
        /// cite from : https://www.tutorialspoint.com/selection-sort-program-in-chash
        /// </summary>
        /// <param name="employees"></param>
        private static void SortName(Employee[] employees)
        {
            Employee temp;
            for (int p = 0; p < employees.Length; p++)
            {
                for (int q = p + 1; q < employees.Length; q++)
                {
                    if (employees[p].GetName().CompareTo(employees[q].GetName()) > 0)
                    {
                        temp = employees[p];
                        employees[p] = employees[q];
                        employees[q] = temp;
                    }
                }
            }
            Console.WriteLine("\nThis option is to ascend employee's name:");
            DisplayEmployees(employees);
        }
        /// <summary>
        /// Display the menu for user to choose 
        /// </summary>
        private static void DisplayMenu()
        {

            Console.WriteLine("1. Sort by Employee Name (ascending) ");
            Console.WriteLine("2. Sort by Employee Number (ascending) ");
            Console.WriteLine("3. Sort by Employee Pay Rate (descending) ");
            Console.WriteLine("4. Sort by Employee Hours (descending) ");
            Console.WriteLine("5. Sort by Employee Gross Pay (descending) ");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Enter choice:");
        }
        /// <summary>
        /// Print out each employee information with a title
        /// </summary>
        /// <param name="employees"></param>
        private static void DisplayEmployees(Employee[] employees)
        {
            Console.WriteLine("\nEmployee\tNumber\tRate\tHours\tGross Pay\t Nick's Company");
            Console.WriteLine("=============\t=======\t======\t=====\t=========\t---------------------");
            foreach (Employee element in employees)
            {
                Console.WriteLine(element);
            }
        }
        /// <summary>
        /// Create an employees array based on a text file. If file cannot be found
        /// or data inside is not valid, an exception will handle those problems. 
        /// </summary>
        /// <returns>Employee[]</returns>

        private static Employee[] Read()
        {
            Employee[] employees = new Employee[100];
            FileStream fs = null;
            StreamReader sr = null;
            int count = 0;
            try
            {
                fs = new FileStream("employees.txt", FileMode.Open);
                sr = new StreamReader(fs);

                while (!sr.EndOfStream && count < employees.Length)
                {
                    string input = sr.ReadLine();
                    string[] elements = input.Split(',');
                    string name = elements[0];
                    if (int.TryParse(elements[1], out int number) == false)
                    {
                        Console.WriteLine("Failed to parse the number from the file!");

                    }
                    if (decimal.TryParse(elements[2], out decimal rate) == false)
                    {
                        Console.WriteLine("Failed to parse the rate from the file!");
                    }
                    if (double.TryParse(elements[3], out double hours) == false)
                    {
                        Console.WriteLine("Failed to parse the hours from the file!");
                    }
                    employees[count] = new Employee(name, number, rate, hours);
                    count++;
                }
                /*create a new employee array, but the length depends on the number 
                  of rows in the text file. In addition, copy employees
                 information from original array to the new array*/



            }
            catch (Exception e)
            {
                Console.WriteLine("\nException loading employees from the file due to " +
                 e.Message);
                return null;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
                if (sr != null)
                {
                    sr.Close();
                }

            }
            Employee[] newEmployees = new Employee[count];
            for (int i = 0; i < count; i++)
            {
                newEmployees[i] = employees[i];
            }
            return newEmployees;

        }
    }
}



