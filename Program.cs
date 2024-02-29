using System;
using System.Collections.Generic;
using System.Linq;

namespace CS_NET_2_Projects
{
	public class Program
	{
		static void Main()
		{
			MyUtils.ConsoleFunctions.SetInitialConsoleColors();

			AssignmentViewer viewer = new AssignmentViewer();
			viewer.Run();
		}
	}
}
