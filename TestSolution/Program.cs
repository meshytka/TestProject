using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestSolution
{
    internal class Program
    {
        public IList<string> FizzBuzz(int n)
        {
            var result = new List<string>();

            for (int i = 1; i <= n; i++)
            {
                StringBuilder str = new StringBuilder();
                if (i % 3 == 0)
                {
                    str.Append("Fizz");
                }
                if (i % 5 == 0)
                {
                    str.Append("Buzz");
                }
                if (str.Length == 0)
                {
                    str.Append(i);
                }
                result.Add(str.ToString());
            }

            return result;
        }

        static void Main(string[] args)
        {
        }
    }
}
