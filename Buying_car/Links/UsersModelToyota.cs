using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Buying_car
{
    public class UsersModelToyota
    {


        public async void GetCurrentPrice(string url)
        {

            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var model = htmlDocument.DocumentNode.Descendants("div")
           .Where(node => node.GetAttributeValue("class", "")
           .Contains("col-xs-12 col-sm-7 col-md-6 right-column")).ToList();



            foreach (var item in model)
            {
                Console.WriteLine(item.GetAttributeValue("col-xs-12 col-sm-7 col-md-6 right-column", ""));

                var oldPrice = Regex.Match(
                      item.Descendants("div")
                      .Where(node => node.GetAttributeValue("class", "")
                      .Equals("row")).FirstOrDefault().InnerText.Trim('\r', '\n', 't')
                  , @"\d+.\d+");


                Console.WriteLine($"Price: {oldPrice} Eur.");

                if (item.Descendants("span").Any(n => n.GetAttributeValue("class", "").Contains("price-new")))
                {
                    var newPrice = Regex.Match(
                   item.Descendants("span")
                   .Where(node => node.GetAttributeValue("class", "")
                   .Equals("price-new")).FirstOrDefault().InnerText.Trim('\r', '\n', 't')
                   ,@"\d+.\d+");


                    PrintColor(ConsoleColor.Red, $" New price: {newPrice} Eur.");
                    Console.ResetColor();
                }
               
            }

            Console.WriteLine();

        }


        private void PrintColor(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }



    }
}
