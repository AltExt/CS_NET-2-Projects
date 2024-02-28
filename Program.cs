using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using MyUtils;

namespace CS_NET_2_Projects
{
	internal class Program
	{
		static void Main()
		{
			bgInitialColor = Console.BackgroundColor;
			fgInitialColor = Console.ForegroundColor;

			SelectAssignment();
		}

		private static void SelectAssignment()
		{
			int selection = 0;
			const int MAX_SELECTION = 2;
			bool running = true;

			List<string> assignmentNames = new List<string>
			{
				"Array Assignment",
				"Iteration Assignment",
				"Exit Application"
			};

			while (running)
			{
				DisplayAssignmentList(ref assignmentNames);
				selection = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(0, MAX_SELECTION);
				running = RunSelectedAssignment(selection, ref assignmentNames);
				ResetConsoleColors();
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

			Console.WriteLine("Press any button to continue:");
			Console.ReadKey();
			Console.Clear();


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

			Console.WriteLine("Press any button to continue:");
			Console.ReadKey();
			Console.Clear();


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

			Console.WriteLine("Press any button to continue:");
			Console.ReadKey();
			Console.Clear();


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

			Console.WriteLine("Press any button to continue:");
			Console.ReadKey();
			Console.Clear();


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

			Console.WriteLine("Press any button to continue:");
			Console.ReadKey();
			Console.Clear();


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

			Console.WriteLine("Press any button to continue:");
			Console.ReadKey();
			Console.Clear();
		}

		private static void ResetConsoleColors()
		{
			Console.BackgroundColor = bgInitialColor;
			Console.ForegroundColor = fgInitialColor;
		}

		private static ConsoleColor bgInitialColor;
		private static ConsoleColor fgInitialColor;
	}
}
