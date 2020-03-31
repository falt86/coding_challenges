using System;
using System.Collections.Generic;
using System.Linq;

namespace coding_challenges.implementations
{
    public class FizzBuzz
    {
        /// <summary>
        /// Shows the classic FizzBuzz problem with maximum flexibility
        /// </summary>
        /// <param name="start">where to begin</param>
        /// <param name="length">how far to go</param>
        /// <param name="rules">what should we return for each int</param>
        /// <returns></returns>
        public IEnumerable<string> Solve(int start, int length, Func<int, string> rules)
        {
            return Solve(start, rules).Take(length);
        }

        /// <summary>
        /// An overload that has no length limit.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="rules"></param>
        /// <returns></returns>
        public IEnumerable<string> Solve(int start, Func<int,string> rules)
        {
            for (var i = start; true; i++)
                yield return rules(i);
        }
    }
}
