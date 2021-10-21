using System;

namespace BTK_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;

        //lock yapacak dummy object
        private static object _lockObject = new object();
        //CustomerManager nesnesine dış erişimi engellemek.
        //Constructor'u olan dışarıdan erişilemeyen nesne.
        private CustomerManager()
        {
            
        }

        public static CustomerManager CreateAsSingleton()
        {
            //Biz bu methodda şunu kontrol edeceğiz
            //Eğer daha önce bu CustomerManager nesnesinden
            //daha önce oluşturulmuşu varsa onu vereceğiz kullanıcıya. Yoksa oluşturacağız
            
            // if (_customerManager is null)
            //     _customerManager = new CustomerManager();
            // return _customerManager;
            //customerManager null mı değil mi diye bak, null'sa yeniyi oluştur.
            // return _customerManager ?? (_customerManager = new CustomerManager());
           
            /*
             
            lock (_lockObject)
            {
                if(_customerManager is null)
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager;
            
            */
            
            lock (_lockObject)
            {
                _customerManager = _customerManager ??= new CustomerManager();
            }

            return _customerManager;
        }

        public void Save()
        {
            Console.WriteLine("Saved!!");
        }
    }
}