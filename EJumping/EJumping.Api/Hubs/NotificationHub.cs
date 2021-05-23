using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJumping.Api.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task UpdateSample(string user, string message)
        {
            await Clients.All.SendAsync("NewNoti",user,message);
        }
    }

}
