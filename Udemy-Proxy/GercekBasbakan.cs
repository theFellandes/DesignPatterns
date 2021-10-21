using System;

namespace Udemy_Proxy
{
    public class GercekBasbakan : IBasbakan
    {
        public void DertDinle(string dert)
        {
            Console.WriteLine("Basbakan: Dinliyorum");
        }

        public void isBul(string yakinim)
        {
            Console.WriteLine("Basbakan: Bana böyle isteklerle gelmeyin.");
        }
    }
}