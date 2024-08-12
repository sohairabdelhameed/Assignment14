using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment14.Company
{
    class Employee
    {
        #region Properties
        public int EmployeeID { get; set; }


        private DateTime _birthDate;


        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        private int _vacationStock;


        public int VacationStock
        {
            get { return _vacationStock; }
            set { _vacationStock = value; }

            #endregion}
             
       #region EventTrigger
            // Event triggered when an employee is laid off

        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;
        #endregion

        #region Methods
        protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            // Invoke the event if there are any subscribers
            EmployeeLayOff?.Invoke(this, e);
        }
        // Method to request a vacation for a certain period
        public bool RequestVacation(DateTime from, DateTime to)
        {
            // Calculate the number of days requested for the vacation
            int daysRequested = (to - from).Days;

            // Check if there are enough vacation days available
            if (_vacationStock >= daysRequested)
            {
                // Deduct the requested days from the vacation stock
                _vacationStock -= daysRequested;
                return true; // Vacation request approved
            }
            else
            {
                return false; // Vacation request denied due to insufficient days
            }
        }

        // Method to perform end-of-year operations, such as checking layoff conditions
        public void EndOfYearOperation()
        {
            // Check if the vacation stock is negative, which triggers a layoff
            if (_vacationStock < 0)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.NegativeVacationStock });
            }

            // Calculate the employee's age based on their birthdate
            int age = DateTime.Now.Year - BirthDate.Year;

            // Adjust age if the employee's birthday hasn't occurred yet this year
            if (BirthDate > DateTime.Now.AddYears(-age)) age--;

            // Check if the employee is over 60 years old, which triggers a layoff
            if (age > 60)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.AgeLimit });
            }
        } 
        #endregion
    }


}
