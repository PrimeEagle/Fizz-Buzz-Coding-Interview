using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberLibrary
{
    public class NumberList
    {
        /// <summary>
        /// Returns a collection of strings representing numbers ranging from the lowerLimit to the upperLimit. An optional list of substitutions can be passed as key pairs, 
        /// which will substitute strings for numbers that are evenly divisible by the key in the key pair.
        /// </summary>
        /// <param name="lowerLimit">The lower limit of numbers to return.</param>
        /// <param name="upperLimit">The upper limit of numbers to return.</param>
        /// <param name="substitutions">A list of substitution strings for numbers evenly divisble by the key value.</param>
        /// <param name="sort">A flag indicating whether the substitution list should be sorted on the key or not. This can affect the order substition phrases are concatenated together for numbers that
        /// are evenly divisible by more than one key value from the substitution list.</param>
        /// <returns></returns>
        public IEnumerable<string> DisplayNumber(long lowerLimit, long upperLimit, Dictionary<long, string> substitutions, bool sort)
        {
            // check if lower and upper limits are valid
            if (lowerLimit > upperLimit)
                throw new ArgumentException("Lower limit cannot be greater than upper limit.");

            List<long> keyList = null;

            // if substitution list exists, create a key list and sort it if necessary
            if (substitutions != null)
            {
                keyList = substitutions.Keys.ToList();

                if (sort)
                    keyList.Sort();
            }

            for (long i = lowerLimit; i <= upperLimit; i++)
            {
                string result = string.Empty;

                // if a substitution list exists, check for all evenly divisible factors
                if (substitutions != null)
                {
                    foreach (long key in keyList)
                    {
                        bool divisible = i%key == 0;

                        if (divisible)
                        {
                            result += result == string.Empty ? substitutions[key] : " " + substitutions[key];
                        }
                    }
                }

                // return just the number if not no substitutions were processed
                result += result == string.Empty ? i.ToString() : string.Empty;
                
                // return results one at a time, in order to handle large sets of data
                yield return result;
            }
        }
    }
}
