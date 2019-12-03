using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitSamples
{
    public class Math
    {
        public decimal Add(decimal a, decimal b) => a + b;
        public decimal Subtract(decimal a, decimal b) => a - b;
        public decimal Multiply(decimal a, decimal b) => a * b;

        public decimal Divide(decimal a, decimal b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            return a / b;
        }

        public bool IsOdd(int input) => input % 2 == 0;
        public bool IsEven(int input) => input % 2 != 0;

        public IEnumerable<int> GetOddNumbers(int bound)
        {
            for (int i = 0; i <= bound; i++)
            {
                if (i % 2 != 0)
                    yield return i;
            }
        }

        public IEnumerable<int> GetEvenNumbers(int bound)
        {
            for (int i = 0; i <= bound; i++)
            {
                if (i % 2 == 0)
                    yield return i;
            }
        }
    }
}