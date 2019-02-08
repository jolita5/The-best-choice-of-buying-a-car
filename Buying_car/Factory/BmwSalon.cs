using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buying_car
{
    public class BmwSalon : ICar
    {
        public decimal Price {get; private set;} = 50606;
        public string Url { get; private set; } = "https://www.bmw.lt/lt/index.html";



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
            Console.WriteLine($"\n{SalonTypes.Bmw_Salon} was chosen.");
        }
    }
}
