using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buying_car
{
    public class TrialDriveAutoGidas : ITrialDriveCostStrategy
    {

        public float Calculate(Order order)
        {
            return 100f;
        }

        public float Discount(Order discount)
        {
            return (float)15 / 100;
        }
    }
}
