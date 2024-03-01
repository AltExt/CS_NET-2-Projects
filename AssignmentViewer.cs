using CS_NET_2_Projects.Assignments;
using System;
using System.Collections.Generic;

namespace CS_NET_2_Projects
{
	public enum ConsoleAppKeyAction
	{ 
		NoAciton,
		RunSelected,
		Quit
	}

	public class AssignmentViewer
	{
		public AssignmentViewer()
		{
			// add all assignments to the list
			assignments.Add(new ArrayAssignment());
			assignments.Add(new IterationSixPartAssignment());
			assignments.Add(new ConsoleAppStringsAndIntegersAssignment());
			assignments.Add(new CallingMethodsAssignment());
			assignments.Add(new MainMethodAssignment());
			assignments.Add(new MethodAssignment());
			assignments.Add(new MethodClassAssignment());
			assignments.Add(new ClassMethodAssignment());
			assignments.Add(new MethodsAndObjectsAssignment());
			assignments.Add(new AbstractClassAssignment());
			assignments.Add(new PolymorphismAssignment());
			assignments.Add(new OperatorAssignment());
			assignments.Add(new ParametersAssignment());
			assignments.Add(new ParsingEnumsAssignment());
			assignments.Add(new StructAssignment());
			assignments.Add(new LambdaExpressionAssignment());

			// get initial console colors
			BGInitialColor = Console.BackgroundColor;
			FGInitialColor = Console.ForegroundColor;

			// figure out the max length of the assignment name and the module name to line everything up
			string menuNameHeading = "Assignment Name";
			string menuModuleHeading = "Module";

			int nameMaxSize = menuNameHeading.Length;
			int moduleMaxSize = menuModuleHeading.Length;
			for (int i = 0; i < assignments.Count; i++)
			{
				if (assignments[i].Name.Length > nameMaxSize) nameMaxSize = assignments[i].Name.Length;
				if (assignments[i].Module.Length > moduleMaxSize) moduleMaxSize = assignments[i].Module.Length;
			}

			// this allows me to have [i]: on each line
			nameMaxSize += "iii: ".Length;

			// create the main menu heading that will be displayed
			while (menuNameHeading.Length < nameMaxSize) menuNameHeading += ' ';
			while (menuModuleHeading.Length < moduleMaxSize) menuModuleHeading += ' ';
			string menuSubmissionRequiredHeading = "Submission Required";

			// define consistant tab and newline strings
			string tabString = "  |  ";
			string newLineString = "\n";

			MainMenuHeading = menuNameHeading + tabString + menuModuleHeading + tabString + menuSubmissionRequiredHeading + newLineString;
			int len = MainMenuHeading.Length;
			for (int i = 0; i < len; i++)
			{
				MainMenuHeading += "=";
			}
			MainMenuHeading += newLineString;

			int maxLineStrLen = 0;
			for (int i = 0; i < assignments.Count; i++)
			{
				// write the name + spacing so everything lines up
				string name = i.ToString() + ": " + assignments[i].Name;
				while (name.Length < nameMaxSize) name += ' ';

				// write the module + spacing so everything lins up
				string module =  assignments[i].Module;
				while (module.Length < moduleMaxSize) module += ' ';

				// add the submission required string
				string requiredString = assignments[i].SubmissionRequired ? ("Required") : ("Not Required");

				// create a single line from above strings
				string lineStr = name + tabString + module + tabString + requiredString + newLineString;

				// track the maxLen of these strings
				if (lineStr.Length > maxLineStrLen) maxLineStrLen = lineStr.Length;

				// add to main menu list
				MainMenu.Add(lineStr);
			}
			
			// create the footer
			MainMenuFooter = "";
			while (MainMenuFooter.Length < maxLineStrLen) MainMenuFooter += "=";
			MainMenuFooter += newLineString;
		}

		public void Run()
		{
			bool running = true;

			while (running)
			{
				// display assignment list
				DisplayMainMenu();

				// select assignment
				GetUserSelection();

				// view assignment
				running = ViewSelectedAssignment();

				// clear screen
				ClearScreen();
			}
		}

		private void DisplayMainMenu()
		{
			Console.Clear();
			Console.Write(MainMenuHeading);
			for (int i = 0; i < MainMenu.Count; i++)
			{
				if (i == CurrentAssignment)
				{
					Console.BackgroundColor = ConsoleColor.White;
					Console.ForegroundColor = ConsoleColor.Black;
				}
				Console.Write(MainMenu[i]);
				if (i == CurrentAssignment)
				{
					Console.BackgroundColor = BGInitialColor;
					Console.ForegroundColor = FGInitialColor;
				}
			}
			Console.Write(MainMenuFooter);
		}

		private void GetUserSelection()
		{
			ConsoleKey pressedKey = MyUtils.ConsoleFunctions.GetConsoleKeyFromUser();

			keyAction = ConsoleAppKeyAction.NoAciton;

			switch (pressedKey)
			{
				case ConsoleKey.UpArrow:
					CurrentAssignment--;
					if (CurrentAssignment == -1) CurrentAssignment = assignments.Count - 1;
					break;
				case ConsoleKey.DownArrow:
					CurrentAssignment++;
					if (CurrentAssignment == assignments.Count) CurrentAssignment = 0;
					break;
				case ConsoleKey.Enter:
					keyAction = ConsoleAppKeyAction.RunSelected;
					break;
				case ConsoleKey.Q:
				case ConsoleKey.Escape:
					keyAction = ConsoleAppKeyAction.Quit;
					break;
			}
		}

		private bool ViewSelectedAssignment()
		{
			/**/ if (keyAction == ConsoleAppKeyAction.Quit)
			{
				return false;
			}
			else if (keyAction == ConsoleAppKeyAction.RunSelected)
			{
				ClearScreen();
				assignments[CurrentAssignment].Run();
				Pause();
				ClearScreen();
			}

			return true;
		}

		private void ClearScreen()
		{
			Console.Clear();
		}

		private void Pause()
		{
			MyUtils.ConsoleFunctions.WaitForEnter();
		}

		private int CurrentAssignment = 0;
		private ConsoleAppKeyAction keyAction = ConsoleAppKeyAction.NoAciton;

		private readonly List<Assignment> assignments = new List<Assignment>();
		private readonly List<string> MainMenu = new List<string>();
		
		private readonly string MainMenuHeading = "";
		private readonly string MainMenuFooter = "";
		
		private readonly ConsoleColor BGInitialColor;
		private readonly ConsoleColor FGInitialColor;
	}
}