namespace UdemyThreadSafeLazySingleton
{
    public class ThreadSafeLazySingleton
    {
        private static volatile ThreadSafeLazySingleton _instance;
        // Dummy object
        private static readonly object LockObject = new();

        private static int _count;
        private readonly string _name;

        private ThreadSafeLazySingleton()
        {
            _count++;
            _name = "ThreadSafeLazySingleton" + _count;
        }

        public static ThreadSafeLazySingleton Instance
        {
            get
            {
                lock(LockObject) _instance ??= new ThreadSafeLazySingleton();
                return _instance;
            }
        }
        
        // Double Lock Checking
        public static ThreadSafeLazySingleton InstanceDoubleLock
        {
            get
            {
                if (_instance is null)
                {
                    lock (LockObject) _instance ??= new ThreadSafeLazySingleton();
                }
                return _instance;
            }
        }
    }
}