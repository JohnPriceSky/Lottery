using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lottery.WebApi.Hubs
{
    public class NotificationHub : Hub
    {
        public void Notification(string message)
        {
            Clients.All.Notification(message);
        }
    }
}