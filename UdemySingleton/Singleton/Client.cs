using System;

namespace UdemySingleton.Singleton
{
    class Client
    {
        static void Main(string[] args)
        {
            for (var i = 0; i < 10; i++)
            {
                Singleton s = Singleton.Instance;
                s.PrintName();
            }
            
            Singleton s1 = Singleton.Instance;
            Singleton s2 = Singleton.Instance;

            Console.WriteLine(s1 == s2 ? "\nThe same object!" : "Different objects!");
        }
    }
}