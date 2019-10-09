using Jwell.Application.Services;
using Jwell.Application.Services.Dtos;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Jwell.Application.MessageListener
{
    public class BroadCastListener : IBroadCastListener,IDisposable
    {

        private bool isDisposed = false;
        private readonly object eventLocker = new object();

        private HubConnection hubConnection;
        private event EventHandler<BroadCastEventArgs> BroadCastListenerEventHandler;

        private IHubConfiguration _hubConfiguration;
        private BroadCastEventArgs _broadCastListenerEventArgs;


        public bool IsConnected { get; private set; }


        public IHubConfiguration HubConfiguration
        {
            get
            {
                return _hubConfiguration;
            }
            set
            {
            }
        }

        public BroadCastEventArgs BroadCastEventArgs
        {
            get
            {
                return _broadCastListenerEventArgs;
            }
            set
            {
            }
        }

        public BroadCastListener(IHubConfiguration hubConfiguration)
        {
            if (hubConfiguration == null)
            {
                throw new ArgumentNullException("Hub configuration object is null !");
            }

            if (string.IsNullOrWhiteSpace(hubConfiguration.HubURL) || !Uri.IsWellFormedUriString(hubConfiguration.HubURL, UriKind.Absolute))
            {
                throw new ArgumentNullException("BroadCast service URL is empty or not well formed value !");
            }

            if (string.IsNullOrWhiteSpace(hubConfiguration.HubName))
            {
                throw new ArgumentNullException("BroadCast service HubName is empty !");
            }

            this.IsConnected = false;
            this._hubConfiguration = hubConfiguration;
        }


        public string ListenHubEvent(Action<object, BroadCastEventArgs> hubEvent)
        {
            if (!_hubConfiguration.IsHubListeningEnabled)
                return string.Concat("Hub listening is disabled for an event named ", _hubConfiguration.Group);

            string statusMessage = string.Concat("All is well. Message is being listened for an event named ", _hubConfiguration.Group);

            try
            {

                if (hubEvent == null)
                    throw new ArgumentNullException("HubEvent is null !");

                if (hubConnection == null || isDisposed)
                    hubConnection = new HubConnection(_hubConfiguration.HubURL);

                IHubProxy proxyHub = hubConnection.CreateHubProxy(_hubConfiguration.HubName);

                try
                {
                    hubConnection.Start().
                        ContinueWith(task
                            =>
                        {
                            if (task.IsFaulted)
                            {
                                throw task.Exception;
                            }
                            else
                            {
                                // Register/attach broadcast listener event
                                //if (_hubConfiguration.Group != EventNameEnum.UNKNOWN)
                                if (!string.IsNullOrWhiteSpace(_hubConfiguration.Group))
                                {
                                    lock (eventLocker)
                                    {
                                        BroadCastListenerEventHandler += (sender, broadCastArgs) =>
                                            hubEvent.Invoke(sender, broadCastArgs);
                                    }
                                }
                            }
                        }, TaskContinuationOptions.OnlyOnRanToCompletion).Wait();

                }
                catch (AggregateException aggregateException)
                {
                    throw aggregateException;
                }


                if (hubConnection.State == ConnectionState.Connected)
                    IsConnected = true;

                proxyHub.On<string>(_hubConfiguration.Group,
                        message =>
                        {
                            _broadCastListenerEventArgs = new BroadCastEventArgs(
                                new MessageRequest()
                                {
                                    Message = message,
                                    Group = _hubConfiguration.Group
                                });
                            OnMessageListened(_broadCastListenerEventArgs);
                        });


                lock (eventLocker)
                {
                    // Unregister/detach broadcast listener event
                    BroadCastListenerEventHandler -= (sender, broadCastArgs) =>
                        hubEvent.Invoke(sender, broadCastArgs);
                }
            }
            catch (Exception exception)
            {
                // Client should handle the exception
                if (hubConnection != null && !string.IsNullOrWhiteSpace(hubConnection.ConnectionId))
                    return string.Format("Opps something wrong happened ! Hub ConnectionID : {0}, Exception - Message : {1}, StackTrace : {2} ",
                        hubConnection.ConnectionId, exception.Message, exception.StackTrace);
                return string.Format("Opps something wrong happened ! Exception - Message : {0}, StackTrace : {1} ", exception.Message, exception.StackTrace);
            }
            return hubConnection != null && !string.IsNullOrWhiteSpace(hubConnection.ConnectionId) ?
                string.Concat(statusMessage, " at Hub ConnectionID : ", hubConnection.ConnectionId) : statusMessage;

        }

        public async Task<string> ListenHubEventAsync(Action<object, BroadCastEventArgs> hubEvent)
        {
            return await new TaskFactory().StartNew(
                () =>
                {
                    return ListenHubEvent(hubEvent);
                }
            );
        }


        public void Dispose()
        {
            Dispose(true);
        }

        #region 私有方法

        private void OnMessageListened(BroadCastEventArgs broadCastArgs)
        {
            EventHandler<BroadCastEventArgs> handler = BroadCastListenerEventHandler;
            if (handler != null)
                handler(this, broadCastArgs);
        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    if (hubConnection != null)
                    {
                        hubConnection.Dispose();
                    }
                }
                isDisposed = true;
            }
        }

        #endregion
    }
}
