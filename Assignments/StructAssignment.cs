using System;

namespace CS_NET_2_Projects.Assignments
{
	struct Number
	{ 
		public int Value;
	}
	
	public class StructAssignment:Assignment
	{
		public StructAssignment(): base("Struct Assignment", "6:D") { }

		public override void Run()
		{
			Number n;
			n.Value = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(0, 100);
			Console.WriteLine("Struct contains: " + n.Value.ToString());
		}
	}
}
