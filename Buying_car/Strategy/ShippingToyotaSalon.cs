using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buying_car
{
    public class ShippingToyotaSalon: IShippingCostStrategy
    {

        public decimal Calculate(Order order, decimal carPrice)
        {
            if (carPrice < 20000)
            {
                return 20;
            }
            else if (carPrice >= 20000 && carPrice < 30000)
            {
                return 15;
            }
            else if (carPrice >= 30000)
            {
                return 10;
            }


            return 0;
        }
    }
}
