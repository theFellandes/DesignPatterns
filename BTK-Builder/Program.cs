using System;

namespace BTK_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector director = new ProductDirector();
            var builder = new NewCustomerProductBuilder();
            director.GenerateProduct(builder);
            var model = builder.GetModel();
            Console.WriteLine(model.Id);
        }
    }

    class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }

    //Bu view modeli üretecek bir business'e ihtiyaç var
    //bu bizim abstract builder'ımız olacak
    //abstract olma sebebi tamamına yakınında soyutlanma kullanıldığı için abstract
    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        private ProductViewModel model = new ProductViewModel();

        public override void GetProductData()
        {
            //Database'ten gelen farazi veriler
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }

        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice * (decimal) 0.90;
            model.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        private ProductViewModel model = new ProductViewModel();

        public override void GetProductData()
        {
            //Database'ten gelen farazi veriler
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }

        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.DiscountApplied = false;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

    //Product'u üretecek bir Director'e ihtiyaç var
    class ProductDirector
    {
        //Builder method vasıtası ile hangi builder'ı kullanacağımızı
        //göndereceğiz.
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            //Temel olarak arka arkaya çalıştıracağımız işlemleri yazacağız.
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}