using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz.Library
{
    public class FizzBuzzService
    {
        public string Print(int n)
        {
            if (IsDivisibleBy(3, n) && IsDivisibleBy(5, n))
            {
                return "FizzBuzz";
            }
            else if (IsDivisibleBy(3, n))
            {
                return "Fizz";
            }
            else if (IsDivisibleBy(5, n))
            {
                return "Buzz";
            }
            else if (IsDivisibleBy(7, n))
            {
                return "FizzyBuzz";
            }
            else
            {
                return n.ToString();
            }
        }

        private bool IsDivisibleBy(int divisibleBy, int number)
        {
            return number % divisibleBy == 0;
        }
    }
}
