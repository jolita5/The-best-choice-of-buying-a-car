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

            var model = htmlDocument.DocumentNode.Descendants("span")
           .Where(node => node.GetAttributeValue("class", "")
           .Contains("full-price")).ToList();

            var modelName = htmlDocument.DocumentNode.SelectSingleNode("//h1");
            Console.WriteLine(modelName.InnerHtml);

            //var price = htmlDocument.DocumentNode.SelectSingleNode("//span");





            foreach (var item in model)
            {
                Console.WriteLine(item.GetAttributeValue("full-price", "").ToString());

                //Console.WriteLine(item.Descendants("span")
                //      .Where(node => node.GetAttributeValue("class", "")
                //      .Equals("c_008")).FirstOrDefault().InnerText.Trim('\r', '\n', 't'));

                //var oldPrice = Regex.Match(
                //      item.Descendants("span")
                //      .Where(node => node.GetAttributeValue("class, dir", "")
                //      .Equals("full-price, ltr")).FirstOrDefault().InnerText.Trim('\r', '\n', 't')
                //  , @"\d+.\d+");

                //Console.WriteLine(oldPrice);



            }

            Console.WriteLine();




        }
    }
}
