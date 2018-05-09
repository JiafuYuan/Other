using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static System.Console;
using static System.Threading.Thread;

namespace Chapter1.Recipe2
{
	class Program
	{
		static void Main(string[] args)
		{
            List<string> list = new List<string> { "10","11"};

            // Cast the objects in the list to type 'string'
            // and project the first letter of each string.
            IEnumerable<int> query =list.AsQueryable().Select(c=>int.Parse(c));
            foreach (int s in query)
                Console.WriteLine(s);
            //      Array sourceArray=new object[5] {1,2,3,4,5};
            //      Array newArray = new object[5];
            //      Array.Copy(sourceArray,2,newArray,3,2);
            //      List<object> list=new List<object>() {1,2,3,4,5};
            //      var var= list.AsQueryable().Cast<string>();
            //      foreach (var v in var)
            //      {
            //          Console.WriteLine(v);
            //      }
            Console.ReadKey();
		    //Thread t = new Thread(PrintNumbersWithDelay);
		    //t.Start();
		    //PrintNumbers();
		}

		static void PrintNumbers()
		{
			WriteLine("Starting...");
			for (int i = 1; i < 10; i++)
			{
				WriteLine(i);
			}
		}

		static void PrintNumbersWithDelay()
		{
			WriteLine("Starting...");
			for (int i = 1; i < 10; i++)
			{
				Sleep(TimeSpan.FromSeconds(2));
				WriteLine(i);
			}
		}
	}
}
