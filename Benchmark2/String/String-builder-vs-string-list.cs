using BenchmarkDotNet.Attributes;
using System.Text;

//| BenmarkStringBuilder | 11.06 ms | 3.082 ms | 9.088 ms | 5.477 ms | 562.5000 | 281.2500 | 31.2500 | 4 MB |

//|    BenmarkStringList | 13.41 ms | 0.441 ms | 1.138 ms | 13.173 ms | 2400.0000 | 600.0000 | 200.0000 |     18 MB |

namespace Benmark2.String
{
	[MemoryDiagnoser]
	public class String_builder_vs_string_list
	{
		int NumberOfItems = 1000;

		#region string builder
		[Benchmark]
		public string[] BenmarkStringBuilder()
		{
			var output = new string[NumberOfItems];
			for (var i = 0; i < output.Length; i++)
			{
				output[i] = GetStringBuilder();
			}
			return output;
		}
		public string GetStringBuilder()
		{
			var builder = new StringBuilder();
			for (var j = 0; j < NumberOfItems; j++)
			{
				builder.Append("1");
			}
			return builder.ToString();
		}
		#endregion

		#region string list
		[Benchmark]
		public string[] BenmarkStringList()
		{
			var output = new string[NumberOfItems];
			for (var i = 0; i < output.Length; i++)
			{
				output[i] = GetStringList();
			}
			return output;
		}
		public string GetStringList()
		{
			var list = new List<string>();
			for (var j=0; j<NumberOfItems; j++)
			{
				list.Add("1");
			}
			return string.Join(null, list);
		}
		#endregion
	}
}
