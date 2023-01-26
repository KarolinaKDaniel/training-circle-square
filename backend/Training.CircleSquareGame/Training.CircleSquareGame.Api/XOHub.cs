using Microsoft.AspNetCore.SignalR;

namespace Training.CircleSquareGame.Api;

public class XOHub : Hub
{
    public static IGameService GameService;

    public XOHub(IGameService gameService)
    {
        GameService = gameService;
    }

    public async Task StartNewGame()
    {
        var filledFields = GameService.Game.Board.GetAllFilledFields();
        
        GameService.RunNewGame();
        
        foreach (var filledField in filledFields)
        {
            await GetField(filledField);
        }
        
    }
    
    public async Task GetField(string fieldId)
    {
        await Clients.All.SendAsync("CurrentFieldValue", fieldId, "");
    }
    
    public async Task SetField(string fieldId)
    {
        var fieldValue = GameService.GetFieldValue(fieldId);

        if (fieldValue != null)
        {
            await Clients.All.SendAsync("CurrentFieldValue", fieldId, fieldValue);
        }
        else
        {
            const string message = "Field is already filled";
            await Clients.All.SendAsync("FieldIsFilled", message);
        }
    }
}