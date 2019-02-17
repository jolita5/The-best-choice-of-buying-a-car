using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Buying_car
{
    public class PaugeotSalon : ICar
    {
        public string Url { get; private set; } = "https://www.peugeotlietuva.lt/modeliu-gama/peugeot-automobiliai.html?utm_source=google&utm_medium=cpc&utm_campaign=lt_brand&utm_content=lt_brand&utm_term=lt_brand_lt03";



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

            Console.WriteLine($"\n{SalonTypes.Peugeot_Salon} was chosen.");
        }



    }
}
