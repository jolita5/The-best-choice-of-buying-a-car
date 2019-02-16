using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buying_car
{
    public class ShoppingCart
    {
        private readonly ITrialDriveCostStrategy _trialDriveStrategy;


        public ShoppingCart(ITrialDriveCostStrategy shippingStrategy)
        {
            _trialDriveStrategy = shippingStrategy;
        }


        public decimal AddPrice(Order order)
        {
            return order.Hour += _trialDriveStrategy.Calculate(order);
        }


        public decimal Order(Order order)
        {
            return _trialDriveStrategy.Calculate(order);
        }
    }
}
