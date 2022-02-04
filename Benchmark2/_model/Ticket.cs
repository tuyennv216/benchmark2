using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benmark2._model
{
	public class Ticket
	{
		public string Name { get; set; } = string.Empty;
		public int Value { get; set; }
		public float Price { get; set; }
		public DateTime DateTime { get; set; }

		public Ticket(string name, int value, DateTime dateTime)
		{
			Name = name;
			Value = value;
			DateTime = dateTime;
		}

		public Ticket(string name, int value, float price, DateTime dateTime)
		{
			Name = name;
			Value = value;
			Price = price;
			DateTime = dateTime;
		}

		public override string ToString()
		{
			return $"{Name} {Value} {DateTime.ToUniversalTime()}";
		}
	}
}
