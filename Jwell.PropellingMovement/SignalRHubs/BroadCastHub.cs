using System;
using Jwell.Application.Services;
using Jwell.Application.Services.Dtos;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Jwell.PropellingMovement.SignalRHubs
{
    /// <summary>
    /// 广播集线器
    /// </summary>
    [HubName("broadcasthub")]
    public class BroadCastHub : Hub
    {
        //private IPropellingMovementService PropellingMovementService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="broadCast"></param>
        public BroadCastHub(IBroadCastService broadCast)
        {
            //this.PropellingMovementService = propellingMovementService;

            if (broadCast == null)
                throw new ArgumentNullException("广播对象为空！");

            BeginBroadCast(broadCast); 
        }

        #region 私有方法

        /// <summary>
        /// Begin broadCast message
        /// </summary>
        /// <param name="broadCast">IBroadCast value</param>
        private void BeginBroadCast(IBroadCastService broadCast)
        {
            // Register/Attach broadcast listener event
            broadCast.MessageListened += (sender, broadCastArgs)
                =>
            {
                RegisterMessageEvents(broadCastArgs);
            };

            // Unregister/detach broadcast listener event
            broadCast.MessageListened -= (sender, broadCastArgs)
               =>
            {
                RegisterMessageEvents(broadCastArgs);
            };
        }

        /// <summary>
        /// 注册广播事件
        /// </summary>
        /// <param name="broadCastArgs"></param>
        private void RegisterMessageEvents(BroadCastEventArgs broadCastArgs)
        {
            if (broadCastArgs != null)
            {
                MessageRequest messageRequest = broadCastArgs.MessageRequest;

                IClientProxy clientProxy = Clients.All;      //Clients.Caller;

                //PropellingMovementDto propellingMovementDto = this.PropellingMovementService.GetPropellingMovementDto(SetupConfig.ServiceNumber
                //    , messageRequest.Group, SetupConfig.Enviroment);
                PropellingMovementDto propellingMovementDto = new PropellingMovementDto();
                //TODO：数据库获取
                if (propellingMovementDto != null)
                {
                    clientProxy.Invoke(messageRequest.Group, messageRequest.Message);
                }
                else
                {
                    throw new Exception("对应的服务广播组不存在"); 
                }
            }
        }
        #endregion
    }
}