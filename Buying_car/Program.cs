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

            Controller user = new Controller();

            user.PrintUsersAnswer();



            //var service = new ShoppingCart(new ShippingAudiSalon ());
            //System.Console.WriteLine(service.AddPrice(new Order() { TotalPrice = 2 }));
            //System.Console.WriteLine(service.Order(new Order()));

            Console.ReadLine();




        }

       

    }
}
