using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace GIAF.UI
{
    public class RssFeed : Hub
    {
        public override async Task OnConnected()
        {
            await Clients.Caller.getConnectionId(Context.ConnectionId);
        }

        public async Task Change(string url)
        {
            await Clients.Others.Change(url);
        }
    }
}