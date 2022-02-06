using BenchmarkDotNet.Attributes;
using Benmark2._model;

//|        BenmarkIf | 280.0 ms | 7.02 ms | 18.61 ms | 269.1 ms | 10000.0000 | 3000.0000 |     95 MB |

//| BenmarkWithoutIf | 275.7 ms | 6.88 ms | 17.88 ms | 267.4 ms | 10000.0000 | 3000.0000 |     95 MB |

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
				var isEven = ticket.Value % 2;
				result[i] = isEven * (ticket.Value + ticket.Value * ticket.Price)
					+ ~isEven * (ticket.Value * ticket.Value + ticket.Price);
			}
			return result;
		}
		#endregion
	}
}
