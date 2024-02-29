using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace CS_NET_2_Projects
{
	public class OtherClass
	{
		public OtherClass() { }

		public int MathOperation(int i) { return i + 1; }
		public decimal MathOperation(decimal i) { return i / 2; }
		public string MathOperation(string i) { return (Convert.ToDecimal(i) / 2).ToString(); }

		public int TwoNumberOperation(int x, int y = 2) { return x * y; }
		public void TwoNumbers(int x, int y)
		{
			Console.WriteLine(x.ToString() + " * 2 = " + (x * 2).ToString());
			Console.WriteLine("y: " + y.ToString());
		}
	}
}
