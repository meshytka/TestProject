using System.Text.RegularExpressions;

namespace TestSolution
{
    public class LinqTasks
    {
        // Print all numbers from 10 to 50 separated by commas
        public void Task1()
        {
            Console.WriteLine(string.Join(',',Enumerable.Range(10, 41)));
        }

        // Print only that numbers from 10 to 50 that can be divided by 3
        public void Task2() 
        {
            Console.WriteLine(string.Join(',', Enumerable.Range(10, 41).All(n => n % 3 == 0)));
        }

        // Output word "Linq" 10 times
        public void Task3()
        {
            Console.WriteLine(string.Concat(Enumerable.Repeat("Linq",10)));
        }

        // Output all words with letter 'a' in string "aaa;abb;ccc;dap"
        public void Task4()
        {
            var str = "aaa;abb;ccc;dap";
            Console.WriteLine(string.Concat(str.Split(';').Where(w => w.Contains('a'))));
        }

        // Output number of letters 'a' in the words with this letter in string "aaa;abb;ccc;dap" separated by comma
        public void Task5()
        {
            var str = "aaa;abb;ccc;dap";
            Console.WriteLine(string.Join(',', str.Split(';').Select(w => w.Count(ch => ch == 'a'))));
        }

        // Output true if word "abb" exists in line  "aaa;xabbx;abb;ccc;dap", otherwise false
        public void Task6()
        {
            var str = "aaa;xabbx;abb;ccc;dap";
            Console.WriteLine(str.Contains("abb"));
        }

        // Get the longest word in string "aaa;xabbx;abb;ccc;dap"
        public void Task7()
        {
            var str = "aaa;xabbx;abb;ccc;dap";
            Console.WriteLine(str.Split(';').Max());
        }

        // Calculate average length of word in string "aaa;xabbx;abb;ccc;dap"
        public void Task8()
        {
            var str = "aaa;xabbx;abb;ccc;dap";
            Console.WriteLine(str.Split(';').Average(w => w.Length));
        }

        // Print the shortest word reversed in string "aaa;xabbx;abb;ccc;dap;zh"
        public void Task9()
        {
            var str = "aaa;xabbx;abb;ccc;dap";
            Console.WriteLine(str.Split(';').Min());
        }

        // Print true if in the first word that starts from "aa" all letters are 'b' otherwise false "baaa;aabb;aaa;xabbx;abb;ccc;dap;zh"
        public void Task10()
        {
            var str = "baaa;aabb;aaa;xabbx;abb;ccc;dap;zh";
            Console.WriteLine(false);
        }

        // Print true if in the first word that starts from "aa" all next letters are 'b' otherwise false "baaa;aabb;aaa;xabbx;abb;ccc;dap;zh"
        public void Task10AsISee()
        {
            var str = "baaa;aabb;aaa;xabbx;abb;ccc;dap;zh";
            Console.WriteLine(str.Split(';').First(w => w.StartsWith("aa")).Skip(2).All(ch => ch == 'b'));
        }

        // Print last word in sequence that excepting first two elements that ends with "bb"
        public void Task11()
        {
            var str = "baaa;aabb;aaa;xabbx;abb;ccc;dap;zh";
            Console.WriteLine(str.Split(';') is string[] a ? !a.Last().EndsWith("bb") ? a.Last() : () => { if (a.Count(str => str.EndsWith("bb")) > 2 || a.Count(str => str.EndsWith("bb")) == 0) return a.Last(); else return a.Last(str => !str.EndsWith("bb")); } : "");
        }
    }
}