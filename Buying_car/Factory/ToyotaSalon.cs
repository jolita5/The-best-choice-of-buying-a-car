using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buying_car
{
    public class ToyotaSalon:ICar
    {
        public string Url { get; private set; } = "https://www.tokvila.lt/";



        public void OnMessageEncoded(object sender, LinkClickedEventArgs e)
        {

            Console.WriteLine(Url);
        }


        public void RichTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            LaunchWeblink(e.Url);
        }

        public void LaunchWeblink(string url)
        {

            if (MakeUrlActive(url))
            {
                Process.Start(url);
            }
        }

        public bool MakeUrlActive(string url)
        {
            return
        ((!string.IsNullOrWhiteSpace(url)) &&
        (url.ToLower().StartsWith("http")));

        }

        public void Start()
        {
            Console.WriteLine($"\n{SalonTypes.Toyota_Salon} was chosen.");
        }
    }
}
