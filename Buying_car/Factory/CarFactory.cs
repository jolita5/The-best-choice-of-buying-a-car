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
                case SalonTypes.AutoGidas:
                   return new AutoGidas();
                case SalonTypes.Peugeot_Salon:
                   return new PaugeotSalon();
                case SalonTypes.Toyota_Salon:
                    return new ToyotaSalon();
                default:
                    return null;
            }

        }
    }
}
