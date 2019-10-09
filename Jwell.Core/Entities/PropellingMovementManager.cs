using System;
using System.ComponentModel.DataAnnotations.Schema;
using Jwell.Domain.Entities.Base;

namespace Jwell.Domain.Entities
{
    [Table("PropellingMovementManager")]
    public class PropellingMovementManager : BaseEntity
    {
        /// <summary>
        /// 主推ID,业务主键
        /// </summary>
        public string PropeMoveID { get; set; }

        /// <summary>
        /// 服务编号
        /// </summary>
        public string ServiceNumber { get; set; }

        /// <summary>
        /// 服务标识
        /// </summary>
        public string ServiceSign { get; set; }

        /// <summary>
        /// 客户端密钥，默认生成
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// 域名
        /// </summary>
        public string DomainName { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public byte IsEnable { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 修改者
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifiedTime { get; set; }

    }
}
