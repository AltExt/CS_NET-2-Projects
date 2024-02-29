#pragma warning disable CS0168 // Variable is declared but never used
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS_NET_2_Projects
{
	public class Program
	{
		static void Main()
		{
			bgInitialColor = Console.BackgroundColor;
			fgInitialColor = Console.ForegroundColor;

			SelectAssignment();
		}

		private static void SelectAssignment()
		{

			List<string> assignmentNames = new List<string>
			{
				"Array Assignment",
				"Iteration Assignment",
				"Console App Strings and Integers Assignment",
				"CallingMethodsAssignment",
				"Exit Application"
			};

			int selection = 0;
			bool running = true;

			while (running)
			{
				//Console.WriteLine(">Display"); Console.ReadLine();
				DisplayAssignmentList(ref assignmentNames);
				//Console.WriteLine("Done"); Console.ReadLine();

				//Console.WriteLine(">GetSelection"); Console.ReadLine();
				selection = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(0, assignmentNames.Count - 1);
				//Console.WriteLine("Done"); Console.ReadLine();

				//Console.WriteLine(">Running"); Console.ReadLine();
				running = RunSelectedAssignment(selection, ref assignmentNames);
				//Console.WriteLine("Done"); Console.ReadLine();

				//Console.WriteLine("Reset Colors"); Console.ReadLine();
				ResetConsoleColors();
				//Console.WriteLine("Done"); Console.ReadLine();
			}
		}

		private static void DisplayAssignmentList(ref List<string> assignmentNames)
		{
			Console.Clear();
			Console.WriteLine("Please choose an assignment to view: ");
			for (int i = 0; i < assignmentNames.Count; i++)
			{
				Console.WriteLine("\t>" + i.ToString() + ": " + assignmentNames[i]);
			}
			Console.WriteLine("====================");
		}

		private static bool RunSelectedAssignment(int selection, ref List<string> assignmentNames)
		{
			if (selection != assignmentNames.Count() - 1)
			{
				Console.Clear();
				Console.WriteLine("Viewing assignment " + assignmentNames[selection]);
			}
			else
			{
				return false;
			}

			switch(selection)
			{
				case 0:
					ArrayAssignment();
					break;
				case 1:
					IterationConsoleAppAssignment();
					break;
				case 2:
					ConsoleAppStringsAndIntegersAssignemnt();
					break;
				case 3:
					CallingMethodsAssignment();
					break;
				default:
					return false;
			}
			return true;
		}

		private static void ArrayAssignment()
		{
			// instansiate and initialise string array, get index from the user and display to screen
			string[] stringArray = { "string0", "string1", "string2", "string3", "string4" };
			int selection = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(0, stringArray.Length);
			Console.WriteLine("You chose strinArray[" + selection.ToString() + "]\nContains: " + stringArray[selection]);

			// same as above for an int array
			int[] intArray = { 9, 8, 7, 3, 2, 1, 4, 5, 6};
			selection = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(0, intArray.Length);
			Console.WriteLine("You chose stringArray[" + selection.ToString() + "]\nContains: " + intArray[selection]);

			// same as above for an string list, for loop to initialise list with "string0", "string1"...
			List<string> stringList = new List<string>();
			for (int i = 0; i < 5; i++) stringList.Add("string" + i.ToString());
			selection = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(0, stringList.Count - 1);
			Console.WriteLine("You chose stringList[" + selection.ToString() + "]\nContains: " + stringList[selection]);
		}

		private	static void IterationConsoleAppAssignment()
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
			PauseThenClearScreen();


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
			PauseThenClearScreen();


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
			PauseThenClearScreen();


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
			PauseThenClearScreen();


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
			PauseThenClearScreen();


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
					if ( testString == uniqueString )
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
			PauseThenClearScreen();
		}

		private static void ConsoleAppStringsAndIntegersAssignemnt()
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
			finally
			{
				PauseThenClearScreen();
			}
#pragma warning restore CS0168 // Variable is declared but never used
		}

		private static void CallingMethodsAssignment()
		{
			// calling methods assignment
			Console.WriteLine("Part 1:");
			int n = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(0, 100);
			Console.WriteLine("AddOne:    " + AddOne(n).ToString());
			Console.WriteLine("SubOne:    " + SubOne(n).ToString());
			Console.WriteLine("MultByTwo: " + MultByTwo(n).ToString());
			PauseThenClearScreen();


			// main method assignment
			Console.WriteLine("Part 2");
			int x = 10;
			decimal y = 15.0m;
			string z = "100";
			OtherClass otherClass = new OtherClass();
			Console.WriteLine("Integer: " + otherClass.MathOperation(x).ToString());
			Console.WriteLine("Decimal: " + otherClass.MathOperation(y).ToString());
			Console.WriteLine("String:  " + otherClass.MathOperation(z));
			PauseThenClearScreen();


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
			PauseThenClearScreen();

			// method class assignment
			Console.WriteLine("Part 4");
			otherClass.TwoNumbers(5, 10);
			a = 15;
			b = 20;
			otherClass.TwoNumbers(a, b);
			PauseThenClearScreen();

		}

		private static int AddOne(int i) { return i + 1; }
		private static int SubOne(int i) { return i - 1; }
		private static int MultByTwo(int i) { return i * 2; }

		private static void ResetConsoleColors()
		{
			Console.BackgroundColor = bgInitialColor;
			Console.ForegroundColor = fgInitialColor;
		}

		private static void PauseThenClearScreen()
		{
			Console.WriteLine("Press enter button to continue:");
			Console.ReadLine();
			Console.Clear();
		}

		private static ConsoleColor bgInitialColor;
		private static ConsoleColor fgInitialColor;
	}
}
