using System;
using System.Collections.Generic;
using System.Linq;
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

			ArrayAssignment();

			Console.ReadLine();
		}

		static void ArrayAssignment()
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

			ResetConcoleColors();
		}

		static void ResetConcoleColors()
		{
			Console.BackgroundColor = bgInitialColor;
			Console.ForegroundColor = fgInitialColor;
		}

		private static ConsoleColor bgInitialColor;
		private static ConsoleColor fgInitialColor;
	}
}
