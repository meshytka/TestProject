namespace Events
{
    public class SomeClass
    {
        public void NewMethod() 
        {
            var evt = new ClassWithEvents();
            evt.OnEvent += Foo;
            evt.OnEvent += () =>
            {
                Foo();
                Console.WriteLine("");
            };
        }

        public void Foo() { }
    }

    public class ClassWithEvents
    {
        // Events based on delegates
        // Events are thread-safe
        public event Action OnEvent;
    }
}