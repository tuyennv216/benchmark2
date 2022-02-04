using BenchmarkDotNet.Attributes;
using Benmark2._model;

//| BenmarkForvar		| 8.803 s | 1.090 s | 3.196 s | 7.088 s | 154000.0000 | 81000.0000 | 1000.0000 | 1 GB |

//| BenmarkForyield		| 8.849 s | 1.126 s | 3.303 s | 7.251 s | 154000.0000 | 81000.0000 | 1000.0000 | 1 GB |

namespace Benmark2.Array
{
	[MemoryDiagnoser]
	public class For_var_vs_yield
	{
		int NumberOfItems = 100000;

		#region for var
		[Benchmark]
		public string[] BenmarkForvar()
		{
			var output = new string[NumberOfItems];
			Ticket[] items = IterateUsingForvar();
			for (var i = 0; i < items.Length; i++)
			{
				output[i] = items[i].ToString();
			}
			return output;
		}
		public Ticket[] IterateUsingForvar()
		{
			// generate all items before send it to the caller
			Ticket[] result = new Ticket[NumberOfItems];
			for (var i = 0; i < NumberOfItems; i++)
			{
				result[i] = new Ticket("name", i, DateTime.Now);
			}
			return result;
		}
		#endregion

		#region for yield
		[Benchmark]
		public string[] BenmarkForyield()
		{
			var output = new string[NumberOfItems];
			Ticket[] items = IterateUsingForvar();
			for (var i = 0; i < items.Length; i++)
			{
				output[i] = items[i].ToString();
			}
			return output;
		}
		public IEnumerable<Ticket> IterateUsingForYield()
		{
			// send direct for each item that was generated
			for (var i = 0; i < NumberOfItems; i++)
			{
				yield return new Ticket("name", i, DateTime.Now);
			}
		}
		#endregion
	}

}
