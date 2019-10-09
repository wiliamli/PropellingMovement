using Jwell.Application.Services;
using Jwell.Application.Services.Dtos;
using Jwell.Framework.Mvc;
using Jwell.Modules.WebApi.Attributes;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Jwell.PropellingMovement.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("MessagePush")]
    [EnableCors("*","*","*")]
    public class MessagePushController : BaseApiController
    {
        private IBroadCastService BroadCastService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="broadCastService"></param>
        public MessagePushController(IBroadCastService broadCastService)
        {
            this.BroadCastService = broadCastService;
        }


        /// <summary>
        /// 获取接口
        /// </summary>
        /// <param name="messageRequest">消息</param>
        /// <returns></returns>
        [ApiIgnore]
        [Route("Broadcast")]
        [HttpPost]
        public StandardJsonResult<string> Broadcast(MessageRequest messageRequest)
        {
            string response = string.Empty;
            return base.StandardAction<string>(() =>
             {
                
                 try
                 {
                     BroadCastService.BroadCast(messageRequest);
                     //response = "Message successfully broadcasted !";
                 }
                 catch (Exception ex)
                 {
                     //response = "Opps got error. ";
                     //response = string.Concat(response, "Excepion, Message : ", exception.Message);
                 }
                 return response;
             });
        }


        //private string ProcessMessageRequest(string message, string eventName)
        //{
        //    string response = string.Empty;
        //    try
        //    {
        //        MessageRequest messageRequest = new MessageRequest()
        //        {
        //            Message = message,
        //            EventName = eventName.FindEnumFromDescription<EventNameEnum>()
        //        };
        //        BroadCastUserService.BroadCast(messageRequest);
        //        response = "Message successfully broadcasted !";
        //    }
        //    catch (Exception exception)
        //    {
        //        response = "Opps got error. ";
        //        response = string.Concat(response, "Excepion, Message : ", exception.Message);
        //    }
        //    return response;
        //}
    }
}