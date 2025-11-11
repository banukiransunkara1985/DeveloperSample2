using System;
using System.Linq;
using System.Text;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        //factorial of n
        public static int GetFactorial(int n)
        {
            if (n < 0) throw new ArgumentException("invalid n value");

            int result = 1;
            for (int i = 1; i <= n; i++)
                result *= i;
            return result;
        }

        // Formats array of strings resuting in sentence and last value
        public static string FormatSeparators(params string[] items)
        {
            if ( items.Length <= 0)
                return string.Empty;

            if (items.Length == 1)
                return items[0];

            return string.Join(", ", items, 0, items.Length - 1) + " and " + items[^1];
        }
    }
}