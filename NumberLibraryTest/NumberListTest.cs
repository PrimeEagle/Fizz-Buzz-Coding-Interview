using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberLibrary;
using System.Collections.Generic;
using System.Linq;

namespace NumberLibraryTest
{
    [TestClass]
    public class NumberListTest
    {
        /// <summary>
        /// Verifies that an exception is thrown if the lower limit is greater than the upper limit.
        /// </summary>
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void LowerLimitGreaterThanUpperLimitException()
        {
            NumberList nl = new NumberList();

            var results = nl.DisplayNumber(10, 1, null, false).ToList();

            // Assert - expect an exception here
        }

        /// <summary>
        /// Tests to see if printing the list works if the lower and upper limit are equal.
        /// </summary>
        [TestMethod]
        public void LowerLimitEqualsUpperLimitWorks()
        {
            NumberList nl = new NumberList();

            var results = nl.DisplayNumber(5, 5, null, false).ToList();

            Assert.AreEqual("5", results[0]);
        }

        /// <summary>
        /// Tests to see if printing the list works if the lower or upper limit are negative.
        /// </summary>
        [TestMethod]
        public void NegativeLimitsWork()
        {
            NumberList nl = new NumberList();

            var results = nl.DisplayNumber(-5, -1, null, false).ToList();

            int i = -5;
            foreach (string s in results)
            {
                Assert.AreEqual(i.ToString(), s);
                i++;
            }
        }

        /// <summary>
        /// Tests to see if printing the list works if no substitution list is provided.
        /// </summary>
        [TestMethod]
        public void BasicNoSubstitionListWorks()
        {
            NumberList nl = new NumberList();

            var results = nl.DisplayNumber(1, 5, null, false).ToList();

            int i = 1;
            foreach (string s in results)
            {
                Assert.AreEqual(i.ToString(), s);
                i++;
            }
        }

        /// <summary>
        /// Tests to see if basic substitution works.
        /// </summary>
        [TestMethod]
        public void SingleSubstitionWorks()
        {
            NumberList nl = new NumberList();

            Dictionary<long, string> substitutions = new Dictionary<long, string>();
            substitutions.Add(2, "even");

            var results = nl.DisplayNumber(1, 10, substitutions, false).ToList();

            int i = 1;
            foreach (string s in results)
            {
                if(i % 2 == 0)
                    Assert.AreEqual("even", s);
                else
                    Assert.AreEqual(i.ToString(), s);
    
                i++;
            }
        }

        /// <summary>
        /// Tests to see if the sort parameter is working.
        /// </summary>
        [TestMethod]
        public void SortedSubstitutionWorks()
        {
            NumberList nl = new NumberList();

            Dictionary<long, string> substitutions = new Dictionary<long, string>();
            substitutions.Add(3, "three");
            substitutions.Add(2, "even");
            
            // unsorted, should substitute for 3 first, then for 2
            var results = nl.DisplayNumber(1, 10, substitutions, false).ToList();
            Assert.AreEqual("three even", results[5]);

            // sorted, should substitute for 2 first, then for 3
            results = nl.DisplayNumber(1, 10, substitutions, true).ToList();
            Assert.AreEqual("even three", results[5]);
       
        }
    }
}
