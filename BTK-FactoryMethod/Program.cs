using System;

namespace BTK_FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            customerManager.Save();
            Console.WriteLine("-------------------------------------------------------");
            CustomerManager customerManager2 = new CustomerManager(new LoggerFactory2());
            customerManager2.Save();
        }
    }

    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Burada iş geliştirip ona göre bir logger veririz.
            //Business to decide factory.
            return new EdLogger();
        }
    }
    
    public class LoggerFactory2:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new WebLogger();
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }

    public class EdLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with EdLogger.");
        }
    }
    
    public class WebLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with WebLogger.");
        }
    }

    public class CustomerManager
    {
        private readonly ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("Saved!");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}