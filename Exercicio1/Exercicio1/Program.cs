using System.Collections.Generic;
using System.Linq;
using static System.Console;
using static System.Convert;

namespace Exercicio1
{
    class Program
    {
        static int Main(string[] args)
        {
            if (ToInt32(args[0]) > 100_000_000)
                return -1;

            var lstInt = new List<int>();

            foreach (var item in args[0].ToCharArray())
                lstInt.Add(ToInt32(item.ToString()));

            var sortedValues = lstInt.OrderByDescending(p => p).ToList();

            int result = 0;

            foreach (int n in sortedValues)
                result = 10 * result + n;

            WriteLine(result);

            return result;
        }
    }
}
