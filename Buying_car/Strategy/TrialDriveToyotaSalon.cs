using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buying_car
{
    public class TrialDriveToyotaSalon : ITrialDriveCostStrategy
    {

        public float Calculate(Order order)
        {

            return 50f;
        }

        public float Discount(Order discount)
        {
            return (float)5 / 100;
        }
    }
}
