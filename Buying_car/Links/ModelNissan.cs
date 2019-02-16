using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Buying_car.Links
{
    public class ModelNissan
    {

        public async void GetCurrentPrice(string url)
        {

            var httpClient = new System.Net.Http.HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var model = htmlDocument.DocumentNode.Descendants("div")
           .Where(node => node.GetAttributeValue("class", "")
           .Contains("c_023")).ToList();



            foreach (var item in model)
            {
                Console.WriteLine(item.GetAttributeValue("c_23", ""));
                Console.WriteLine(item.Descendants("div")
                      .Where(node => node.GetAttributeValue("class", "")
                      .Equals("heading-group")).FirstOrDefault().InnerText.Trim('\r', '\n', 't'));


                var oldPrice = Regex.Match(
                      item.Descendants("p")
                      .Where(node => node.GetAttributeValue("class", "")
                      .Equals("disclaimer")).FirstOrDefault().InnerText.Trim('\r', '\n', 't')
                  , @"\d+.\d+");
                Console.WriteLine($"Price: {oldPrice} Eur.");

              
    
                
            }

            Console.WriteLine();

        }

        

    }
}
