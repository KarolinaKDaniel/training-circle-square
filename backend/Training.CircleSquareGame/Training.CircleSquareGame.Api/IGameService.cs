namespace Training.CircleSquareGame.Api;

    public interface IGameService
    {
        public Game Game { get; }

        void RunNewGame();

        void MakeAMove(Player player, string fieldName);

        string GetFieldValue(string fieldName);
    }