using System;

namespace CS_NET_2_Projects.Assignments
{
	public class CallingMethodsAssignment: Assignment
	{
		public CallingMethodsAssignment():base("Calling Methods Assignment", "4:B") { }

		public override void Run()
		{
			// this should technically be the main function for the assignemnt, but the functionallity is the same regardless

			// get user input
			int n = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(0, 100);
			// call all methods and display results
			Console.WriteLine("AddOne:    " + AddOne(n).ToString());
			Console.WriteLine("SubOne:    " + SubOne(n).ToString());
			Console.WriteLine("MultByTwo: " + MultByTwo(n).ToString());
		}

		// three methods taking one int parameter and returnint one int
		private static int AddOne(int i) { return i + 1; }
		private static int SubOne(int i) { return i - 1; }
		private static int MultByTwo(int i) { return i * 2; }
	}
}
