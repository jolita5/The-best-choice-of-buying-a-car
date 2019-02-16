using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buying_car
{
    public class ShippingAutoGidas: IShippingCostStrategy
    {

        public decimal Calculate(Order order, decimal carPrice)
        {
            if (carPrice < 20000)
            {
                return 40;
            }
            else if (carPrice >= 20000 && carPrice < 30000)
            {
                return 35;
            }
            else if (carPrice >= 30000)
            {
                return 25;
            }


            return 0;
        }
    }
}
