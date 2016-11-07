using System;

namespace MyLibrary
{
    public class MyMath
    {
        public static int Factorial(int v)
        {
            if (v < 0)
                throw new IndexOutOfRangeException();
            if (v == 0)
                return 1;

            return v * Factorial(v - 1);
        }
        
        public static int Fibonachi(int n)
        {
            if (n <= 0)
                throw new IndexOutOfRangeException();
            if (n == 1)
                return 1;
            if (n == 2)
                return 1;

            return  Fibonachi(n-1) + Fibonachi(n - 2);
        }
    }
}