using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment14.Company
{
    class SalesPerson : Employee
    {
      
        #region Property
        public int AchievedTarget { get; set; }
        #endregion

        #region Method
        // Method to check if the salesperson has met the sales quota.
        // If the achieved target is less than the quota, it triggers the layoff process
        // by calling the OnEmployeeLayOff method and passing the reason as FailedSalesTarget.
        public bool CheckTarget(int Quota)
        {
            // If the achieved target is less than the required quota,
            // the salesperson is considered to have failed the target.
            if (AchievedTarget < Quota)
            {
                // Triggers the layoff process by invoking the OnEmployeeLayOff method.
                // The cause of layoff is specified as FailedSalesTarget.
                OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.FailedSalesTarget });
                return false; // Indicates that the target was not met.
            }
            return true; // Indicates that the target was met.
        }
    } 
    #endregion


}
