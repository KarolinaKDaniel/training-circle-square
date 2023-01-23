namespace Training.CircleSquareGame.Api;

public class Player
{
    public PlayerType PlayerType { get; }
    public int NumberOfWins { get; set; }

    //TODO adding a possibility to add a name?

    public Player(PlayerType playerType)
    {
        PlayerType = playerType;
        NumberOfWins = 0;
    }

    public void AddWin()
    {
        NumberOfWins++;
    }
}

public enum PlayerType
{
    X,
    O
}