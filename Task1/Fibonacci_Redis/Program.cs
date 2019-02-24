using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci_Redis
{
    class Program
    {
        private static ConnectionMultiplexer redisConnection;

        static void Main(string[] args)
        {
            redisConnection = ConnectionMultiplexer.Connect("localhost");
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
            if (GetNumberFromCache(number, out result))
            {
                return result;
            }

            result = number > 1 ? FibonacciNumber(number - 1) + FibonacciNumber(number - 2) : number;
            PutNumberInCache(number, result);

            return result;
        }

        public static void PutNumberInCache(int cacheItemName, int cacheNumber)
        {
            var db = redisConnection.GetDatabase();

            db.StringSet(cacheItemName.ToString(), cacheNumber);
        }

        public static bool GetNumberFromCache(int cacheItemName, out int cacheNumber)
        {
            cacheNumber = -1;
            var db = redisConnection.GetDatabase();
            string cachedObject = db.StringGet(cacheItemName.ToString());

            if (cachedObject != null)
            {
                return int.TryParse(cachedObject.ToString(), out cacheNumber);
            }

            return false;
        }
    }
}
