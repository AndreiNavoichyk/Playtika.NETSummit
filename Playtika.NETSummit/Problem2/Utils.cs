using System;

namespace Playtika.NETSummit.Problem2
{
    // Add bugs
    public static class Utils
    {
        // Factorial
        public static int Foo1(int n)
        {
            var result = 1;
            for (var i = 1; i <= n; ++i)
            {
                result *= i;
            }

            return result;
        }

        // Triangle inequality
        public static bool Foo2(int a, int b, int c)
        {
            var result = true;

            result &= a <= b + c;
            result &= b <= a + c;
            result &= c <= a + b;

            return result;
        }

        // Prime number
        public static bool Foo3(int n)
        {
            var count = 0;

            for (var i = 2; i < (int) Math.Sqrt(n) + 1; ++i)
            {
                if (n % i == 0)
                {
                    count++;
                }
            }

            return count == 0;
        }

        // Count of digits in number
        public static int Foo4(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return (int) Math.Floor(Math.Log10(Math.Abs(n)) + 1);
            }
        }
    }
}