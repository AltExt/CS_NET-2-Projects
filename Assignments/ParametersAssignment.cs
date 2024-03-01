using CS_NET_2_Projects.Assignments.Additional_Required_Classes;
using System;
using System.Collections.Generic;

namespace CS_NET_2_Projects.Assignments
{
	public class ParametersAssignment: Assignment
	{
		public ParametersAssignment(): base("Parameter Assignment", "6:B") { }

		public override void Run()
		{
			// create 2 employee generic objects
			EmployeeGeneric<string> stringEmployee = new EmployeeGeneric<string>();
			EmployeeGeneric<int> intEmployee = new EmployeeGeneric<int>();

			// populate the lists
			stringEmployee.Things.Add("s0");
			stringEmployee.Things.Add("s1");
			stringEmployee.Things.Add("s2");
			stringEmployee.Things.Add("s3");
			stringEmployee.Things.Add("s4");

			intEmployee.Things.Add(0);
			intEmployee.Things.Add(1);
			intEmployee.Things.Add(2);
			intEmployee.Things.Add(3);
			intEmployee.Things.Add(4);

			// print contents od each list
			stringEmployee.PrintThingsList();
			intEmployee.PrintThingsList();
		}
	}
}
