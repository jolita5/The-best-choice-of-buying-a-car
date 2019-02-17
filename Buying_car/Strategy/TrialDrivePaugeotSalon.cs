using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buying_car
{
    public class TrialDrivePaugeotSalon : ITrialDriveCostStrategy
    {

        public float Calculate(Order order)
        {
            return 80f;
        }

        public float Discount(Order discount)
        {
            return (float)20 / 100;
        }
    }
}
