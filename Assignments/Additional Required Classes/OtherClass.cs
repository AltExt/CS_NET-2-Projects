using System;

namespace CS_NET_2_Projects.Assignments.Additional_Required_Classes
{
	public class OtherClass
	{
		public OtherClass() { }

		// main method assignment methods (4:C-1)
		public int MathOperation(int i) { return i + 1; }
		public decimal MathOperation(decimal i) { return i / 2; }
		public string MathOperation(string i) { return (Convert.ToDecimal(i) / 2).ToString(); }

		// method assignment (4:C-2)
		public int TwoNumberOperation(int x, int y = 2) { return x * y; }
		
		// method class assignment (4:C-3)
		public void TwoNumbers(int x, int y)
		{
			Console.WriteLine(x.ToString() + " * 2 = " + (x * 2).ToString());
			Console.WriteLine("y: " + y.ToString());
		}

		// class method assignment (4:E)
		public void HalfInput(int input) 
		{
			// void function that takes in a number and halfs it, wtiring that to screen
			Console.WriteLine(input.ToString() + " / 2 = " + (input / 2).ToString()); 
		}
		
		// overloaded function with output parameter (4:E)
		public void HalfInput(int input, out int output) { output = input / 2; }
	}
}
