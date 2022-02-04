using BenchmarkDotNet.Attributes;
using Benmark2._model;

//| BenmarkForDecrementIndex | 110.70 ms | 34.19 ms | 100.82 ms | 54.72 ms | 1000.0000 | - | - | 14 MB |

//| BenmarkForIncrementIndex | 93.62 ms | 23.56 ms | 66.45 ms | 59.47 ms | 1750.0000 | 1000.0000 | 250.0000 | 14 MB |

namespace Benmark2.Array
{
	[MemoryDiagnoser]
	public class For_increment_vs_decrement_index
	{
		int NumberOfItems = 100000;

		#region for decrement index
		[Benchmark]
		public string[] BenmarkForDecrementIndex()
		{
			var output = new string[NumberOfItems];
			Ticket[] items = ForIncrementIndex();
			for (var i = items.Length - 1; i >= 0; i--)
			{
				output[i] = items[i].ToString();
			}
			return output;
		}
		public Ticket[] ForDecrementIndex()
		{
			var items = new Ticket[NumberOfItems];
			for (var i = items.Length - 1; i >= 0; i--)
			{
				items[i] = new Ticket("name", i, DateTime.Now);
			}
			return items;
		}
		#endregion

		#region for increment index
		[Benchmark]
		public string[] BenmarkForIncrementIndex()
		{
			var output = new string[NumberOfItems];
			Ticket[] items = ForIncrementIndex();
			for (var i = 0; i < items.Length; i++)
			{
				output[i] = items[i].ToString();
			}
			return output;
		}
		public Ticket[] ForIncrementIndex()
		{
			var items = new Ticket[NumberOfItems];
			for (var i = 0; i < items.Length; i++)
			{
				items[i] = new Ticket("name", i, DateTime.Now);
			}
			return items;
		}
		#endregion
	}
}
