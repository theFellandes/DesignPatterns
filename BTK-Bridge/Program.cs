using System;

namespace BTK_Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            //MessageSenderBase'in bridge'ini set ediyoruz.
            customerManager.MessageSenderBase = new MailSender();
            customerManager.UpdateCustomer();
        }
    }

    //Farklı mesaj sınıflarında Send farklılık göstereceğinden abstract.
    abstract class MessageSenderBase
    {
        //Sabit send methodu
        public void Save()
        {
            Console.WriteLine("Message Saved!");
        }

        //BU İKİSİ DE MESAJ GÖNDERME EYLEMİ BU KÖTÜ YAZIM!!!
        // public void SendSms()
        // {
        //     
        // }
        //
        // public void SendEmail()
        // {
        //     
        // }
        
        //Send'in yapacağı işlemi bir nevi köprü yöntemiyle gerçekleştirelim.
        //Send soyutlandığından concrete yapılmalı
        public abstract void Send(Body body);

    }

    //Message body
    class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class MailSender : MessageSenderBase
    {

        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via MailSender", body);
        }
    }
    
    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via SmsSender", body);
        }
    }

    //Değişiklik gösterecek class
    //Kullanan class, gerekli mesajlama işlemlerini yapacak class
    class CustomerManager
    {
        public MessageSenderBase MessageSenderBase { get; set; }
        //Burada bir operasyonumuz olacak, mesaj göndermeye çalışacağız
        public void UpdateCustomer()
        {
            MessageSenderBase.Send(new Body());
            Console.WriteLine("Customer updated.");
        }
    }
}