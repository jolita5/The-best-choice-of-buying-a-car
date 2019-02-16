using Buying_car.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Buying_car
{
    public class Controller
    {
        private AutoGidas bmw = new AutoGidas();
        private NissanSalon audi = new NissanSalon();
        private ToyotaSalon toyota = new ToyotaSalon();
        private Button btn = new Button();
        private CarFactory factory = new CarFactory();
        ModelAutoGidas autogidas = new ModelAutoGidas();

        private ShoppingCart service;
        private ICar _obj;
        private bool _isAnswerIncorrect = true;
        private int _userChoice;
        private string _model;
        private string _userUrl;



        public void GetUsersChoice()
        {
            PrintUsersAnswer();

        }


        private void PrintUsersAnswer()
        {

            Console.WriteLine($"Please, choose one salon to open a website: \n 1) {SalonTypes.AutoGidas} - {bmw.Url}," +
                $" \n 2) {SalonTypes.Nissan_Salon} - {audi.Url} , \n 3) {SalonTypes.Toyota_Salon} - {toyota.Url}");

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




        public static bool IsValidURL(string url)
        {
            WebRequest webRequest = WebRequest.Create(url);
            WebResponse webResponse;
            try
            {
                webResponse = webRequest.GetResponse();
            }
            catch 
            {
                return false;
            }

            return true;
        }



        private void GetTotalPrise(int userChoice)
        {

            Console.WriteLine("Enter the link of car model you have chosen:");
           _userUrl = Console.ReadLine();


            if (IsValidURL(_userUrl) == true)
            {
                switch (userChoice)
                {
                    case 1:
                        service = new ShoppingCart(new ShippingAutoGidas());
                        autogidas.GetModelName(_userUrl);
                        autogidas.GetCurrentPrice(_userUrl);
                        Console.WriteLine("Shipping price: " + service.Order(new Order(), _carPrice) + " Eur.");
                        Console.WriteLine("Total price: " + service.AddPrice(new Order() { TotalPrice = _carPrice }, _carPrice) + " Eur.");
                        break;
                    case 2:
                        service = new ShoppingCart(new ShippingAudiSalon());
                        Console.WriteLine(_model + "\nCar price: " + _carPrice + " Eur.");
                        Console.WriteLine("Shipping price: " + service.Order(new Order(), _carPrice) + " Eur.");
                        Console.WriteLine("Total price: " + service.AddPrice(new Order() { TotalPrice = _carPrice }, _carPrice) + " Eur.");
                        break;
                    case 3:
                        service = new ShoppingCart(new ShippingToyotaSalon());
                        Console.WriteLine(_model + "\nCar price: " + _carPrice + " Eur.");
                        Console.WriteLine("Shipping price: " + service.Order(new Order(), _carPrice) + " Eur.");
                        Console.WriteLine("Total price: " + service.AddPrice(new Order() { TotalPrice = _carPrice }, _carPrice) + " Eur.");
                        break;

                }
            }
            else
            {
                Console.WriteLine("Link don't exist! Please, check the link.");
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

                        _obj = factory.CreateCarShop(SalonTypes.AutoGidas);
                        _obj.Start();

                        _isAnswerIncorrect = false;
                        break;
                    case 2:
                        btn.MessageEncoded += audi.RichTextBox_LinkClicked;
                        btn.DoubleClick(audi.Url);

                        _obj = factory.CreateCarShop(SalonTypes.Nissan_Salon);
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
