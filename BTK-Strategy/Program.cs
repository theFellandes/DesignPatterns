using System;

namespace BTK_Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.CreditCalculatorBase = new After2010CreditCalculator();
            customerManager.SaveCredit();

            Console.WriteLine("---------------------");
            Console.WriteLine("# We used the same customerManager object here #");
            
            customerManager.CreditCalculatorBase = new Before2010CreditCalculator();
            customerManager.SaveCredit();
        }
    }

    //Bu soyut vasıtası ile bizim After2010 ve Before2010 tarzındaki stratejilerimiz artabilir.
    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }

    class Before2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using before2010");
        }
    }

    class After2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using after2010");
        }
    }

    //Stratejilerimizi kullanacak iş katmanımız.
    class CustomerManager
    {
        //Burada property vermek yerine bir injection ile de çözülebilir.
        public CreditCalculatorBase CreditCalculatorBase { get; set; }
        //buraya iş kodları yazacağız.
        public void SaveCredit()
        {
            Console.WriteLine("Customer manager business");
            //Kredisini hesaplama kısmı, eğer üstteki kodları yazmasaydık if şöyleyse if böyleyse demek gerekecekti.
            // biz if-if yazmaktansa base'imizi vereceğiz bu da şu demek, before da olabilir after da olabilir.
            //  base'in bize sağladığı avantaj da budur zaten.
            //Kısacası bize Base üzerinden ne verilirse biz de o base üzerinden hesaplamayı gerçekleştireceğiz.
            CreditCalculatorBase.Calculate();
        }
    }
}