using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  // Conditions, Parralel Watch, Immediate Window
  class Program
  {
    static void Main(string[] args)
    {
      List<Task> listOfTasks = new List<Task>();

      for (int i = 0; i < 3; i++)
      {
        var task = new Task(Do);
        listOfTasks.Add(task);
        task.Start();
      }

      Task.WaitAll(listOfTasks.ToArray());
      Console.WriteLine("Done");
      Console.ReadKey();
    }

    static void Do()
    {
      var counter = 0;
      for (int i = 0; i < 5; counter++)
      {
        var model = new Model {Id = counter};
        var factorialOfNumber = Factorial(model.Id);
        Thread.Sleep(1000);
        Console.WriteLine(factorialOfNumber);
      }
    }

    static int Factorial(int number)
    {
      if (number == 0)
      {
        return 1;
      }
      else
      {
        return number * Factorial(number - 1);
      }
    }

    public class Model
    {
      private int id;

      public int Id
      {
        get { return id; }
        set
        {
          if (value != 777)
          {
            id = value;
          }
        }
      }
    }
  }
}
