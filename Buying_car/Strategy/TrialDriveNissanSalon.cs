using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buying_car
{
    public class TrialDriveNissanSalon: ITrialDriveCostStrategy
    {

        public decimal Calculate(Order order)
        {
            return 80;
        }
    }
}
