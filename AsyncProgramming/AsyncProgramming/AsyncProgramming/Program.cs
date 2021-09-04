using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-- ASync Method Call");
            var result2 = MyMethodAsync(5); //no wait   

            Console.WriteLine("-- Sync Method Call");
            var result1 = MyMethod(5); //waiting

            Console.WriteLine($"Sync Method Call result:{result1}");
            Console.WriteLine($"ASync Method Call result:{result2.Result}");
        }

        private static int MyMethod(int Count)
        {
            int result = 0;
            for (int i = 1; i <= Count; i++)
            {
                Thread.Sleep(200);
                Console.WriteLine($"sync number print :{i}");
                result += i;
            }
            return result;
        }

        private static Task<int> MyMethodAsync(int Count)
        {
            Task<int> task = new Task<int>(() =>
            {
                int result = 0;
                for (int i = 1; i <= Count; i++)
                {
                    Thread.Sleep(200);
                    Console.WriteLine($"async number print :{i}");
                    result += i;
                }
                return result;
            });
            task.Start();

            return task;
        }
    }
}
