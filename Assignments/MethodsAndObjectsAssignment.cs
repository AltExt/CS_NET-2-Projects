using CS_NET_2_Projects.Assignments.Additional_Required_Classes;

namespace CS_NET_2_Projects.Assignments
{
	public class MethodsAndObjectsAssignment: Assignment
	{
		public MethodsAndObjectsAssignment(): base("Methods and Objects Assignment", "5:A") { }

		public override void Run()
		{
			// create employee object and call sayname method
			Employee employee = new Employee("Sample", "Student");
			employee.SayName();
		}
	}
}
