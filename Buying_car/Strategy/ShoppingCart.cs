using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buying_car
{
    public class ShoppingCart
    {
        private readonly IShippingCostStrategy _shippingStrategy;


        public ShoppingCart(IShippingCostStrategy shippingStrategy)
        {
            _shippingStrategy = shippingStrategy;
        }


        public decimal AddPrice(Order order)
        {
            return order.TotalPrice += _shippingStrategy.Calculate(order);
        }


        public decimal Order(Order order)
        {
            return _shippingStrategy.Calculate(order);
        }
    }
}
