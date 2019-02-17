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

            user.PrintUsersAnswers();



            Console.ReadLine();


        }

    }
}
