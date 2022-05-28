using Microsoft.AspNetCore.SignalR;

namespace Toki_API.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string senderId, string recieverId)
        {
            await Clients.All.SendAsync("RecieveMessage", senderId, recieverId);

        }

        public async Task SendInvite(string recieverId)
        {
            await Clients.All.SendAsync("RecieveInvite", recieverId);

        }
    }
}
