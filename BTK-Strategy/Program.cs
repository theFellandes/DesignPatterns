using System;

namespace BTK_Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

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

    class CustomerManager
    {
        public void SaveCredit()
        {
            Console.WriteLine("Customer manager business");
            //Kredisini hesaplama kısmı, eğer üstteki kodları yazmasaydık if şöyleyse if böyleyse demek gerekecekti.
        }
    }
}