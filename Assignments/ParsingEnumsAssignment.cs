using System;

namespace CS_NET_2_Projects.Assignments
{
	public enum DayOfTheWeek
	{
		Monday = 0,
		Tuesday,
		Wednesday,
		Thursday,
		Friday,
		Saturday,
		Sunday
	}

	public class ParsingEnumsAssignment: Assignment
	{
		public ParsingEnumsAssignment(): base("Parsing Enums Assignment", "6:C") { }

		public override void Run()
		{
			DayOfTheWeek day = (DayOfTheWeek)(MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(Convert.ToInt32(DayOfTheWeek.Monday), Convert.ToInt32(DayOfTheWeek.Sunday)));

			Console.WriteLine("Selected: " + nameof(day));
		}
	}
}
