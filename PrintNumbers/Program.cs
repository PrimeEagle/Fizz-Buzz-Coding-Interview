using System;
using System.Collections.Generic;
using NumberLibrary;

namespace PrintNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberList numberList = new NumberList();

            Dictionary<long, string> substitutions = new Dictionary<long, string>
            {
                {5, "buzz"},
                {3, "fizz"}
            };


            foreach (string s in numberList.DisplayNumber(1, 40, substitutions, true))
            {
                Console.WriteLine(s);
            }

            Console.ReadLine();
        }
    }
}
