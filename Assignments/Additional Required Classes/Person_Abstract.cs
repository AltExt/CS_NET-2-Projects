namespace CS_NET_2_Projects.Assignments.Additional_Required_Classes
{
	public abstract class Person_Abstract
	{
		public Person_Abstract(string fName, string lName) 
		{
			FName = fName;
			LName = lName;
		}

		public abstract void SayName();

        public string FName { get; set; }
        public string LName { get; set; }
    }
}
