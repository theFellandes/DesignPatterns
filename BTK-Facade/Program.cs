﻿using System;

namespace BTK_Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
        }
    }

    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    internal interface ILogging
    {
        void Log();
    }

    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    internal interface ICaching
    {
        void Cache();
    }

    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User checked");
        }
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }

    //Bunu bu şekilde kullanmaktansa şöyle kullanırız:
    // class CustomerManager
    // {
    //     private ILogging _logging;
    //     private ICaching _caching;
    //     private IAuthorize _authorize;
    //
    //     public CustomerManager(ILogging logging, ICaching caching, IAuthorize authorize)
    //     {
    //         _logging = logging;
    //         _caching = caching;
    //         _authorize = authorize;
    //     }
    //
    //     public void Save()
    //     {
    //         _logging.Log();
    //         _caching.Cache();
    //         _authorize.CheckUser();
    //         Console.WriteLine("Saved.");
    //     }
    // }
    
    class CustomerManager
    {
        private CrossCuttingConcernsFacade _concerns;
      
        public CustomerManager()
        {
            _concerns = new CrossCuttingConcernsFacade();
        }

        public void Save()
        {
            _concerns.Authorize.CheckUser();
            _concerns.Caching.Cache();
            _concerns.Logging.Log();
            Console.WriteLine("Saved.");
        }
    }

    //New'lemeyi facade'ın içinde yaptık.
    //Dependency injection ile geliştirilebilir.
    class CrossCuttingConcernsFacade
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;

        public CrossCuttingConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
        }
    }
}