using System;

namespace UdemyLazySingleton.LazySingleton
{
    class Client
    {
        static void Main(string[] args)
        {
            for (var i = 0; i < 10; i++)
            {
               LazySingleton s = LazySingleton.Instance;
                s.PrintName();
            }
        }
    }
}