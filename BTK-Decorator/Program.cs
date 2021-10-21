using System;

namespace BTK_Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var personalCar = new PersonalCar {Make = "BMW", Model = "3.20", HirePrice = 2500};

            SpecialOffer specialOffer = new SpecialOffer(personalCar);
            specialOffer.DiscountPercentage = 10;

            Console.WriteLine("Concrete: {0}", personalCar.HirePrice);
            Console.WriteLine("Special Offer: {0}", specialOffer.HirePrice);
        }
    }

    abstract class CarBase
    {
        //Farklı durumlarda bu attribute'ları ezeceğimiz için abstract yapıyoruz.
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class PersonalCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    class CommercialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase;

        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        public int DiscountPercentage { get; set; }
        private readonly CarBase _carBase;
        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }

        public override string Make { get; set; }
        public override string Model { get; set; }

        public override decimal HirePrice
        {
            get => _carBase.HirePrice - _carBase.HirePrice * DiscountPercentage / 100;
            set
            {
                
            }
        }
    }
}