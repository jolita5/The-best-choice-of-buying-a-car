using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Buying_car.Links
{
    public class ModelPaugeot
    {


        public async void GetCurrentPriceAndModel(string url)
        {

            var httpClient = new System.Net.Http.HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var model = htmlDocument.DocumentNode.Descendants("div")
           .Where(node => node.GetAttributeValue("class", "")
           .Contains("description-panel js-block-video-to-hide left-position active")).ToList();

            if (htmlDocument.DocumentNode.Descendants("div").Any(n => n.GetAttributeValue("class", "").Contains("description-panel js-block-video-to-hide left-position active")))
            {
                var modelName = htmlDocument.DocumentNode.SelectSingleNode("//h2");
                Console.WriteLine(modelName.InnerHtml);

                var nuo = htmlDocument.DocumentNode.SelectSingleNode("//small");

                foreach (var item in model)
                {
                    if (item.Descendants("span").Any(n => n.GetAttributeValue("itemprop", "").Contains("lowPrice")))
                    {

                        var price = Regex.Match(
                          item.Descendants("span")
                          .Where(node => node.GetAttributeValue("itemprop", "")
                          .Equals("lowPrice")).FirstOrDefault().InnerText.Trim()
                      , @"\d+.\d+");

                        Console.WriteLine($"Price: {nuo.InnerHtml} {price} Eur.");

                    }
                    else
                    {
                        Console.WriteLine("No price in this page!");

                    }

                }
            }
            else
            {
                Console.WriteLine("Is this car model from Paugeot salon! Please, check it and try again.");

            }



        }
    }
}
