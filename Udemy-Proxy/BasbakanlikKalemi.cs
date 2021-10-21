using System;

namespace Udemy_Proxy
{
    public class BasbakanlikKalemi
    {
        private IBasbakan basbakan;

        public BasbakanlikKalemi(IBasbakan basbakan)
        {
            this.basbakan = new VekilBasbakan(basbakan);
        }

        public IBasbakan BanaBasbaskaniVer()
        {
            Console.WriteLine("Başbakanlık Kalemi: Tabi efendim.");
            return basbakan;
        }
    }
}