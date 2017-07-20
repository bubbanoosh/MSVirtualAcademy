using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRPerformanceSurf.Hubs
{
    public class SignalRPerformanceHub : Hub
    {
        public void Send(string message)
        {
            // Sends the message to ALL clients that are connected

            // Dynamic runtime will create a JS function called 'showMessage' and has a parameter to pass the data
            Clients.All.showMessage(
                // SignalR Context
                Context.User.Identity.Name + " says: " + message
                );
        }
    }
}