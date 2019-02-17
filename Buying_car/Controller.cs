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
        private ModelAutoGidas userAutoGidas = new ModelAutoGidas();
        private ModelPaugeot userPaugeot = new ModelPaugeot();
        private ModelToyota userToyota = new ModelToyota();
        private ShoppingCart _service;
        private ICar _car;




        public void PrintUsersAnswers()
        {
            Console.WriteLine($"Please, choose one salon to open a website: \n 1) {SalonTypes.AutoGidas} - {autoGidas.Url}" +
             $" \n 2) {SalonTypes.Peugeot_Salon} - {nissan.Url} \n 3) {SalonTypes.Toyota_Salon} - {toyota.Url}");

            int userChoice = Convert.ToInt32(Console.ReadLine());

            bool isInCorrect = true;

            while (isInCorrect)
            {
                try
                {
                    GetUsersChoisenSalon(userChoice);
                    isInCorrect = false;
                }
                catch (Exception ex)
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(ex.Message);

                }


            }

            Console.WriteLine("\nPlease, enter a link of car model you have chosen:");
            string userUrl = Console.ReadLine();

            while (isInCorrect)
            {
                try
                {
                    GetModelInfo(userChoice, userUrl);
                    isInCorrect = false;
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    userUrl = Console.ReadLine();

                }


            }

            Console.WriteLine("\nWould you like to take a trial drive? Please, enter 'yes' or 'no'?");
            string answer = Console.ReadLine();


            while (isInCorrect)
            {
                try
                {
                    GetTrialDrivePrice(userChoice, answer);
                    isInCorrect = false;
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    answer = Console.ReadLine();

                }


            }

            Console.WriteLine("Have a nice day!");


        }



        private void GetUsersChoisenSalon(int userSalon)
        {
            bool _isAnswerIncorrect = true;

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



        private void GetModelInfo(int userChoice, string userUrl)
        {


            bool isLinkUnvalid = true;

            while (isLinkUnvalid)
            {
                if (IsValidURL(userUrl) == true)
                {
                    switch (userChoice)
                    {
                        case 1:
                            userAutoGidas.GetCurrentPriceAndModel(userUrl);
                            isLinkUnvalid = false;
                            break;
                        case 2:
                            userPaugeot.GetCurrentPriceAndModel(userUrl);
                            isLinkUnvalid = false;
                            break;
                        case 3:
                            userToyota.GetCurrentPriceAndModel(userUrl);
                            isLinkUnvalid = false;
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Link don't exist! Please, check the link.");
                    userUrl = Console.ReadLine();
                }

            }

        }



        private void GetTrialDrivePrice(int userChoice, string answer)
        {

            bool isLinkUnvalid = true;


            while (isLinkUnvalid)
            {
                if (answer == "yes")
                {
                    switch (userChoice)
                    {
                        case 1:
                            _service = new ShoppingCart(new TrialDriveAutoGidas());
                            Console.WriteLine($"Trial drive price: {_service.Order(new Order())} Eur.");
                            PrintColor(ConsoleColor.Red, $"Trial drive price with {_service.Discount(new Order())} % discount: { _service.AddPrice(new Order() { TotalPriceTrialDrive = _service.Order(new Order()) })} Eur.");
                            Console.ResetColor();
                            isLinkUnvalid = false;
                            break;
                        case 2:
                            _service = new ShoppingCart(new TrialDrivePaugeotSalon());
                            Console.WriteLine($"Trial drive price: {_service.Order(new Order())} Eur.");
                            PrintColor(ConsoleColor.Red, $"Trial drive price with {_service.Discount(new Order())} % discount: { _service.AddPrice(new Order() { TotalPriceTrialDrive = _service.Order(new Order()) })} Eur.");
                            Console.ResetColor();
                            isLinkUnvalid = false;
                            break;
                        case 3:
                            _service = new ShoppingCart(new TrialDriveToyotaSalon());
                            Console.WriteLine($"Trial drive price: {_service.Order(new Order())} Eur.");
                            PrintColor(ConsoleColor.Red, $"Trial drive price with {_service.Discount(new Order())} % discount: { _service.AddPrice(new Order() { TotalPriceTrialDrive = _service.Order(new Order()) })} Eur.");
                            Console.ResetColor();
                            isLinkUnvalid = false;
                            break;

                    }
                }
                else if (answer == "no")
                {
                    Console.WriteLine("No trial Drive!");
                    isLinkUnvalid = false;

                }
                else
                {
                    Console.WriteLine("This choice doesn't exist! Please, enter 'yes' or 'no'.");
                    answer = Console.ReadLine();
                }

            }


        }

        private void PrintColor(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

    }
}
