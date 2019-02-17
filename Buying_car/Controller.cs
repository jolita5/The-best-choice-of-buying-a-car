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
        private ModelPaugeot userNissan = new ModelPaugeot();
        private ModelToyota userToyota = new ModelToyota();
        private ShoppingCart service;
        private ICar _car;
        private bool _isAnswerIncorrect = true;
        private string _userUrl;




        public void PrintUsersAnswer(int userChoice)
        {

            Console.WriteLine($"Please, choose one salon to open a website: \n 1) {SalonTypes.AutoGidas} - {autoGidas.Url}" +
                $" \n 2) {SalonTypes.Peugeot_Salon} - {nissan.Url} \n 3) {SalonTypes.Toyota_Salon} - {toyota.Url}");

            userChoice = Convert.ToInt32(Console.ReadLine());
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


            try
            {
                GetTotalPrise(userChoice);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
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

            Console.WriteLine("Please, enter a link of car model you have chosen:");
            _userUrl = Console.ReadLine();

            Console.WriteLine("\n Would you like to take a trial drive? Please, enter 'yes' or 'no'?");
            string answer = Console.ReadLine();

            bool isLinkUnvalid = true;

            Console.WriteLine();

            while (isLinkUnvalid)
            {
                if (IsValidURL(_userUrl) == true)
                {
                    switch (userChoice)
                    {
                        case 1:
                            service = new ShoppingCart(new TrialDriveAutoGidas());
                            userAutoGidas.GetCurrentPriceAndModel(_userUrl);
                            Console.WriteLine($"Trial drive price: {service.Order(new Order())} Eur.");
                            Console.WriteLine($"Trial drive price with {service.Discount(new Order())} % discount: { CalculateTrialDrivePrice(answer)} Eur.");
                            isLinkUnvalid = false;
                            break;
                        case 2:
                            service = new ShoppingCart(new TrialDrivePaugeotSalon());
                            userNissan.GetCurrentPriceAndModel(_userUrl);
                            Console.WriteLine($"Trial drive price: {service.Order(new Order())} Eur.");
                            Console.WriteLine($"Trial drive price with {service.Discount(new Order())} % discount: { CalculateTrialDrivePrice(answer)} Eur.");
                            isLinkUnvalid = false;
                            break;
                        case 3:
                            service = new ShoppingCart(new TrialDriveToyotaSalon());
                            userToyota.GetCurrentPriceAndModel(_userUrl);
                            Console.WriteLine($"Trial drive price: {service.Order(new Order())} Eur.");
                            Console.WriteLine($"Trial drive price with {service.Discount(new Order())} % discount: { CalculateTrialDrivePrice(answer)} Eur.");
                            isLinkUnvalid = false;
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

        private float CalculateTrialDrivePrice(string answer)
        {

            switch (answer)
            {

                case "yes":
                    return service.AddPrice(new Order() {TotalPriceTrialDrive = service.Order(new Order()) });
                case "no":
                    return 0;
                default:
                    Console.WriteLine("Please, enter 'yes' or 'no'!");
                    answer = Console.ReadLine();
                    break;

            }
            return 0;

        }

    }
}
