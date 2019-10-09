using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jwell.Application.Services.Dtos
{
    /// <summary>
    /// 推送信息
    /// </summary>
    public class MessageRequest
    {
        ///<summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 分组
        /// </summary>
        public string Group { get; set; }

    }
}