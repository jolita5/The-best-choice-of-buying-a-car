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

            // user.GetUsersChoice();

            Console.WriteLine("Enter Link:");
            string userUrl = Console.ReadLine();

            UsersModelToyota userModel = new UsersModelToyota();




            userModel.GetCurrentPrice(userUrl);

            Console.ReadLine();




        }

       

    }
}
