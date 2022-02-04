using BenchmarkDotNet.Attributes;
using Benmark2._model;

//| BenmarkIf			| 305.1 ms | 21.32 ms | 54.66 ms | 293.6 ms | 10000.0000 | 3000.0000 | - | 95 MB |

//| BenmarkWithoutIf	| 369.7 ms | 50.12 ms | 132.05 ms | 301.8 ms | 11000.0000 | 3500.0000 | 500.0000 | 95 MB |

namespace Benmark2.If
{
	[MemoryDiagnoser]
	public class If_vs_without_if
	{
		int NumberOfItems = 1000000;

		#region if
		[Benchmark]
		public string[] BenmarkIf()
		{
			var output = new string[NumberOfItems];
			var items = If();
			for (var i = 0; i < items.Length; i++)
			{
				output[i] = items[i].ToString();
			}
			return output;
		}
		public float[] If()
		{
			float[] result = new float[NumberOfItems];
			for (var i = 0; i < NumberOfItems; i++)
			{
				var ticket = new Ticket("name", i, 2 * i, DateTime.Now);
				if (ticket.Value % 2 == 0)
				{
					result[i] = ticket.Value + ticket.Value * ticket.Price;
				}
				else
				{
					result[i] = ticket.Value * ticket.Value + ticket.Price;
				}
			}
			return result;
		}
		#endregion

		#region without if
		[Benchmark]
		public string[] BenmarkWithoutIf()
		{
			var output = new string[NumberOfItems];
			var items = WithoutIf();
			for (var i = 0; i < items.Length; i++)
			{
				output[i] = items[i].ToString();
			}
			return output;
		}
		public float[] WithoutIf()
		{
			float[] result = new float[NumberOfItems];
			for (var i = 0; i < NumberOfItems; i++)
			{
				var ticket = new Ticket("name", i, 2 * i, DateTime.Now);
				var value1 = ticket.Value % 2;
				var value2 = value1 == 0 ? 1 : 0;
				result[i] = value1 * (ticket.Value + ticket.Value * ticket.Price)
					+ value2 * (ticket.Value * ticket.Value + ticket.Price);
			}
			return result;
		}
		#endregion
	}
}
