#pragma warning disable CS0168 // Variable is declared but never used

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_NET_2_Projects
{
	public enum Assignment
	{
		ArrayAssignment = 0,
		IterationAssignment,
		ConsoleAppStringsAndIntegersAssignment,
		CallingMethodsAssignment,
		MethodsAndObjectsAssignment,
		ExitApplication
	}

	public class AssignmentViewer
	{
		public AssignmentViewer()
		{
			mSelectedAssignment = Assignment.ArrayAssignment;
			for (int i = 0; i < Convert.ToInt32(Assignment.ExitApplication) + 1; i++)
			{
				mAssignmentNames.Add( Enum.GetName(typeof(Assignment), i) );
			}
		}

		public void Run()
		{
			bool running = true;

			while (running)
			{
				// select assignment
				GetUserSelection();

				// view assignment
				running = ViewSelectedAssignment();

				// clear screen
				ClearScreen();
			}
		}

		private void GetUserSelection()
		{
			Console.WriteLine("Assignment List: ");
			for (int i = 0; i < mAssignmentNames.Count; i++) Console.WriteLine("\t" + i.ToString() + ": " + mAssignmentNames[i]);
			Console.WriteLine("====================");

            mSelectedAssignment = (Assignment)(MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(0, Convert.ToInt32(Assignment.ExitApplication)));
		}

		private bool ViewSelectedAssignment()
		{
			switch (mSelectedAssignment)
			{
				case Assignment.ArrayAssignment:
					ArrayAssignment();
					break;
				case Assignment.IterationAssignment:
					IterationAssignment();
					break;
				case Assignment.ConsoleAppStringsAndIntegersAssignment:
					ConsoleAppStringsAndIntegersAssignment();
					break;
				case Assignment.CallingMethodsAssignment:
					CallingMethodsAssignment();
					break;
				case Assignment.MethodsAndObjectsAssignment:
					MethodsAndObjectsAssignment();
					break;
				case Assignment.ExitApplication:
					return false;
			}
			return true;
		}

		private void ClearScreen()
		{
			MyUtils.ConsoleFunctions.WaitForEnter(true);
		}

		private void ArrayAssignment()
		{
			// instansiate and initialise string array, get index from the user and display to screen
			string[] stringArray = { "string0", "string1", "string2", "string3", "string4" };
			int selection = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(0, stringArray.Length);
			Console.WriteLine("You chose strinArray[" + selection.ToString() + "]\nContains: " + stringArray[selection]);

			// same as above for an int array
			int[] intArray = { 9, 8, 7, 3, 2, 1, 4, 5, 6 };
			selection = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(0, intArray.Length);
			Console.WriteLine("You chose stringArray[" + selection.ToString() + "]\nContains: " + intArray[selection]);

			// same as above for an string list, for loop to initialise list with "string0", "string1"...
			List<string> stringList = new List<string>();
			for (int i = 0; i < 5; i++) stringList.Add("string" + i.ToString());
			selection = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(0, stringList.Count - 1);
			Console.WriteLine("You chose stringList[" + selection.ToString() + "]\nContains: " + stringList[selection]);
		}

		private void IterationAssignment()
		{
			// Assignment Part 1
			Console.WriteLine("Assignment Part 1:");

			// instantiate and initialise string array
			string[] stringArray = new string[5];
			for (int i = 0; i < stringArray.Length; i++) stringArray[i] = "string" + i.ToString() + "\t>";

			// get user string input
			string userInput = MyUtils.ConsoleFunctions.GetTextFromUser();

			// append user input to each string
			for (int i = 0; i < stringArray.Length; i++) stringArray[i] += userInput;

			// write each string to the screen
			for (int i = 0; i < stringArray.Length; i++) Console.WriteLine("stringArray[" + i.ToString() + "]:" + stringArray[i]);
			ClearScreen();


			// Assignment Part 2
			Console.WriteLine("Assignment Part 2");

			// Create an infinite loop
			/*
			while (true)
			{
				Console.WriteLine("This is an infinite loop!");
			}
			*/

			// Fix the loop by adding an exit condition
			int max = 10;
			while (max >= 0)
			{
				Console.WriteLine("This is no longer an infinite loop!");
				max--;
			}
			ClearScreen();


			// Assignment Part 3
			Console.WriteLine("Assignment Part 3");

			// Loop using < operator
			Console.WriteLine("Loop using < operator");
			const int REPS = 5;
			for (int i = 0; i < REPS; i++)
			{
				Console.Write(i.ToString());
				if (i != REPS - 1) Console.Write(", ");
				else Console.Write("\n");
			}

			// Loop using <= operator
			Console.WriteLine("Loop using <= operator");
			for (int i = 0; i <= 4; i++)
			{
				Console.Write(i.ToString());
				if (i != REPS - 1) Console.Write(", ");
				else Console.Write("\n");
			}
			ClearScreen();


			// Assignment Part 4
			Console.WriteLine("Assignment Part 4");

			// Create list of unique strings
			List<string> uniqueStrings = new List<string>
			{
				"Alice",
				"Bob",
				"Charlie"
			};

			// get user input
			string userinput = MyUtils.ConsoleFunctions.GetTextFromUser("Enter a name to search:");

			// loop over list and break if a matching stirng to userinput is found
			int match = -1;
			for (int i = 0; i < uniqueStrings.Count; i++)
			{
				if (userinput == uniqueStrings[i])
				{
					match = i;
					break;
				}
			}

			// match will still be -1 if no matching string is found
			if (match == -1)
			{
				Console.WriteLine("No match for '" + userinput + "' found in the list.");
			}
			else
			{
				Console.WriteLine("Match found at index " + match.ToString());
			}
			ClearScreen();


			// Assignment Part 5
			Console.WriteLine("Assignment Part 5");

			// Create list of non unique strings
			List<string> nonUniqueStrings = new List<string>
			{
				"Alice",
				"Bob",
				"Charlie",
				"Bob",
				"Charlie",
				"David"
			};

			// get user input
			userinput = MyUtils.ConsoleFunctions.GetTextFromUser("Enter a name to search:");

			// loop over list and break if a matching stirng to userinput is found
			match = -1;
			for (int i = 0; i < nonUniqueStrings.Count; i++)
			{
				// this will break and return the first matching index to userinput
				if (userinput == nonUniqueStrings[i])
				{
					match = i;
					break;
				}
			}

			// match will still be -1 if no matching string is found
			if (match == -1)
			{
				Console.WriteLine("No match for '" + userinput + "' found in the list.");
			}
			else
			{
				Console.WriteLine("Match found at index " + match.ToString());
			}
			ClearScreen();


			// Assignment Part 6
			Console.WriteLine("Assignment Part 6");

			// re using the unique and non unique list from previous part
			uniqueStrings = new List<string>();

			// loop over each non unique element
			foreach (string testString in nonUniqueStrings)
			{
				match = 0;

				// loop over each known unique element to compare
				foreach (string uniqueString in uniqueStrings)
				{
					// if they match we don't need to go any further
					if (testString == uniqueString)
					{
						match = 1;
						break;
					}
				}

				// if there is no match add that item to the unique elememt list
				if (match == 0)
				{
					Console.WriteLine(testString + "\tThis item is unique");
					uniqueStrings.Add(testString);
				}
				// otherwise inform user of a match
				else
				{
					Console.WriteLine(testString + "\tThis item is not unique");
				}
			}
		}

		private void ConsoleAppStringsAndIntegersAssignment()
		{
			try
			{
				List<int> ints = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
				for (int i = 0; i < ints.Count; i++)
				{
					Console.Write(ints[i].ToString());
					if (i != ints.Count - 1) Console.Write(", ");
					else Console.Write("\n");
				}

				Console.WriteLine("Please enter a number for all values to be divided by: ");
				int divisor = Convert.ToInt32(Console.ReadLine());
				for (int i = 0; i < ints.Count; i++)
				{
					Console.Write((ints[i] / divisor).ToString());
					if (i != ints.Count - 1) Console.Write(", ");
					else Console.Write("\n");
				}
			}
			catch (DivideByZeroException ex)
			{
				Console.WriteLine("Please don't divide by 0!");
			}
			catch (FormatException ex)
			{
				Console.WriteLine("Please enter an integer value!");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void CallingMethodsAssignment()
		{
			// calling methods assignment
			Console.WriteLine("Part 1:");
			int n = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(0, 100);
			Console.WriteLine("AddOne:    " + AddOne(n).ToString());
			Console.WriteLine("SubOne:    " + SubOne(n).ToString());
			Console.WriteLine("MultByTwo: " + MultByTwo(n).ToString());
			ClearScreen();


			// main method assignment
			Console.WriteLine("Part 2");
			int x = 10;
			decimal y = 15.0m;
			string z = "100";
			OtherClass otherClass = new OtherClass();
			Console.WriteLine("Integer: " + otherClass.MathOperation(x).ToString());
			Console.WriteLine("Decimal: " + otherClass.MathOperation(y).ToString());
			Console.WriteLine("String:  " + otherClass.MathOperation(z));
			ClearScreen();


			// method assignment
			Console.WriteLine("Part 3");
			int a = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(0, 100);
			int b = 0;
			Console.WriteLine("Would you like to enter a second number?(y/n)");
			if (MyUtils.ConsoleFunctions.GetBoolFromUser())
			{
				b = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(0, 100);
				Console.WriteLine("Reault: " + otherClass.TwoNumberOperation(a, b).ToString());
			}
			else
			{
				Console.WriteLine("Reault: " + otherClass.TwoNumberOperation(a).ToString());
			}
			ClearScreen();

			// method class assignment
			Console.WriteLine("Part 4");
			otherClass.TwoNumbers(5, 10);
			a = 15;
			b = 20;
			otherClass.TwoNumbers(a, b);
		}

		private void MethodsAndObjectsAssignment()
		{
			// create employee
			Employee e = new Employee("Sample", "Student", 0);

			// call sayname
			e.SayName();
		}

		private static int AddOne(int i) { return i + 1; }
		private static int SubOne(int i) { return i - 1; }
		private static int MultByTwo(int i) { return i * 2; }

		private readonly List<string> mAssignmentNames = new List<string>();
		private Assignment mSelectedAssignment = Assignment.ArrayAssignment;
	}
}