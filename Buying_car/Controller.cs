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




        public void PrintUsersAnswer()
        {

            Console.WriteLine($"Please, choose one salon to review website: \n 1) BMW - {bmw.Url}, \n 2) AUDI -{audi.Url} , \n 3) TOYOTA - {toyota.Url}");

            int userChoice = Convert.ToInt32(Console.ReadLine());


            while (_isAnswerIncorrect)
            {
                try
                {
                    GetUsersAnswer(userChoice);
                    _isAnswerIncorrect = false;
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    userChoice = Convert.ToInt32(Console.ReadLine());
                }
            }

        }



        public void GetUsersAnswer(int userChoice)
        {


            bool isAnswerIncorrect = true;

            do
            {

                switch (userChoice)
                {
                    case 1:
                        btn.MessageEncoded += bmw.RichTextBox_LinkClicked;
                        btn.DoubleClick(bmw.Url);
                        isAnswerIncorrect = false;
                        break;
                    case 2:
                        btn.MessageEncoded += audi.RichTextBox_LinkClicked;
                        btn.DoubleClick(audi.Url);
                        isAnswerIncorrect = false;
                        break;
                    case 3:
                        btn.MessageEncoded += toyota.RichTextBox_LinkClicked;
                        btn.DoubleClick(toyota.Url);
                        isAnswerIncorrect = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect choice! Please, try again!");
                        userChoice = Convert.ToInt32(Console.ReadLine());
                        break;
                }

            }
            while (isAnswerIncorrect);

        }

    }
}
