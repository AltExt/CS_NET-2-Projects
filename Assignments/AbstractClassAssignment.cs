using CS_NET_2_Projects.Assignments.Additional_Required_Classes;

namespace CS_NET_2_Projects.Assignments
{
	public class AbstractClassAssignment: Assignment
	{
		public AbstractClassAssignment():base("Abstract Class Assignment", "5:C") { }

		public override void Run()
		{
			// create employee and call sayname
			Employee_FromAbstract employee = new Employee_FromAbstract("Sample", "Student");
			employee.SayName();
		}
	}
}
