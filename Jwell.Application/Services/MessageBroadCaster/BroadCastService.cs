using Jwell.Application.Services;
using Jwell.Application.Services.Dtos;
using Jwell.Framework.Application.Service;
using Jwell.Modules.Cache;
using Jwell.Modules.MessageQueue.Redis;
using Jwell.Repository.Repositories;
using System;

namespace Jwell.Application
{
    public class BroadCastService : IBroadCastService
    {
        private EventHandler<BroadCastEventArgs> messageListenedHandler;
        private readonly object eventLocker = new object();

        public void BroadCast(MessageRequest messageRequest)
        {
            EventHandler<BroadCastEventArgs> handler;
            lock (eventLocker)
            {
                handler = messageListenedHandler;
                if (handler != null)
                {
                    handler(this, new BroadCastEventArgs(messageRequest));
                }
            }

        }

        public event EventHandler<BroadCastEventArgs> MessageListened
        {
            add
            {
                lock (eventLocker)
                {
                    messageListenedHandler += value;
                }
            }
            remove
            {
                lock (eventLocker)
                {
                    messageListenedHandler -= value;
                }
            }
        }
    }
}