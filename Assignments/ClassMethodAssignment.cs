using System;
using CS_NET_2_Projects.Assignments.Additional_Required_Classes;

namespace CS_NET_2_Projects.Assignments
{
	public class ClassMethodAssignment: Assignment
	{
		public ClassMethodAssignment(): base("Class Method Assignment", "4:E", false) { }

		public override void Run()
		{
			// instantiate the otherclass
			OtherClass otherClass = new OtherClass();
			// get user input
			int input = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(0, 100);
			// call overloaded function halfinput with one parameter
			otherClass.HalfInput(input);

			// get user input
			input = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(0, 100);
			// call overloaded method halfinput with out parameter
			otherClass.HalfInput(input, out int output);
			Console.WriteLine("Output: " + output.ToString());

			// calling a static method from a static class
			StaticClass.Method();
		}
	}
}
