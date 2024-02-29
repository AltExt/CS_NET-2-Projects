using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_NET_2_Projects
{
	public class Employee: Person, IQuittable
	{
		public Employee(string fName, string lName, int id) : base(fName, lName)
		{
			ID = id;
		}

		public override void SayName()
		{
			base.SayName();
			Console.WriteLine("ID: " + ID.ToString());
		}

		public void Quit()
		{
			Console.WriteLine("Quit method called from employee class");
		}

        public int ID { get; set; }
    }
}
