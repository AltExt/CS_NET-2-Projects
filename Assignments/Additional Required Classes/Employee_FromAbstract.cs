using System;

namespace CS_NET_2_Projects.Assignments.Additional_Required_Classes
{
	public class Employee_FromAbstract: Person_Abstract, IQuittable
	{
		public Employee_FromAbstract(string fName, string lName): base(fName, lName) { }

		public override void SayName()
		{
			Console.WriteLine("SayName called from Employee using abstract person base class\n>" + FName + " " + LName);
		}

		public void Quit()
		{
			Console.WriteLine("Employee_FromAbstract Quit() called");
		}
	}
}
