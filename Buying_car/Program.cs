using Buying_car.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buying_car
{
    class Program
    {
        static void Main(string[] args)
        {
            CarFactory factory = new CarFactory();
            ICar obj = factory.CreateCarShop(Console.ReadLine());
            obj.Start();


            Console.ReadLine();
        }
    }
}
