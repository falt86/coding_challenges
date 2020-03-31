using coding_challenges.implementations;
using System;
using System.Linq;

namespace coding_challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowFibonacci();
            //ShowFizzBuzz();
        }

        static void ShowFizzBuzz()
        {
            var fb = new FizzBuzz();
            var result = fb.Solve(1, 100, (int i) =>
            {
                if (i % 15 == 0) return "FizzBuzz";
                if (i % 3 == 0) return "Fizz";
                if (i % 5 == 0) return "Buzz";
                return i.ToString();
            });
            foreach (var r in result)
                Console.WriteLine(r);
        }

        static void ShowFibonacci()
        {
            var fib = new Fibonacci();
            Console.WriteLine(string.Join(',',fib.Solve().Take(20)));
            Console.WriteLine($"The 20th value in fibonacci is {fib.ElementAtIndex(19)}");
        }
    }
}
