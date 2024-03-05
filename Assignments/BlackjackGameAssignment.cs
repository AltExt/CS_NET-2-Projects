using CS_NET_2_Projects.Assignments.Blackjack_Game_Requirements;

namespace CS_NET_2_Projects.Assignments
{
	public class BlackJackGameAssignment: Assignment
	{
		public BlackJackGameAssignment(): base("BlackJack Game", "7:A", true)
		{
			game = new BlackJackGame();
		}

		public override void Run()
		{
			game.Play();
		}

		private readonly Game game;
	}
}
