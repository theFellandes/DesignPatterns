using System;

namespace UdemySingleton.Singleton
{
    public class Singleton
    {
        private static Singleton _singleton = new Singleton();
        private static int _count;
        private readonly string _name;

        private Singleton()
        {
            _count++;
            _name = "Singleton " + _count;
        }

        public static Singleton Instance => _singleton;

        public void PrintName()
        {
            Console.WriteLine(_name);
        }
    }
}