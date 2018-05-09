using System;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;

namespace Chapter5.Recipe2
{
	class Program
	{
		static void Main(string[] args)
		{
			Task t = AsynchronousProcessing();
			t.Wait();
		    Console.ReadKey();
		}

		static async Task AsynchronousProcessing()
		{
			Func<string, Task<string>> asyncLambda = async TaskName => {
				await Task.Delay(TimeSpan.FromSeconds(2));
				return
				    $"Task {TaskName} is running on a thread id {CurrentThread.ManagedThreadId}." +
				    $" Is thread pool thread: {CurrentThread.IsThreadPoolThread}";
			};

			string result = await asyncLambda("async lambda");

			WriteLine(result);
		}


    }
}
