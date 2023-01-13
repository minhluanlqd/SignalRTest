using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage1(string user, string message)
        {
           await Clients.All.SendAsync("ReceiveOne", user, message);
        }
    }
}
