namespace Udemy_Proxy
{
    public class Vatandas
    {
        private IBasbakan basbakan;

        public Vatandas(BasbakanlikKalemi kalem)
        {
            basbakan = kalem.BanaBasbaskaniVer();
        }

        public string DerdiniAnlat()
        {
            basbakan.DertDinle("Bir derdim var...");
            return "Yasasin...";
        }

        public string IsIste()
        {
            basbakan.isBul("Oglum");
            return "Yasasin...";
        }
    }
}