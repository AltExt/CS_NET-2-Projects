﻿using System;

namespace CS_NET_2_Projects.Assignments.Additional_Required_Classes
{
	public class Employee: Person, IQuittable
	{
		public Employee(string fName, string lName, int id = 0) : base(fName, lName)
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
			Console.WriteLine("Employee Quit() called");
		}

		public static bool operator== (Employee e1, Employee e2)
		{
			return e1.ID == e2.ID;
		}

		public static bool operator!= (Employee e1, Employee e2)
		{
			return !(e1 == e2);
		}


		// added to stop vs complaining
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// added to stop vs complaining
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public int ID { get; set; }
    }
}