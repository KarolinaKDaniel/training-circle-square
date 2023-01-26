namespace Training.CircleSquareGame.Api
{
    public class GameService : IGameService
    {
        public Game Game { get; set; }

        public GameService(int maxNumberOfWins = 3)
        {
            Game = new Game(maxNumberOfWins);
        }

        public void RunNewGame()
        {
            Game = new Game(3);
        }

        public void MakeAMove(Player player, string fieldName)
        {
            Game.Board.FillAField(player.PlayerType, fieldName);

            if (Game.Board.CheckIfPlayerWon(player.PlayerType))
            {
                player.AddWin();

            }

            //
            // if (Game.CheckIfWon(player))
            // {
            //     // DO STH
            //     return;
            // }
            Game.ChangePlayer();

        }

        public string? GetFieldValue(string fieldName)
        {
            if (Game.Board.IsFieldFilled(fieldName))
                return null;

            var player = Game.GetPlayer(Game.CurrentPlayer);

            MakeAMove(player, fieldName);

            return player.PlayerType == PlayerType.X ? "x" : "o";
        }
    }
}