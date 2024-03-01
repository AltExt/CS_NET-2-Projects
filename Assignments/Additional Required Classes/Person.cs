using System;

namespace CS_NET_2_Projects.Assignments.Additional_Required_Classes
{
	public abstract class Person
	{
        public Person(string fName, string lName)
        {
            FName = fName;
            LName = lName;
        }

        public string LName { get; set; }
        public string FName { get; set; }
        public virtual void SayName() 
        {
            Console.WriteLine("Name: " + FName + " " + LName);
        } 

    }
}
