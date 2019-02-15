using Buying_car.Factory;
using Buying_car.Links;
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

            // ModelToyota userModel = new ModelToyota();
            // userModel.GetCurrentPrice(userUrl);

            ModelNissan nissan = new ModelNissan();

            nissan.GetCurrentPrice(userUrl);

            Console.ReadLine();




        }

       

    }
}
