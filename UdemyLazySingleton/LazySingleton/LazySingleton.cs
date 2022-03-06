using System;

namespace UdemyLazySingleton.LazySingleton
{
    // Unprotected against multithreading
    public class LazySingleton
    {
        private static LazySingleton _singleton;

        private static int _count;
        private string _name;

        private LazySingleton()
        {
            _count++;
            _name = "LazySingleton" + _count;
        }

        public static LazySingleton Instance => _singleton ??= new LazySingleton();

        public void PrintName()
        {
            Console.WriteLine(_name);
        }
    }
}