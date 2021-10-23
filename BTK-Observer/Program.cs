using System;
using System.Collections.Generic;

namespace BTK_Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager();
            //Müşterileri bilgilendirmek için yaptık.
            productManager.Attach(new CustomerObserver());
            //Çalışanları bilgilendirdik.
            productManager.Attach(new EmployeeObserver());
            CustomerObserver customerObserver = new CustomerObserver();
            productManager.Attach(customerObserver);
            //customerObserver nesnesini detach'ledik
            productManager.Detach(customerObserver);
            productManager.UpdatePrice();
        }
    }
    
    class ProductManager
    {
        private List<Observer> _observers = new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Product price changed.");
            //Abone varsa aboneleri bilgilendireceğiz
            Notify();
        }

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

    abstract class Observer
    {
        public abstract void Update();
    }

    class CustomerObserver : Observer
    {
        //Mesajlama sistemi vasıtasıyla mesaj gönderebiliriz.
        public override void Update()
        {
            Console.WriteLine("Message to customer: Product price changed!");
        }
    }

    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to employee: Product price changed.");
        }
    }
}