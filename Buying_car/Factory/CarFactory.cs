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
                case SalonTypes.Audi_Salon:
                   return new AudiSalon();
                case SalonTypes.Auto_Market:
                    return new ToyotaSalon();
                default:
                    return null;
            }

        }
    }
}
