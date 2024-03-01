using CS_NET_2_Projects.Assignments.Additional_Required_Classes;
using System;

namespace CS_NET_2_Projects.Assignments
{
	public class OperatorAssignment: Assignment
	{
		public OperatorAssignment(): base("Operator Assignment", "6-A", true) { }

		public override void Run()
		{
			// e1 == e2, e1 != e3, e2 != e3
			Employee e1 = new Employee("Alice", "Gross", 0);
			Employee e2 = new Employee("Alice", "Gross", 0);
			Employee e3 = new Employee("Bob", "Pinkman", 1);

			Console.WriteLine("e1: ");
			e1.SayName();
			Console.WriteLine("e2: ");
			e2.SayName();
			Console.WriteLine("e3: ");
			e3.SayName();

			string output = (e1 == e2) ? "e1 == e2" : "e1 != e2";
			Console.WriteLine(output);

			output = (e1 == e3) ? "e1 == e3" : "e1 != e3";
			Console.WriteLine(output);

			output = (e2 == e3) ? "e2 == e3" : "e2 != e3";
			Console.WriteLine(output);
		}
	}
}
