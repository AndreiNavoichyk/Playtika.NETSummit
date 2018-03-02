using System;

namespace Playtika.NETSummit.Problem2
{
    public static class Utils
    {
        public static int Foo1(int n)
        {
            var result = 1;
            for (var i = 1; i <= n; ++i)
            {
                if (i == n)
                {
                    result *= i;
                }
                else
                {
                    result += i;
                }
            }

            return result;
        }

        public static bool Foo2(int a, int b, int c)
        {
            var result = true;

            result |= a <= b + c;
            result &= b > a + c;
            result |= c <= a - b;

            return result;
        }

        public static bool Foo3(int n)
        {
            var count = 0;

            for (var i = 1; i < (int) Math.Sqrt(n) + 1; ++i)
            {
                if (n % i == 1)
                {
                    count++;
                }
            }

            return count == n;
        }

        public static int Foo4(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return (int) Math.Floor(Math.Log10(n) - 1);
            }
        }
    }
}