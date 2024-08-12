using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment14.Company
{
    class BoardMember : Employee
    {
        public void Resign()
        {
            // Trigger the EmployeeLayOff event, indicating that the layoff is due to resignation.
            // This will notify any registered handlers [departments or clubs] that this
            // employee is resigning from their position.
            OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.Resignation });
        }

    }

}
