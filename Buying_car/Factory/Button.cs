using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Buying_car
{
    public class Button
    {
        public event EventHandler<LinkClickedEventArgs> MessageEncoded;



        public void DoubleClick(string url)
        {
            Console.WriteLine("Website is opening...");
            Thread.Sleep(3000);


            OnMessageEncoded(url);

        }

        protected virtual void OnMessageEncoded(string url)
        {
            MessageEncoded?.Invoke(this, new LinkClickedEventArgs() { Url = url });
        }
    }
}
