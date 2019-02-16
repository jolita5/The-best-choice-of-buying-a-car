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
    public class ModelAutoGidas
    {


        public async void GetCurrentPriceAndModel(string url)
        {

            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var model = htmlDocument.DocumentNode.Descendants("div")
           .Where(node => node.GetAttributeValue("class", "")
           .Contains("panel-left")).ToList();


            foreach (var item in model)
            {

                Console.WriteLine(item.Descendants("div")
                      .Where(node => node.GetAttributeValue("class", "")
                      .Equals("title-container")).FirstOrDefault().InnerText.Trim('\r', '\n', 't'));

                var price = Regex.Match(
                   item.Descendants("span")
                   .Where(node => node.GetAttributeValue("class", "")
                   .Equals("data-value")).FirstOrDefault().InnerText.Trim('\r', '\n', 't')
                   , @"\d+.\d+");

                Console.WriteLine($"Price: {price} Eur.");



            }

        }


    }
}
