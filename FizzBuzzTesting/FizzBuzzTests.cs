using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzz;

namespace FizzBuzzTesting
{
    [TestClass]
    public class FizzBuzzTests
    {
        [TestMethod]
        public void IfNumberIsDivisibleThenReturnReplacmentText()
        {
            IFilter filter = new DivisibleFilter(3,"Fizz");
            string result = filter.ApplyFilter(6);

            Assert.AreEqual("Fizz", result);
        }

        [TestMethod]
        public void IfNumberIsNotDivisibleThenReturnEmptyString()
        {
            IFilter filter = new DivisibleFilter(3, "Fizz");
            string result = filter.ApplyFilter(7);

            Assert.AreEqual(String.Empty, result);
        }

        [TestMethod]
        public void IfNoFiltersApplyThenReturnOriginalNumber()
        {
            FilterRunner runner = new FilterRunner();
            runner.AddFilter(new DivisibleFilter(3, "Fizz"));
            runner.AddFilter(new DivisibleFilter(5, "Buzz"));
            string result = runner.RunFilters(7);

            Assert.AreEqual("7", result);
        }

        [TestMethod]
        public void IfSomeFilterApplyReturnOnlyTheirReplacementText()
        {
            FilterRunner runner = new FilterRunner();
            runner.AddFilter(new DivisibleFilter(3, "Fizz"));
            runner.AddFilter(new DivisibleFilter(5, "Buzz"));
            runner.AddFilter(new DivisibleFilter(7, "Foo"));
            string result = runner.RunFilters(15);

            Assert.AreEqual("FizzBuzz", result);
        }

        [TestMethod]
        public void IfAllFilterApplyReturnAllReplacementText()
        {
            FilterRunner runner = new FilterRunner();
            runner.AddFilter(new DivisibleFilter(3, "Fizz"));
            runner.AddFilter(new DivisibleFilter(5, "Buzz"));
            runner.AddFilter(new DivisibleFilter(10, "Foo"));
            string result = runner.RunFilters(30);

            Assert.AreEqual("FizzBuzzFoo", result);
        }

        [TestMethod]
        public void IfRequestingOneHundredTestsReturnOneHundredResults()
        {
            FilterRunner runner = new FilterRunner();

            int count = 0;
            foreach(string s in runner.Run(100))
                count++;
            Assert.AreEqual(100, count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IfendIndexIsLessThanstartIndexThenThrowArgumentException()
        {
            FilterRunner runner = new FilterRunner();
            foreach (string s in runner.Run(4,3));
        }
    }
}
