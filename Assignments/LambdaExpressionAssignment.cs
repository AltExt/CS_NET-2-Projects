using CS_NET_2_Projects.Assignments.Additional_Required_Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS_NET_2_Projects.Assignments
{

	public class LambdaExpressionAssignment: Assignment
	{
		public LambdaExpressionAssignment(): base("Lamba Expression Assignment", "6:E") { }

		public override void Run()
		{
			// employee list
			List<Employee> employees = new List<Employee>();
			employees.Add(new Employee("Alice", "lName", 0));
			employees.Add(new Employee("Joe", "lName", 1));
			employees.Add(new Employee("Bob", "lName", 2));
			employees.Add(new Employee("Joe", "lName", 3));
			employees.Add(new Employee("Charlie", "lName", 4));
			employees.Add(new Employee("Denis", "lName", 5));
			employees.Add(new Employee("Eoghan", "lName", 6));
			employees.Add(new Employee("Finbarr", "lName", 7));
			employees.Add(new Employee("Ger", "lName", 8));
			employees.Add(new Employee("Harry", "lName", 9));

			// foreach method to find all joes
			List<Employee> joeList = new List<Employee>();
			foreach(Employee e in employees)
			{
				if (e.FName == "Joe") { joeList.Add(e); }
			}

			// print to screen
			Console.WriteLine("All Joes: ");
			foreach(Employee e in joeList) e.SayName();

			joeList.Clear();

			// lamda expression to find all joes
			joeList = employees.Where(e => e.FName == "Joe").ToList();

			// print to screen
			Console.WriteLine("\n\nAll Joes: ");
			foreach (Employee e in joeList) e.SayName();

			// find all employees with ID > 5
			List<Employee> idGreaterThanFive = employees.Where(e => e.ID > 5).ToList();

			// print to screen
			Console.WriteLine("\n\nAll Employess.ID > 5: ");
			foreach (Employee e in idGreaterThanFive) e.SayName();
		}
	}
}
