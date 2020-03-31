using System.Collections.Generic;

namespace coding_challenges.implementations
{
    public class Fibonacci
    {
        const long index0 = 0;
        const long index1 = 1;

        /// <summary>
        /// Fibonacci started his sequesnce 1,1,2. Modern mathematicians start it 0,1,1.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<long> Solve()
        {
            var a = index0;
            var b = index1;
        
            for (var i=0L; true; i++)
            {
                if (i == 0) yield return a;
                if (i == 1) yield return b;
                b = a + b;
                a = b - a;
                yield return b;
            }
        }

        /// <summary>
        /// gets the value of the nth element in the fibonacci sequence
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public long ElementAtIndex(int i)
        {
            if (i == 0) return index0;
            if (i == 1) return index1;
            return ElementAtIndex(i - 2) + ElementAtIndex(i - 1);
        }
    }
}
