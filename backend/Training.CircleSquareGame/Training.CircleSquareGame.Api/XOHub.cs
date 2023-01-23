using Microsoft.AspNetCore.SignalR;

namespace Training.CircleSquareGame.Api;

public class XOHub : Hub
{
    public static IGameService GameService;

    public XOHub(IGameService gameService)
    {
        GameService = GameServiceInstance.Instance;
    }

    public async Task GetField(string fieldId)
    {
        await Clients.All.SendAsync("CurrentFieldValue", fieldId, "");
    }
    
    public async Task SetField(string fieldId)
    {
        var fieldValue = GameService.GetFieldValue(fieldId);

        if (!fieldValue.Equals(null))
        {
            await Clients.All.SendAsync("CurrentFieldValue", fieldId, fieldValue);
        }
        else
        {
            await Clients.All.SendAsync("FieldIsFilled", fieldId);
            // TODO Add to frontend
        }
    }
}