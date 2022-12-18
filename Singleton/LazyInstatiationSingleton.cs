namespace TestSolution
{
    public sealed class LazyInstatiationSingleton
    {
        private LazyInstatiationSingleton() { }

        private static LazyInstatiationSingleton instance = new();

        public static LazyInstatiationSingleton Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
