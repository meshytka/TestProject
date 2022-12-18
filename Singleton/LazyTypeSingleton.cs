namespace TestSolution
{
    public sealed class LazyTypeSingleton
    {
        private LazyTypeSingleton() { }

        private static Lazy<LazyTypeSingleton> lazyInstance = new Lazy<LazyTypeSingleton>(() => new LazyTypeSingleton());

        public static LazyTypeSingleton Instance
        {
            get
            {
                return lazyInstance.Value;
            }
        }
    }
}
