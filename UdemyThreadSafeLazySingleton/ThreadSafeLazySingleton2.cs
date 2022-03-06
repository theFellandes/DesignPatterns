using System;

namespace UdemyThreadSafeLazySingleton
{
    public class ThreadSafeLazySingleton2
    {
        private static ThreadSafeLazySingleton2 _singleton;
        // Dummy object
        private static readonly Lazy<ThreadSafeLazySingleton2> _instance = 
            new(() => new ThreadSafeLazySingleton2());

        private static int _count;
        private readonly string _name;

        private ThreadSafeLazySingleton2()
        {
            _count++;
            _name = "ThreadSafeLazySingleton2 " + _count;
        }

        public static ThreadSafeLazySingleton2 Instance => _instance.Value;
    }
}