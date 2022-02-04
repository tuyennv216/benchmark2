using BenchmarkDotNet.Attributes;

//| BenmarkParallel | 509.5 ms | 1.47 ms | 1.38 ms | 2 KB |

//| BenmarkSequence | 1,532.6 ms | 1.64 ms | 1.45 ms |      2 KB |

namespace Benmark2.Task_Thread
{
	[MemoryDiagnoser]
	public class Sequence_vs_parallel
	{
		//int NumberOfItems = 10;

		#region parallel
		[Benchmark]
		public async Task<int> BenmarkParallel()
		{
			var output = 0;

			var task1 = Task1();
			var task2 = Task2();
			var task3 = Task3();

			await Task.WhenAll(task1, task2, task3);

			output += task1.Result + task2.Result + task3.Result;
			return output;
		}
		#endregion

		#region sequence
		[Benchmark]
		public async Task<int> BenmarkSequence()
		{
			var output = 0;

			var value1 = await Task1();
			var value2 = await Task2();
			var value3 = await Task3();

			output += value1 + value2 + value3;
			return output;
		}

		#endregion

		#region tasks
		public Task<int> Task1()
		{
			return Task.Delay(500).ContinueWith(_ => 1);
		}
		public Task<int> Task2()
		{
			return Task.Delay(500).ContinueWith(_ => 1);
		}
		public Task<int> Task3()
		{
			return Task.Delay(500).ContinueWith(_ => 1);
		}
		#endregion
	}
}
