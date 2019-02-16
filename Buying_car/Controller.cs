using Buying_car.Factory;
using Buying_car.Links;
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
        private AutoGidas autoGidas = new AutoGidas();
        private NissanSalon nissan = new NissanSalon();
        private ToyotaSalon toyota = new ToyotaSalon();
        private Button btn = new Button();
        private CarFactory factory = new CarFactory();
        ModelAutoGidas userAutoGidas = new ModelAutoGidas();
        ModelNissan userNissan = new ModelNissan();
        ModelToyota userToyota = new ModelToyota();

        private ShoppingCart service;
        private ICar _obj;
        private bool _isAnswerIncorrect = true;
        private int _userChoice;
        private string _userUrl;



        public void GetUsersChoice()
        {
            PrintUsersAnswer();

        }


        private void PrintUsersAnswer()
        {

            Console.WriteLine($"Please, choose one salon to open a website: \n 1) {SalonTypes.AutoGidas} - {autoGidas.Url}," +
                $" \n 2) {SalonTypes.Nissan_Salon} - {nissan.Url} , \n 3) {SalonTypes.Toyota_Salon} - {toyota.Url}");

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




        private bool IsValidURL(string url)
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
            bool check = true;

            Console.WriteLine();

            while(check)
            {
                if (IsValidURL(_userUrl) == true)
                {
                    switch (userChoice)
                    {
                        case 1:
                            service = new ShoppingCart(new TrialDriveAutoGidas());
                            userAutoGidas.GetCurrentPriceAndModel(_userUrl);
                            Console.WriteLine("Trial drive 1 h: " + service.Order(new Order()) + " Eur.");
                            check = false;
                            Console.WriteLine("Trial drive 2 h: " + service.AddPrice(new Order() { TotalPrice = 3 }) + " Eur.");
                            break;
                        case 2:
                            service = new ShoppingCart(new TrialDriveNissanSalon());
                            userNissan.GetCurrentPriceAndModel(_userUrl);
                            Console.WriteLine("Trial drive 1 h: " + service.Order(new Order()) + " Eur.");
                            Console.WriteLine("Trial drive 2 h: " + service.AddPrice(new Order() { TotalPrice = 3}) + " Eur.");
                            check = false;
                            break;
                        case 3:
                            service = new ShoppingCart(new TrialDriveToyotaSalon());
                            userToyota.GetCurrentPriceAndModel(_userUrl);
                            Console.WriteLine("Trial drive 1 h: " + service.Order(new Order()) + " Eur.");
                            Console.WriteLine("Trial drive 2 h: " + service.AddPrice(new Order() { TotalPrice = 3 }) + " Eur.");
                            check = false;
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Link don't exist! Please, check the link.");
                    _userUrl = Console.ReadLine();
                }

            }







        }




        private void GetUsersAnswer(int userChoice)
        {



            do
            {

                switch (userChoice)
                {
                    case 1:
                        btn.MessageEncoded += autoGidas.RichTextBox_LinkClicked;
                        btn.DoubleClick(autoGidas.Url);

                        _obj = factory.CreateCarShop(SalonTypes.AutoGidas);
                        _obj.Start();

                        _isAnswerIncorrect = false;
                        break;
                    case 2:
                        btn.MessageEncoded += nissan.RichTextBox_LinkClicked;
                        btn.DoubleClick(nissan.Url);

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
