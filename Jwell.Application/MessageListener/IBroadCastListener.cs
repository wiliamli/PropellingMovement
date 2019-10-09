using Jwell.Application.Services;
using Jwell.Application.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Application.MessageListener
{
    public interface IBroadCastListener
    {
        IHubConfiguration HubConfiguration { get; set; }

        bool IsConnected { get; }

        string ListenHubEvent(Action<object, BroadCastEventArgs> hubEvent);

        Task<string> ListenHubEventAsync(Action<object, BroadCastEventArgs> hubEvent);
    }
}
