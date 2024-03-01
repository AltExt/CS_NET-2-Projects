using CS_NET_2_Projects.Assignments.Additional_Required_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_NET_2_Projects.Assignments
{
	public class PolymorphismAssignment: Assignment
	{
		public PolymorphismAssignment():base("Polymorphism Assignment", "5:D", true) { }

		public override void Run()
		{
			// create object of type IQuittable from employee class inheriting from IQuittable interface and call quit function
			IQuittable quittableEmployee = new Employee("F_Name", "L_Name");
			quittableEmployee.Quit();

			// second class inheriting from IQuittable
			IQuittable quittableEmployeeFromAbstract = new Employee_FromAbstract("F_Name", "L_Name");
			quittableEmployeeFromAbstract.Quit();
		}
	}
}
