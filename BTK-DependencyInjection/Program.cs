using System;

namespace BTK_DependencyInjection
{
    //Dependency injection WITHOUT IoC!!!
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            productManager.Save();
            
            productManager = new ProductManager(new NhProductDal());
            productManager.Save();
        }
    }

    interface IProductDal
    {
        public void Save();
    }
    
    class EfProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with Entity framework");
        }
    }
    
    class NhProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with Nh");
        }
    }

    class ProductManager
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Save()
        {
            //Business Code
            _productDal.Save();
        }
    }
}