using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assig_1
{
    /// <summary>
    /// Author: Zhiping Yu  Student number: 000822513   Sep 24,2020
    /// This class is a model class. Other class can call its construtor to create 
    /// employee objects and call other methods if necessary.
    /// 
    /// I, Zhiping Yu, 000822513 certify that this material is my original work.  
    /// No other person's work has been used without due acknowledgement.
    /// </summary>
    class Employee
    {
        /*Declare instance variables of Employee class*/
        private string name;
        private int number;
        private decimal rate;
        private double hours;
        private decimal gross;
        /// <summary>
        /// Constructor  inializes instance variables
        /// </summary>
        /// <param name="name">employee's name</param>
        /// <param name="number">employee's number</param>
        /// <param name="rate">employee's rate of pay</param>
        /// <param name="hours">tht number of hours employee worked</param>
        public Employee(string name, int number, decimal rate, double hours)
        {
            this.name = name;
            this.number = number;
            this.rate = rate;
            this.hours = hours;

        }
        /// <summary>
        /// Calcaute the gross pay of an employee based on the hours the employee
        /// worked and the rate of pay 
        /// </summary>
        /// <returns>an employee's gross pay</returns>
        public decimal GetGross()

        {
            if (hours <= 40)

            {
                gross = (decimal)hours * rate;
                return gross;
            }
            else
            {
                gross = (decimal)(hours - 40) * rate * (decimal)(1.5) +
                    (40 * rate);
                return gross;
            }

        }
        /// <summary>
        /// Get the number of hours which an employee worked
        /// </summary>
        /// <returns>the number of hours worked</returns>

        public double GetHours()
        {
            return hours;
        }
        /// <summary>
        /// Get the name of an employee
        /// </summary>
        /// <returns>an employee's name</returns>
        public string GetName()
        {
            return name;
        }
        /// <summary>
        /// Get the rate of pay 
        /// </summary>
        /// <returns>an employee's rate of pay</returns>
        public decimal GetRate()
        {
            return rate;
        }
        /// <summary>
        /// Get the number of an employee
        /// </summary>
        /// <returns>an employee's number</returns>
        public int GetNumber()
        {
            return number;
        }
        /// <summary>
        /// Override ToString() method and provide the formatted fields of an employee
        /// </summary>
        /// <returns>the representation of an employee</returns>
        public override string ToString()
        {
            return $"{name}\t{number}\t${rate}\t" + string.Format("{0:0.00}\t", GetHours()) + string.Format("${0:0,0.00}", GetGross());
            //return $"{name,15}{number,10}{rate,10:C}{hours,10}{GetGross(),15:C}";

        }
        /// <summary>
        /// Provides value for the number of hours an employee worked
        /// </summary>
        /// <param name="hours"></param>
        public void SetHours(double hours)
        {
            this.hours = hours;
        }
        /// <summary>
        /// Provides the name of an employee
        /// </summary>
        /// <param name="name"></param>
        public void SetName(string name)
        {
            this.name = name;
        }
        /// <summary>
        /// Provides an employee's number
        /// </summary>
        /// <param name="number"></param>
        public void SetNumber(int number)
        {
            this.number = number;
        }
        /// <summary>
        /// Provides an employee's rate of pay
        /// </summary>
        /// <param name="rate"></param>
        public void SetRate(decimal rate)
        {
            this.rate = rate;
        }
    }
}
