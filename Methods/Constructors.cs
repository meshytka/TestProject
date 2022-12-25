using System.Xml.Serialization;

namespace Methods
{
    public class Constructors
    {
        // instance constructors are not inherited (can't be with virtual, new, ovveride, sealed and abstract modifiers)
        public Constructors() { }

        // There can be mutiple constructors but with different signature
        public Constructors(string name) { }

        public Constructors(int num) { }

        // Type instance can be created without calling constructors:
        public void CreateInstanceWithoutCallingConstructors()
        {
            var obj = new Constructors();

            // MemberwiseClone allocates memory, initializes the service fields of the object, and then copies bytes of the original object
            // into the memory area that allokated for new object
            var copy = obj.MemberwiseClone();


            // Constructor usually doesn't called with object deserialization
            // Deserialization code allocates memory for object without calling constructor just using GetUninitializedObject or GetSafeUninitializedObject methods
            XmlSerializer serializer = new XmlSerializer(typeof(SerializableClass));
            string xml;
            using (StringWriter stringWriter = new StringWriter())
            {
                var serializableClass = new SerializableClass();
                serializer.Serialize(stringWriter, serializableClass);
                xml = stringWriter.ToString();
            }
            using (StringReader stringReader = new StringReader(xml))
            {
                var serializableClass = serializer.Deserialize(stringReader) as SerializableClass;
            }
        }

        [Serializable]
        public class SerializableClass { }
    }

    // If there is no any constructors compiler will create default constuctor
    public class ClassWithutDefaultConstructor
    {
        // It will be disable and it looks like this:
        // It will call System.Object constructor that just returns control
        // public ClassWithutDefaultConstructor() : base {}
    }

    // For abstract class compiler creates protected default consructor
    public abstract class AbstractClass { }

    // For static class compiler doesn't create default constructor
    public static class StaticClass { }

    public class InlineInitializing
    {
        // It is possible to initialize fields inline
        // It will be during creation of an object of a reference type
        // Compiler puts this syntax in constructor that performs the initialization
        private string SomeSring = "str";
        private string SomeSring2 = "str2";
        private string SomeSring3 = "str3";

        // It will increase for IL-code if we will have a multiple constructors
        public InlineInitializing() { }

        public InlineInitializing(int num) { }

        public InlineInitializing(string str) { }
    }

    public class RightInlineInitializing
    {
        // It will be good if there will be fields without inline initialization
        private string SomeSring;
        private string SomeSring2;
        private string SomeSring3;

        // And single consructor that performs general initialization
        public RightInlineInitializing() 
        {
            SomeSring = "str";
            SomeSring2 = "str2";
            SomeSring3 = "str3";
        }

        // And force each constructor explisity call this constructor
        public RightInlineInitializing(int num) : this() { }

        public RightInlineInitializing(string str) : this() { }
    }
}
