using System;
using CS_NET_2_Projects.Assignments.Additional_Required_Classes;

namespace CS_NET_2_Projects.Assignments
{
	public class MethodAssignment: Assignment
	{
		public MethodAssignment(): base("Method Assignment", "4:D-2", false) { }

		public override void Run()
		{
			// this should technically be the main function for the assignemnt, but the functionallity is the same regardless

			// get user input for a
			int a = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(0, 100);

			// instantiate otherclass
			OtherClass otherClass = new OtherClass();

			Console.WriteLine("Would you like to enter a second number?(y/n)");
			// get user input
			if (MyUtils.ConsoleFunctions.GetBoolFromUser())
			{
				// get user input for b
				int b = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(0, 100);
				// call method with default parameter
				Console.WriteLine("Reault: " + otherClass.TwoNumberOperation(a, b).ToString());
			}
			else
			{
				// call method with default parameter
				Console.WriteLine("Reault: " + otherClass.TwoNumberOperation(a).ToString());
			}
			ClearScreen();
		}
	}
}
