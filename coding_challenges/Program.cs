using coding_challenges.implementations;
using System;
using System.Linq;

namespace coding_challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowBusyBeaver();
            //ShowFibonacci();
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
            Console.WriteLine(string.Join(',', fib.Solve().Take(20)));
            Console.WriteLine($"The 20th value in fibonacci is {fib.ElementAtIndex(19)}");
        }

        static void ShowBusyBeaver()
        {
            var bb = new BusyBeaver(3, (int state, int symbol) =>
            {
                switch (state)
                {
                    case 1:
                        return symbol == 0
                        ? new TuringContext(2, 1, true)
                        : new TuringContext(3, 1, true);
                    case 2:
                        return symbol == 0
                        ? new TuringContext(3, 0, true)
                        : new TuringContext(2, 1, true);
                    case 3:
                        return symbol == 0
                       ? new TuringContext(3, 1, false)
                       : new TuringContext(1, 1, false);
                    default:
                        throw new InvalidOperationException("The state should be between 1 and 3. (4 is the halt state)");
                }
            });

            var result = bb.Execute(new int[1000]);
            var score = BusyBeaver.Score(result);
            Console.WriteLine($"Our busy beaver wrote {score} 1's before halting");
        }
    }
}
