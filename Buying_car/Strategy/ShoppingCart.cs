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


        public float AddPrice(Order order)
        {
            return order.TotalPriceTrialDrive - DiscountEur(order);
        }


        public float DiscountEur(Order order)
        {
            return order.TotalPriceTrialDrive *= _trialDriveStrategy.Discount(order);
        }


        public float Order(Order order)
        {
            return _trialDriveStrategy.Calculate(order);
        }

        public float Discount(Order order)
        {
            return _trialDriveStrategy.Discount(order);
        }

    }
}
