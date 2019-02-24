using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите q, чтобы выйти. Любой другой знак, чтобы продолжить");
            while (!Console.ReadKey().Equals("q"))
            {
                Console.WriteLine();
                Console.WriteLine("Введите число:");
                var number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ответ:");
                Console.WriteLine(FibonacciNumber(number)); 
            }
        }

        public static int FibonacciNumber(int number)
        {
            int result;
            if(GetNumberFromCache(number, out result))
            {
                return result;
            }

            result = number > 1 ? FibonacciNumber(number - 1) + FibonacciNumber(number - 2) : number;
            PutNumberInCache(number, result);

            return result;
        }

        public static void PutNumberInCache(int cacheItemName, int cacheNumber)
        {
            ObjectCache cache = MemoryCache.Default;
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5);
            cache.Set(cacheItemName.ToString(), cacheNumber, policy);
        }

        public static bool GetNumberFromCache(int cacheItemName, out int cacheNumber)
        {
            cacheNumber = -1;
            ObjectCache cache = MemoryCache.Default;
            var cachedObject = cache[cacheItemName.ToString()];

            if(cachedObject != null)
            {
                return int.TryParse(cachedObject.ToString(), out cacheNumber);
            }

            return false;
        }
    }
}
