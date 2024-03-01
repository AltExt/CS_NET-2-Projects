using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_NET_2_Projects.Assignments.Additional_Required_Classes
{
	public class EmployeeGeneric<T>: Employee
	{
		public EmployeeGeneric(): this("fName", "lName", 0) { }

		public EmployeeGeneric(string fName, string lName, int id): base(fName, lName, id) 
		{
			Things = new List<T>();
		}

		public void PrintThingsList()
		{
			foreach (var thing in Things) Console.WriteLine(thing.ToString());
		}

        public List<T> Things{ get; set; }
	}
}
