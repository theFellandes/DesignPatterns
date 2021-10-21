using System;

namespace Udemy_Proxy
{
    public class VekilBasbakan : IBasbakan
    {
        
        private IBasbakan _gercekBasbakan;

        public VekilBasbakan(IBasbakan gercekBasbakan)
        {
            _gercekBasbakan = gercekBasbakan;
        }
        
        public void DertDinle(string dert)
        {
            Console.WriteLine("Vekil: Derdinizi Dinliyorum.");
            bool ayiklandi = Ayikla(dert);
            if (ayiklandi)
                Ilet(dert);
        }

        public void isBul(string yakinim)
        {
            Console.WriteLine("Vekil: İsteğinizi Dinliyorum.");
        }

        private bool Ayikla(string dert)
        {
            bool b = true;
            return b;
        }

        private void Ilet(string dert)
        {
            _gercekBasbakan.DertDinle(dert);
        }
    }
}