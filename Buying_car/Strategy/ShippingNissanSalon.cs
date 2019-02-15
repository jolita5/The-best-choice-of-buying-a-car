using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buying_car
{
    public class ShippingAudiSalon: IShippingCostStrategy
    {

        public decimal Calculate(Order order, decimal carPrice)
        {

            if(carPrice < 20000)
            {
                return 30;
            }
            else if(carPrice >= 20000 && carPrice < 30000)
            {
                return 25;
            }
            else if(carPrice >= 30000)
            {
                return 20;
            }


            return 0;
        }
    }
}
