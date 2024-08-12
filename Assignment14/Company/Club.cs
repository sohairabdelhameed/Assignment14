using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment14.Company
{
    class Club
    {
        #region Properties
       
        public int ClubID { get; set; }
        public string ClubName { get; set; }
        #endregion

        #region storingList
        // List to store the members of the club
        private List<Employee> Members = new List<Employee>(); 
        #endregion

        #region Method to add a new member to the club

        public void AddMember(Employee E)
        {
            // Add the employee to the Members list
            Members.Add(E);

            // Register the RemoveMember method as an event handler
            // for the EmployeeLayOff event. This will ensure that
            // the RemoveMember method is called when the employee
            // triggers the layoff event.
            E.EmployeeLayOff += RemoveMember;
        }

        // Callback method to remove a member from the club if they are laid off
        private void RemoveMember(object sender, EmployeeLayOffEventArgs e)
        {
            // Check if the layoff cause is due to negative vacation stock
            if (e.Cause == LayOffCause.NegativeVacationStock)
            {
                // Remove the employee from the Members list
                Members.Remove(sender as Employee);
            }
        } 
        #endregion
    }


}
