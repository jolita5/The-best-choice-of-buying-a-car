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
            int userChoice = 0;
            Controller user = new Controller();

            //  user.PrintUsersAnswer(userChoice);
            Console.WriteLine("Enter the link of car model you have chosen:");
            string userUrl = Console.ReadLine();

            ModelPaugeot userNissan = new ModelPaugeot();
            userNissan.GetCurrentPriceAndModel(userUrl);


            Console.ReadLine();




        }



    }
}
