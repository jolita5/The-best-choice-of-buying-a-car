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
        private PaugeotSalon nissan = new PaugeotSalon();
        private ToyotaSalon toyota = new ToyotaSalon();
        private Button btn = new Button();
        private CarFactory factory = new CarFactory();
        ModelAutoGidas userAutoGidas = new ModelAutoGidas();
        ModelPaugeot userNissan = new ModelPaugeot();
        ModelToyota userToyota = new ModelToyota();

        private ShoppingCart service;
        private ICar _car;
        private bool _isAnswerIncorrect = true;
        private string _userUrl;
        private decimal _hours;





        public void PrintUsersAnswer(int userChoice)
        {

            Console.WriteLine($"Please, choose one salon to open a website: \n 1) {SalonTypes.AutoGidas} - {autoGidas.Url}," +
                $" \n 2) {SalonTypes.Peugeot_Salon} - {nissan.Url} , \n 3) {SalonTypes.Toyota_Salon} - {toyota.Url}");

            userChoice = Convert.ToInt32(Console.ReadLine());
            bool isInCorrect = true;

            while (isInCorrect)
            {
                try
                {
                    GetUsersChoisenSalon(userChoice);
                    GetTotalPrise(userChoice);
                    isInCorrect = false;
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    userChoice = Convert.ToInt32(Console.ReadLine());

                }
            }


        }



        private void GetUsersChoisenSalon(int userSalon)
        {



            do
            {

                switch (userSalon)
                {
                    case 1:
                        btn.MessageEncoded += autoGidas.RichTextBox_LinkClicked;
                        btn.DoubleClick(autoGidas.Url);

                        _car = factory.CreateCarShop(SalonTypes.AutoGidas);
                        _car.Start();

                        _isAnswerIncorrect = false;
                        break;
                    case 2:
                        btn.MessageEncoded += nissan.RichTextBox_LinkClicked;
                        btn.DoubleClick(nissan.Url);

                        _car = factory.CreateCarShop(SalonTypes.Peugeot_Salon);
                        _car.Start();

                        _isAnswerIncorrect = false;
                        break;
                    case 3:
                        btn.MessageEncoded += toyota.RichTextBox_LinkClicked;
                        btn.DoubleClick(toyota.Url);

                        _car = factory.CreateCarShop(SalonTypes.Toyota_Salon);
                        _car.Start();

                        _isAnswerIncorrect = false;
                        break;
                    default:
                        Console.WriteLine("This choice doesn't exist! Please, try again!");
                        userSalon = Convert.ToInt32(Console.ReadLine());
                        break;
                }

            }
            while (_isAnswerIncorrect);

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
            Console.WriteLine("How many hours would you like to take for the trial drive?");
            _hours = Convert.ToDecimal(Console.ReadLine());

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
                            Console.WriteLine($"Trial drive 1 h: {service.Order(new Order())} Eur.");
                            check = false;
                            Console.WriteLine($"Trial drive {_hours} h: {service.AddPrice(new Order() { Hour = (_hours * service.Order(new Order())/10) })} Eur.");
                            break;
                        case 2:
                            service = new ShoppingCart(new TrialDrivePaugeotSalon());
                            userNissan.GetCurrentPriceAndModel(_userUrl);
                            Console.WriteLine($"Trial drive 1 h: {service.Order(new Order())} Eur.");
                            Console.WriteLine($"Trial drive {_hours} h: {service.AddPrice(new Order() { Hour = (_hours * service.Order(new Order())/10) })} Eur.");
                            check = false;
                            break;
                        case 3:
                            service = new ShoppingCart(new TrialDriveToyotaSalon());
                            userToyota.GetCurrentPriceAndModel(_userUrl);
                            Console.WriteLine($"Trial drive 1 h: {service.Order(new Order())} Eur.");
                            Console.WriteLine($"Trial drive {_hours} h: {service.AddPrice(new Order() { Hour = (_hours * service.Order(new Order())/10)}) } Eur.");
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




    }
}
