using CS_NET_2_Projects.Assignments.Additional_Required_Classes;

namespace CS_NET_2_Projects.Assignments
{
	public class MethodClassAssignment: Assignment
	{
		public MethodClassAssignment(): base("Method Class Assignment", "4:D-3", true) { }

		public override void Run()
		{
			// this should technically be the main function for the assignemnt, but the functionallity is the same regardless

			// instantiate otherclass
			OtherClass otherClass = new OtherClass();

			// call method using numbers
			otherClass.TwoNumbers(5, 10);

			// declare variables and call method using them
			int a = 15; int b = 20;
			otherClass.TwoNumbers(a, b);
		}
	}
}
