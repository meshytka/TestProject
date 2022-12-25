using System;

namespace TestSolution
{
    public class Yield
    {
        public void SomeMethod()
        {
            for (var enumerator = DoEnumeration(); enumerator.MoveNext();)
            {
                Console.WriteLine(enumerator.Current);
            }
        }

        IEnumerator<int> DoEnumeration()
        {
            // yield operator is good because we can iterate over a collection of any size (there will be only one item in memory
            // yield operator is bad because it has implicit allocations (new()) that overload garbage collector there are a method that called often. That can slow down app
            yield return 1;
            Console.WriteLine("After 1"); // this code will be called when the calling code gets the first element and calls the MoveNext method
            yield return 2;
            Console.WriteLine("After 2"); // this code will be called when the calling code gets the second element and calls the MoveNext method
            yield return 3;
            Console.WriteLine("After 3"); // this code will be called when the calling code gets the third element and calls the MoveNext method
        }

        // How it looks:
        // switch (this.1__state)
        //  {
        //  case 0:
        //    this.1__state = -1;
        //    this.2__current = 1;
        //    this.1__state = 1;
        //    return true;
        //  case 1:
        //    this.1__state = -1;
        //    Console.WriteLine("After 1");
        //    this.2__current = 2;
        //    this.1__state = 2;
        //    return true;
        //  case 2:
        //    this.1__state = -1;
        //    Console.WriteLine("After 2");
        //    this.2__current = 3;
        //    this.1__state = 3;
        //    return true;
        //  case 3:
        //    this.1__state = -1;
        //    Console.WriteLine("After 3");
        //    return false;
        //  default:
        //    return false;
        //}

        public void SomeMethod2()
        {
            var enumerable = DoEnumerable();

            foreach (var item in enumerable)
            {
                Console.WriteLine(item);
            }

            // this code will be executed correctly as previous
            foreach (var item in enumerable)
            {
                Console.WriteLine(item);
            }
        }

        // IEnumerable is thread-safe
        // this code will compile very similar to IEnumerator
        IEnumerable<int> DoEnumerable()
        {
            yield return 1;
            Console.WriteLine("After 1"); // this code will be called when the calling code gets the first element and calls the MoveNext method
            yield return 2;
            Console.WriteLine("After 2"); // this code will be called when the calling code gets the second element and calls the MoveNext method
            yield return 3;
            Console.WriteLine("After 3"); // this code will be called when the calling code gets the third element and calls the MoveNext method
        }

        IEnumerable<int> DoEnumerable2()
        {
            try
            {
                yield return 1;
                Console.WriteLine("After 1"); // this code will be called when the calling code gets the first element and calls the MoveNext method
            }
            // it isn't possible to use yield in a try block if there is a catch block
            //catch { }
            finally
            {
                // we can't use yield in finally block
                // yield return 2;
                Console.WriteLine("After 2");
            }
        }

        // How it looks:
        // bool IEnumerator.MoveNext()
        // {
        //    try
        //    {
        //        switch (this.1__state)
        //        {
        //          case 0:
        //            this.1__state = -1;
        //            this.1__state = -3;
        //            this.2__current = 1;
        //            this.1__state = 1;
        //            return true;
        //          case 1:
        //            this.1__state = -3;
        //            Console.WriteLine("After 1");
        //            this.m__Finally1();
        //            return false;
        //          default:
        //            return false;
        //        }
        //     }
        //     __fault
        //     {
        //         this.System.IDisposable.Dispose();
        //     }
        // }

        // private void m__Finally1()
        // {
        //    this.1__state = -1;
        //    Console.WriteLine("After 2");
        //  }

        public IEnumerable<int> SomeMethod3()
        {
            // it looks like easy code with while(ienumerator.moveNext()){ return ... }
            foreach (var item in Enumerable.Range(0, 10))
            {
                yield return item * 2;
            }
        }

        IEnumerable<int> DoEnumerable3()
        {
            foreach (var item in Enumerable.Range(0,10))
            {
                yield return item * 2;
            }
        }

        // How it looks:
        // bool IEnumerator.MoveNext()
        // {
        //     try
        //     {
        //       switch (this.1__state)
        //       {
        //         // at the first call IEnumerable:
        //         case 0:
        //           this.1__state = -1;
        //           // create new variable and assign a value
        //           this.s__1 = Enumerable.Range(0, 10).GetEnumerator();
        //           this.1__state = -3;
        //           break;
        //         case 1:
        //           this.1__state = -3;
        //           break;
        //         default:
        //           return false;
        //       }
        //       // then just always will call MoveNext and assigning the current value
        //       if (this.s__1.MoveNext())
        //       {
        //         this.5__2 = this.s__1.Current;
        //         this.2__current = this.5__2 * 2;
        //         this.1__state = 1;
        //         return true;
        //       }
        //       this.m__Finally1();
        //       this.s__1 = (IEnumerator<int>)null;
        //       return false;
        //     }
        //     __fault
        //     {
        //       this.System.Disposable.Dispose();
        //     }
        // }

        // private void m__Finally1()
        // {
        //    this.1__state = -1;
        //    if (this.s__1 == null)
        //      return;
        //    this.s__1.Dispose();
        // } 
    }
}