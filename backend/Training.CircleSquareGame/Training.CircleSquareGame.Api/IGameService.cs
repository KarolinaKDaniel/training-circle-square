using Training.CircleSquareGame.Api;

public interface IGameService
{
    public Game Game { get; set; }

    void RunNewGame(int maxNumberOfWins);

    void MakeAMove(Player player, string fieldName);

    string GetFieldValue(string fieldName);
}