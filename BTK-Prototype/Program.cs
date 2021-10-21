using System;

namespace BTK_Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer{FirstName = "Engin", LastName = "Demiroğ", City = "Ankara", Id = 1};

            //customer2'yi Person olarak alıyor
            //Type casting yaparak Customer'a ayarladık
            var customer2 = (Customer)customer1.Clone();

            customer2.FirstName = "Salih";
            
            //customer1 ve customer2 ikisi de aynı nesne değil ancak new'lemeden kurtardık clone ile.
            Console.WriteLine(customer1.FirstName);
            Console.WriteLine(customer2.FirstName);
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();
        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }
        //Bu method bize Customer'ı clone'lamayı sağlayacak
        public override Person Clone()
        {
            return (Person) MemberwiseClone();
        }
    }
    
    public class Employee : Person
    {
        public decimal Salary { get; set; }
        //Bu method bize Customer'ı clone'lamayı sağlayacak
        public override Person Clone()
        {
            return (Person) MemberwiseClone();
        }
    }
}