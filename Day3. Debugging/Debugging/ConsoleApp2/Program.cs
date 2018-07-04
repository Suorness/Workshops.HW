using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
  class Program
  {
    // Step Into Specific example
    static void Main(string[] args)
    {
      var result = Do(M1(), M2());
      Console.WriteLine(result.ToString());

      Console.ReadKey();
    }


    static int Do(int a1, int a2)
    {
      return a1 + a2;
    }

    static int M1()
    {
      return 1;
    }

    static int M2()
    {
      return 2;
    }
  }
}
