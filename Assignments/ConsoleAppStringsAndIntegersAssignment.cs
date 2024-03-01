#pragma warning disable CS0168 // Variable is declared but never used
using System;
using System.Collections.Generic;

namespace CS_NET_2_Projects.Assignments
{
	public class ConsoleAppStringsAndIntegersAssignment: Assignment
	{
		public ConsoleAppStringsAndIntegersAssignment():base("Console App Strings And Integers Assignment", "3:B") { }

		public override void Run()
		{
			try
			{
				// create an integer list
				List<int> ints = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
				// display the list
				for (int i = 0; i < ints.Count; i++)
				{
					Console.Write(ints[i].ToString());
					if (i != ints.Count - 1) Console.Write(", ");
					else Console.Write("\n");
				}

				// get user input for divisor
				int min = 0; int max = 100;
				int divisor = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(min, max,
					"Please enter a number for all values to be divided by: ",
					("Please enter a number between " + min.ToString() + " and " + max.ToString())
				);

				// divide all numbers by divisor and write to screen
				for (int i = 0; i < ints.Count; i++)
				{
					Console.Write((ints[i] / divisor).ToString());
					if (i != ints.Count - 1) Console.Write(", ");
					else Console.Write("\n");
				}
			}
			catch (DivideByZeroException ex) // if the user inputs 0
			{
				Console.WriteLine("Please don't divide by 0!");
			}
			catch (FormatException ex) // if the user inputs any non integer value
			{
				Console.WriteLine("Please enter an integer value!");
			}
			catch (Exception ex) // all other exceptions
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
#pragma warning restore CS0168 // Variable is declared but never used