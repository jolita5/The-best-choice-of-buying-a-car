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
            BmwSalon bmw = new BmwSalon();
            AudiSalon audi = new AudiSalon();
            ToyotaSalon toyota = new ToyotaSalon();

            Console.WriteLine($"Please, choose one salon to review website: \n 1) BMW - {bmw.Url}, \n 2) AUDI -{audi.Url} , \n 3) TOYOTA - {toyota.Url}");

            string userChoice = Console.ReadLine();

            try
            {
                GetUsersAnswer(userChoice);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }




            Console.WriteLine();



            //CarFactory factory = new CarFactory();
            //ICar obj = factory.CreateCarShop(SalonTypes.Audi_Salon);
            //obj.Start();

            //var service = new ShoppingCart(new ShippingAudiSalon ());
            //System.Console.WriteLine(service.AddPrice(new Order() { TotalPrice = 2 }));
            //System.Console.WriteLine(service.Order(new Order()));

            Console.ReadLine();




        }

        public static void GetUsersAnswer(string userChoice)
        {
            BmwSalon bmw = new BmwSalon();
            AudiSalon audi = new AudiSalon();
            ToyotaSalon toyota = new ToyotaSalon();
            Button btn = new Button();


            bool isAnswerIncorrect = true;

            do
            {
                switch (userChoice)
                {
                    case "1":
                        btn.MessageEncoded += bmw.RichTextBox_LinkClicked;
                        btn.DoubleClick(bmw.Url);
                        isAnswerIncorrect = false;
                        break;
                    case "2":
                        btn.MessageEncoded += audi.RichTextBox_LinkClicked;
                        btn.DoubleClick(audi.Url);
                        isAnswerIncorrect = false;
                        break;
                    case "3":
                        btn.MessageEncoded += toyota.RichTextBox_LinkClicked;
                        btn.DoubleClick(toyota.Url);
                        isAnswerIncorrect = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect choice! Please, try again!");
                        userChoice = Console.ReadLine();
                        break;
                }

                if (!int.TryParse(userChoice, out value))
                {
                    throw new ArgumentException("Wrong format! Please, enter the number!");
                }
            }
            while (isAnswerIncorrect);

           
        }


    }
}
