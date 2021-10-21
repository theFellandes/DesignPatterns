using System;

namespace Udemy_Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vatandas basbakanlik kalemine gelir ve surec baslar.");

            IBasbakan basbakan = new GercekBasbakan();
            BasbakanlikKalemi kalem = new BasbakanlikKalemi(basbakan);

            Vatandas riza = new Vatandas(kalem);
            riza.DerdiniAnlat();
            riza.IsIste();
        }
    }
}