namespace Training.CircleSquareGame.Api
{
    public class Game
    {
        public Player[] Players { get; }
        public Board Board { get; }
        public int MaxNumberOfWins { get; }
        public PlayerType CurrentPlayer { get; set; }

        public Game(int maxNumberOfWins)
        {
            Board = new Board();
            MaxNumberOfWins = maxNumberOfWins;
            Players = new[] { new Player(PlayerType.X), new Player(PlayerType.O) };
            CurrentPlayer = PlayerType.X;
        }

        public bool CheckIfWon(Player player)
        {
            if (player.NumberOfWins == MaxNumberOfWins) return true;
            return false;
        }

        public void ChangePlayer()
        {
            _ = CurrentPlayer == PlayerType.X ? CurrentPlayer = PlayerType.O : CurrentPlayer = PlayerType.X;
        }

        public Player GetPlayer(PlayerType playerType)
        {
            return Players.First(p => playerType == p.PlayerType);
        }
    }
}
