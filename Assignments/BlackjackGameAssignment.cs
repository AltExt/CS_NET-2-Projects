using CS_NET_2_Projects.Assignments.Blackjack_Game_Requirements;

namespace CS_NET_2_Projects.Assignments
{
	public class BlackjackGameAssignment: Assignment
	{
		public BlackjackGameAssignment():base("Blackjack Game", "7:A", true) 
		{
			TheGame = new BlackjackGame();
		}

		public override void Run()
		{
			TheGame.Play();
		}

		private BlackjackGame TheGame;
	}
}
