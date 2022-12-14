namespace Singleton
{
    public sealed class TreadProtectedSingleton
    {
        private TreadProtectedSingleton() { }

        private static readonly object lockObj = new object (); 

        private static TreadProtectedSingleton instance = null;
        public static TreadProtectedSingleton Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new TreadProtectedSingleton();
                    }
                    return instance;
                }
            }
        }
    }
}
