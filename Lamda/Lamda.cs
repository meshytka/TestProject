using System.Linq.Expressions;

namespace Lamda
{
    public class Lamda
    {
        public void SomeMethod()
        {
            bool x = true;

            Expression<Func<bool>> expression = () => x;
            Func<bool> predicate = () => x;

            x = false;

            predicate();
            BoolMethod();

            bool BoolMethod() => x;
        }

        /*  public void SomeMethod()
            {
              Lamda.Lamda.c__DisplayClass0_0 cDisplayClass00 = new Lamda.Lamda.c__DisplayClass0_0();
              cDisplayClass00.x = true;
              // ISSUE: field reference
              Expression.Lambda<Func<bool>>((Expression) Expression.Field((Expression) Expression.Constant((object) cDisplayClass00, typeof (Lamda.Lamda.c__DisplayClass0_0)), FieldInfo.GetFieldFromHandle(__fieldref (Lamda.Lamda.c__DisplayClass0_0.x))), Array.Empty<ParameterExpression>());
              // ISSUE: method pointer
              Func<bool> func = new Func<bool>((object) cDisplayClass00, __methodptr(<SomeMethod>b__1));
              cDisplayClass00.x = false;
              int num = func() ? 1 : 0;
              cDisplayClass00.<SomeMethod>g__BoolMethod|();
            }

            public Lamda()
            {
              base..ctor();
            }

            [CompilerGenerated]
            private sealed class c__DisplayClass0_0
            {
              public bool x;

              public c__DisplayClass0_0()
              {
                base..ctor();
              }

              internal bool <SomeMethod>b__1()
              {
                return this.x;
              }

              internal bool <SomeMethod>g__BoolMethod|()
              {
                return this.x;
              }
            }

        There is implicit allocation (class c)
        */

        // There is no implicit allocations
        public void SomeMethod2()
        {
            bool x = true;

            Console.WriteLine(BoolMethod());

            bool BoolMethod()
            { 
                x = false;
                return !x;
            }
        }

        /*  [CompilerGenerated]
            [StructLayout(LayoutKind.Auto)]
            private struct c__DisplayClass1_0
            {
              public bool x;
            }

        Because there is a structure (compiler know that it will not be used anywhere outside the function)

        And we can change value of variebles because they are passed by ref:
            Console.WriteLine(Lamda.Lamda.<SomeMethod2>g__BoolMethod|0_0(ref cDisplayClass00));
         */
    }
}