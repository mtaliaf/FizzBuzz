using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzz;


class Program
{
    static void Main(string[] args)
    {
        FilterRunner runner = new FilterRunner();
        runner.AddFilter(new DivisibleFilter(3, "Fizz"));
        runner.AddFilter(new DivisibleFilter(5, "Buzz"));

        foreach(String result in runner.Run(5,3))
            Console.WriteLine(result);

        Console.ReadKey();
    }
}

