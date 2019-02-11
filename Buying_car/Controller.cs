using Buying_car.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buying_car
{
    public class Controller
    {
        private BmwSalon bmw = new BmwSalon();
        private AudiSalon audi = new AudiSalon();
        private ToyotaSalon toyota = new ToyotaSalon();
        private Button btn = new Button();
        private bool _isAnswerIncorrect = true;
        private CarFactory factory = new CarFactory();
        private ShoppingCart service;
        private ICar _obj;
        private int _userChoice;



        public void GetUsersChoice()
        {
            PrintUsersAnswer();
          //  PrintTotalPrice(_userChoice);

        }


        private void PrintUsersAnswer()
        {

            Console.WriteLine($"Please, choose one salon to open a website: \n 1) {SalonTypes.Bmw_Salon} - {bmw.Url}," +
                $" \n 2) {SalonTypes.Audi_Salon} - {audi.Url} , \n 3) {SalonTypes.Toyota_Salon} - {toyota.Url}");

            _userChoice = Convert.ToInt32(Console.ReadLine());


            while (_isAnswerIncorrect)
            {
                try
                {
                    GetUsersAnswer(_userChoice);
                    _isAnswerIncorrect = false;
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    _userChoice = Convert.ToInt32(Console.ReadLine());
                }
            }

            GetTotalPrise(_userChoice);

        }



        private void GetTotalPrise(int userChoice)
        {
            Console.WriteLine("Enter the model, you have chosen:");
            string model = Console.ReadLine();
            Console.WriteLine("Enter the price of your chosen car model:");
            decimal cost = Convert.ToDecimal(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                    service = new ShoppingCart(new ShippingBmwSalon());
                    Console.WriteLine(model + "\nCar price: " + cost + " Eur.");
                    Console.WriteLine("Shipping price: " + service.Order(new Order()) + " Eur.");
                    Console.WriteLine("Total price: " + service.AddPrice(new Order() { TotalPrice = cost }) + " Eur.");
                    break;
                case 2:
                    service = new ShoppingCart(new ShippingAudiSalon());
                    Console.WriteLine(model + "\nCar price: " + cost + " Eur.");
                    Console.WriteLine("Shipping price: " + service.Order(new Order()) + " Eur.");
                    Console.WriteLine("Total price: " + service.AddPrice(new Order() { TotalPrice = cost }) + " Eur.");
                    break;
                case 3:
                    service = new ShoppingCart(new ShippingToyotaSalon());
                    Console.WriteLine(model + "\nCar price: " + cost + " Eur.");
                    Console.WriteLine("Shipping price: " + service.Order(new Order()) + " Eur.");
                    Console.WriteLine("Total price: " + service.AddPrice(new Order() { TotalPrice = cost }) + " Eur.");
                    break;

            }


        }




        private void GetUsersAnswer(int userChoice)
        {



            do
            {

                switch (userChoice)
                {
                    case 1:
                        btn.MessageEncoded += bmw.RichTextBox_LinkClicked;
                        btn.DoubleClick(bmw.Url);

                        _obj = factory.CreateCarShop(SalonTypes.Bmw_Salon);
                        _obj.Start();

                        _isAnswerIncorrect = false;
                        break;
                    case 2:
                        btn.MessageEncoded += audi.RichTextBox_LinkClicked;
                        btn.DoubleClick(audi.Url);

                        _obj = factory.CreateCarShop(SalonTypes.Audi_Salon);
                        _obj.Start();

                        _isAnswerIncorrect = false;
                        break;
                    case 3:
                        btn.MessageEncoded += toyota.RichTextBox_LinkClicked;
                        btn.DoubleClick(toyota.Url);

                        _obj = factory.CreateCarShop(SalonTypes.Toyota_Salon);
                        _obj.Start();

                        _isAnswerIncorrect = false;
                        break;
                    default:
                        Console.WriteLine("This choice doesn't exist! Please, try again!");
                        userChoice = Convert.ToInt32(Console.ReadLine());
                        break;
                }

            }
            while (_isAnswerIncorrect);

        }

    }
}
