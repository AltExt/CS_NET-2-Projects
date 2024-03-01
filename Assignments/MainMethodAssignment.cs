using System;
using CS_NET_2_Projects.Assignments.Additional_Required_Classes;

namespace CS_NET_2_Projects.Assignments
{
	public class MainMethodAssignment: Assignment
	{
		public MainMethodAssignment() : base("Main Method Assignment", "4:D-1") { }

		public override void Run()
		{
			// this should technically be the main function for the assignemnt, but the functionallity is the same regardless
			
			// declare variables to be used
			int x = 10;
			decimal y = 15.0m;
			string z = "100";

			// instantiate otherclass
			OtherClass otherClass = new OtherClass();

			// call overloaded method and display results
			Console.WriteLine("Integer: " + otherClass.MathOperation(x).ToString());
			Console.WriteLine("Decimal: " + otherClass.MathOperation(y).ToString());
			Console.WriteLine("String:  " + otherClass.MathOperation(z));
		}
	}
}
