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

            string userChoice = Console.ReadLine();


            bool check = true;

            while(check)
            {
                try
                {
                    GetUsersChoisenSalon(userChoice);
                    check = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    userChoice = Console.ReadLine();
                }
            }
            


        }



        private void GetUsersChoisenSalon(string userSalon)
        {
            bool _isAnswerIncorrect = true;
            int nr = 0;

            do
            {

                switch (userSalon)
                {
                    case "1":
                        btn.MessageEncoded += autoGidas.RichTextBox_LinkClicked;
                        btn.DoubleClick(autoGidas.Url);

                        _car = factory.CreateCarShop(SalonTypes.AutoGidas);
                        _car.Start();

                        _isAnswerIncorrect = false;
                        break;
                    case "2":
                        btn.MessageEncoded += nissan.RichTextBox_LinkClicked;
                        btn.DoubleClick(nissan.Url);

                        _car = factory.CreateCarShop(SalonTypes.Peugeot_Salon);
                        _car.Start();

                        _isAnswerIncorrect = false;
                        break;
                    case "3":
                        btn.MessageEncoded += toyota.RichTextBox_LinkClicked;
                        btn.DoubleClick(toyota.Url);

                        _car = factory.CreateCarShop(SalonTypes.Toyota_Salon);
                        _car.Start();

                        _isAnswerIncorrect = false;
                        break;
                    default:

                        if (!Int32.TryParse(userSalon, out nr))
                        {
                            throw new Exception("Input is incorrect format! Please, enter a number: 1, 2 or 3.");
                        }

                        Console.WriteLine("This choice doesn't exist! Please, try again!");
                        userSalon = Console.ReadLine();
                        break;
                }



            }
            while (_isAnswerIncorrect);





            GetModelInfo(userSalon);

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



        private void GetModelInfo(string userChoice)
        {

            Console.WriteLine("\nPlease, enter a link of car model you have chosen:");
            string userUrl = Console.ReadLine();

            bool isLinkUnvalid = true;

            while (isLinkUnvalid)
            {
                if (IsValidURL(userUrl) == true)
                {
                    switch (userChoice)
                    {
                        case "1":
                            userAutoGidas.GetCurrentPriceAndModel(userUrl);
                            isLinkUnvalid = false;
                            break;
                        case "2":
                            userPaugeot.GetCurrentPriceAndModel(userUrl);
                            isLinkUnvalid = false;
                            break;
                        case "3":
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

            GetTrialDrivePrice(userChoice);

        }



        private void GetTrialDrivePrice(string userChoice)
        {
            Console.WriteLine("\nWould you like to take a trial drive? Please, enter 'yes' or 'no'?");
            string answer = Console.ReadLine();

            bool isIncorrect = true;


            while (isIncorrect)
            {
                if (answer == "yes")
                {
                    switch (userChoice)
                    {
                        case "1":
                            _service = new ShoppingCart(new TrialDriveAutoGidas());
                            Console.WriteLine($"Trial drive price: {_service.Order(new Order())} Eur.");
                            PrintColor(ConsoleColor.Red, $"Trial drive price with {_service.Discount(new Order())} % discount: { _service.AddPrice(new Order() { TotalPriceTrialDrive = _service.Order(new Order()) })} Eur.");
                            Console.ResetColor();
                            isIncorrect = false;
                            break;
                        case "2":
                            _service = new ShoppingCart(new TrialDrivePaugeotSalon());
                            Console.WriteLine($"Trial drive price: {_service.Order(new Order())} Eur.");
                            PrintColor(ConsoleColor.Red, $"Trial drive price with {_service.Discount(new Order())} % discount: { _service.AddPrice(new Order() { TotalPriceTrialDrive = _service.Order(new Order()) })} Eur.");
                            Console.ResetColor();
                            isIncorrect = false;
                            break;
                        case "3":
                            _service = new ShoppingCart(new TrialDriveToyotaSalon());
                            Console.WriteLine($"Trial drive price: {_service.Order(new Order())} Eur.");
                            PrintColor(ConsoleColor.Red, $"Trial drive price with {_service.Discount(new Order())} % discount: { _service.AddPrice(new Order() { TotalPriceTrialDrive = _service.Order(new Order()) })} Eur.");
                            Console.ResetColor();
                            isIncorrect = false;
                            break;

                    }
                }
                else if (answer == "no")
                {
                    Console.WriteLine("No trial Drive!");
                    isIncorrect = false;

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
