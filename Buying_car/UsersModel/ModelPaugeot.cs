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

            var modelName = htmlDocument.DocumentNode.SelectSingleNode("//h2");
            Console.WriteLine(modelName.InnerHtml);

            var nuo = htmlDocument.DocumentNode.SelectSingleNode("//small");

            foreach (var item in model)
            {

               
                var price = Regex.Match(
                      item.Descendants("span")
                      .Where(node => node.GetAttributeValue("itemprop", "")
                      .Equals("lowPrice")).FirstOrDefault().InnerText.Trim('\r', '\n', 't')
                  , @"\d+.\d+");

                Console.WriteLine($"Price: {nuo.InnerHtml} {price} Eur.");


            }

            Console.WriteLine();




        }
    }
}
