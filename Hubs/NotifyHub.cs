using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Hubs
{
    public class NotifyHub : Hub
    {
        public async Task NotifyUser(String fromUser, String toUser)
        {
            await Clients.Others.SendAsync("Receive", fromUser, toUser);
        }
    }
}
