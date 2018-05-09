using System;
using System.Threading;
using static System.Console;

namespace Chapter2.Recipe1
{
	internal class Program
	{
		private static void Main(string[] args)
		{
            WriteLine("出现应用程序未处理的异常：" + DateTime.Now + "\r\n");

            WriteLine("Incorrect counter");

			var c = new Counter();
            Thread t = new Thread(new ThreadStart(Work));
            Thread tq = new Thread(new ParameterizedThreadStart(WorkParam));
            var t1 = new Thread(() => TestCounter(c));
			var t2 = new Thread(() => TestCounter(c));
			var t3 = new Thread(() => TestCounter(c));
			t1.Start();
			t2.Start();
			t3.Start();
			t1.Join();
			t2.Join();
			t3.Join();

			WriteLine($"Total count: {c.Count}");
			WriteLine("--------------------------");

			WriteLine("Correct counter");

			var c1 = new CounterNoLock();

			t1 = new Thread(() => TestCounter(c1));
			t2 = new Thread(() => TestCounter(c1));
			t3 = new Thread(() => TestCounter(c1));
			t1.Start();
			t2.Start();
			t3.Start();
			t1.Join();
			t2.Join();
			t3.Join();

			WriteLine($"Total count: {c1.Count}");
            ReadLine();
		}

		static void TestCounter(CounterBase c)
		{
			for (int i = 0; i < 100000; i++)
			{
				c.Increment();
				c.Decrement();
			}
		}

        public static void Work()
        {

        }
        public static void WorkParam(object obj)
        {

        }
        class Counter : CounterBase
		{
			private int _count;

			public int Count => _count;

		    public override void Increment()
			{
				_count++;
			}

			public override void Decrement()
			{
				_count--;
			}
		}

		class CounterNoLock : CounterBase
		{
			private int _count;

			public int Count => _count;

            public int Count2
            {
                get
                {
                    return _count;
                }
                set
                {
                    _count = value;
                }
            }

		    public override void Increment()
			{
				Interlocked.Increment(ref _count);
			}

			public override void Decrement()
			{
				Interlocked.Decrement(ref _count);
			}
		}

		abstract class CounterBase
		{
			public abstract void Increment();

			public abstract void Decrement();
		}
	}
}
