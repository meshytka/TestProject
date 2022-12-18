namespace TestSolutions
{
    public class AnonymousTypes
    {
        public void Sample()
        {
            // anonymous class are generic
            // When anonymous objects are created it also generated right methods:
            // ToString
            // Equals (that compares objects not by reference, but by value)
            // GetHashCode (so we can use them as a key in a Dictionary and with Linq.GroupBy)
            var anonymType = new { Hello = "Hello", World = "World" };

            var dict = Enumerable.ToDictionary(new List<string>(), key => new { Hello = "Hello1", World = "World1" }, value => "");
            dict.Add(anonymType, "");

            var anonymType2 = new { Hello = "Hello", World = "World" };
            dict.Add(anonymType2, "");

            var anonymType3 = new { Hello = "Hello", World = "World" };
            var result = dict.Select(el => el.Key == anonymType3);

            // This will be the same anonymous class as the previous (generic, but with different types AnonymousType<string,string> vs AnonymousType<int,List<bool>)
            // it saves memory
            var anonymType4 = new { Hello = 123, World = new List<bool>() };

            // Different anonymous class because different field names
            var anonymType5 = new { Hello1 = "Hello", World2 = "World" };
        }
    }
}