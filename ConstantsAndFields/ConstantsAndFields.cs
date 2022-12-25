namespace ConstantsAndFields
{
    public class ConstantsAndFields
    {
        public class SomeClass
        {
            // Can use only primitive types (Int32/64|Byte|Char|Double|Decimal|String...)
            // Value that assotiated with constant name must be declarated at compile time. Then the compile saves values of constants in module's metadata
            // Constants are considered part of the type (static)
            // Memory for constants is't allocated at runtime
            // If you will change constant name you need to rebuild DLL assembly and application
            public const int SomeConst = 23;

            // Also we can use obj as const but with only null value
            public const SomeClass SomeObjConst = null;

            // Can use any types
            // dynamic memory to store instance field is allocated when instance of this type is created
            public SomeClass SomeField;

            // dynamic memory to store static field is allocated within object type that is created when the type is loaded into the application domain
            // usually it occurs with JIT-compiling any method that refers to this type
            // If you will change static fields value you need to rebuild DLL only
            public static int SomeStaticField = 1;

            // value of readonly typess can be set only when object of this type is created (in the constuctor)
            // but we have to remember that if we have reference type field we can't change it's reference, but we can change its values
            public readonly SomeClass SomeReadonlyField;

            // it is possible to set the value of a readonly field inline (it will be initialized at the constructor execution time)
            // but it is possible to have a perfomanse problems
            public readonly SomeClass SomeReadonlyField2 = new SomeClass();

            public volatile SomeClass SomeVolatileField;

            public SomeClass()
            {
                SomeField = new SomeClass();
                SomeReadonlyField = SomeField;

                SomeVolatileField = new SomeClass();
            }
        }
    }
}