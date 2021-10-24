using System;
using System.Collections.Generic;

namespace BTK_Command
{
    class Program
    {
        static void Main(string[] args)
        {
            StockManager stockManager = new StockManager();
            BuyStock buyStock = new BuyStock(stockManager);
            SellStock sellStock = new SellStock(stockManager);
            
            StockController stockController = new StockController();
            stockController.TakeOrder(buyStock);
            stockController.TakeOrder(buyStock);
            stockController.TakeOrder(sellStock);
            
            stockController.PlaceOrders();
        }
    }

    class StockManager
    {
        //Database'ten geldiğini düşünelim
        private string _name = "Laptop";
        private int _quantity = 10;

        public void Buy()
        {
            Console.WriteLine("Stock: {0}, {1} bought.", _name, _quantity);
        }

        public void Sell()
        {
            Console.WriteLine("Stock: {0}, {1} sold.", _name, _quantity);
        }
    }

    interface IOrder
    {
        void Execute();
    }
    
    class BuyStock : IOrder
    {
        private StockManager _stockManager;

        public BuyStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }

        //Parametre olarak biz buraya komutun yapması gereken
        // yani StockManager'ın implementasyonunu gerçekleştireceğiz.
        //  base'ini oluşturuyoruz.
        public void Execute()
        {
            _stockManager.Buy();
        }
    }

    class SellStock : IOrder
    {
        //Bu enjeksiyonu abstract class'la da yapabiliriz.
        private StockManager _stockManager;

        public SellStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }
        public void Execute()
        {
            _stockManager.Sell();
        }
    }

    class StockController
    {
        private List<IOrder> _orders = new List<IOrder>();

        public void TakeOrder(IOrder order)
        {
            _orders.Add(order);
        }

        public void PlaceOrders()
        {
            foreach (var order in _orders)
            {
                order.Execute();
            }
            _orders.Clear();
        }
    }
}