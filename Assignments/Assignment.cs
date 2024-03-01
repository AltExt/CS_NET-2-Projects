namespace CS_NET_2_Projects
{
	public abstract class Assignment
	{
		public Assignment(string name, string module, bool subrequired = false)
		{
			Name = name;
			Module = module;
			SubmissionRequired = subrequired;
		}

		public abstract void Run();

        public string Name { get; set; }
        public string Module { get; set; }
		public bool SubmissionRequired { get; set; }

		protected void ClearScreen()
		{
			MyUtils.ConsoleFunctions.WaitForEnter(true);
		}
    }
}
