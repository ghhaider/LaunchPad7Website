using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launchpad
{
    public class Enums
    {
        public enum Status
        {
            Paid = 1,
            UnPaid = 2,
            Pending = 3
        }

        public enum PaymentMethod
        {
            Cash = 1,
            Cheque = 2
        }
        public enum Gender
        {
            Male,
            Female
        }
    }
}
