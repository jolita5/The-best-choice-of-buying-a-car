using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buying_car.Factory
{
    public class CarFactory
    {

        public ICar CreateCarShop(SalonTypes car)
        {
            switch (car)
            {
                case SalonTypes.Bmw_Salon:
                   return new BmwSalon();
                case SalonTypes.Nissan_Salon:
                   return new NissanSalon();
                case SalonTypes.Toyota_Salon:
                    return new ToyotaSalon();
                default:
                    return null;
            }

        }
    }
}
