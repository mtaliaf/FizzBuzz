using System;
using System.Collections.Generic;

namespace FizzBuzz
{
    public interface IFilter
    {
        string ApplyFilter(int num);
    }

    public class DivisibleFilter : IFilter
    {
        private int divisor;
        private string replacementText;

        public DivisibleFilter(int num, string text)
        {
            divisor = num;
            replacementText = text;
        }

        public string ApplyFilter(int num)
        {
            if (num % divisor == 0)
                return replacementText;
            else
                return String.Empty;
        }
    }

    public class FilterRunner
    {
        private List<IFilter> filters = new List<IFilter>();

        public void AddFilter(IFilter filter)
        {
            filters.Add(filter);
        }

        public string RunFilters(int testNum)
        {
            string result = String.Empty;

            foreach (IFilter filter in filters)
            {
                result += filter.ApplyFilter(testNum);
            }

            if (String.IsNullOrEmpty(result))
                result = testNum.ToString();

            return result;
        }

        public IEnumerable<string> Run(int endIndex)
        {
            return Run(1, endIndex);

        }

        public IEnumerable<string> Run(int startIndex, int endIndex)
        {
            if (startIndex > endIndex)
                throw new ArgumentException("endIndex can not be less than the startIndex","endIndex");

            for (int i = startIndex; i <= endIndex; i++)
            {
                yield return RunFilters(i);
            }

        }
    }
}