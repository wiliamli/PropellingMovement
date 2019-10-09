using Jwell.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Domain.Entities
{
    [Table("PropellingMovementInterface")]
    public class PropellingMovementInterface:BaseEntity
    {
        /// <summary>
        /// 主推ID，外键
        /// </summary>
        public string PropeMoveID { get; set; }

        /// <summary>
        /// 频道
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// 主推接口Url
        /// </summary>
        public string InterfaceUrl { get; set; }

        /// <summary>
        /// 环境
        /// </summary>
        public string Environment { get; set; }
    }
}
