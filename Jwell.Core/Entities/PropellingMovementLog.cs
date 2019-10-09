using Jwell.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Domain.Entities
{
    [Table("PropellingMovementLog")]
    public class PropellingMovementLog : BaseEntity
    {
        /// <summary>
        /// 服务编号
        /// </summary>
        public string ServiceNumber { get; set; }

        /// <summary>
        /// 服务标识
        /// </summary>
        public string ServiceSign { get; set; }

        /// <summary>
        /// 主推消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 分组消息
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// 中间层推送服务
        /// </summary>
        public string InterfaceUrl { get; set; }

        /// <summary>
        /// 环境
        /// </summary>
        public string Environment { get; set; }

        /// <summary>
        /// 数据库时间
        /// </summary>
        public DateTime? Timestamp { get; set; }
    }
}
