using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buying_car
{
    public interface IShippingCostStrategy
    {
        decimal Calculate(Order order);
    }
}
