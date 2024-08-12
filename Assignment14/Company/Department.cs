using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment14.Company
{
    class Department
    {
   
        #region Properties
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        #endregion


        #region StoringList
        // List to store the staff members of the department
        private List<Employee> Staff = new List<Employee>();
        #endregion


        #region  Method to add a new employee to the department
        public void AddStaff(Employee E)
        {
            // Add the employee to the Staff list
            Staff.Add(E);

            // Register the RemoveStaff method as an event handler
            // for the EmployeeLayOff event. This ensures that the
            // RemoveStaff method is called when the employee triggers
            // the layoff event.
            E.EmployeeLayOff += RemoveStaff;
        }

        // Callback method to remove an employee from the department if they are laid off
        private void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
        {
            // Check if the layoff cause is either due to age limit or negative vacation stock
            if (e.Cause == LayOffCause.AgeLimit || e.Cause == LayOffCause.NegativeVacationStock)
            {
                // Remove the employee from the Staff list
                Staff.Remove(sender as Employee);
            }
        } 
        #endregion
    }

}
