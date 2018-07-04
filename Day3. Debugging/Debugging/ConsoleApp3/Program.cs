using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
  // Recursion depth with parralel watch
  class Program
  {
    static void Main(string[] args)
    {
      var test = new TestClass(); // DebuggerDisplay filter
      test.Number = 100;

      System.Diagnostics.Debug.WriteLineIf(test.Number == 100, "test.Number equals to 100");
      var x = Factorial(10);
      Console.WriteLine(x);
      Console.ReadKey();
    }

    static int Factorial(int number)
    {
      if (number == 0) // action point
      {
        return 1;
      }
      
      return number * Factorial(number - 1);
    }
  }

  [DebuggerDisplay("The number is {Number}")]
  public class TestClass
  {
    public int Number { get; set; }
  }


}
