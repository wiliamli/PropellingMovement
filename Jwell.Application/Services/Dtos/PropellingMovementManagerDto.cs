using Jwell.Domain.Entities;
using Jwell.Framework.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Application.Services.Dtos
{
    public class PropellingMovementManagerDto
    {
        public long ID { get; set; }

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
        /// 频道
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        private string createBy = "admin";
        public string CreatedBy
        {
            get
            {
                return createBy;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(createBy))
                {
                    createBy = value;
                }
            }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 修改者
        /// </summary>
        private string modifiedBy = "admin";
        public string ModifiedBy
        {
            get
            {
                return modifiedBy;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(modifiedBy))
                {
                    modifiedBy = value;
                }
            }
        }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifiedTime { get; set; }
    }

    public static class PropellingMovementManagerDtoExt
    {
        public static IQueryable<PropellingMovementManagerDto> ToDtos(this IQueryable<PropellingMovementManager> query)
        {
            return from a in query
                   select new PropellingMovementManagerDto()
                   {
                       ID = a.ID,
                       ServiceNumber = a.ServiceNumber,
                       ClientSecret = a.ClientSecret,
                       IsEnable = a.IsEnable > 0,
                       CreatedBy = a.CreatedBy,
                       CreatedTime = a.CreatedTime,
                       DomainName = a.DomainName,
                       ModifiedBy = a.ModifiedBy,
                       ModifiedTime = a.ModifiedTime,
                       ServiceSign = a.ServiceNumber,
                       PropeMoveID=a.PropeMoveID
                   };
        }

        public static PageResult<PropellingMovementManagerDto> ToDtos(this PageResult<PropellingMovementManager> query)
        {
            var queryDto = (from a in query.Pager
                            select new PropellingMovementManagerDto()
                            {
                                ID = a.ID,
                                ServiceNumber = a.ServiceNumber,
                                ClientSecret = a.ClientSecret,
                                IsEnable = a.IsEnable > 0,
                                CreatedBy = a.CreatedBy,
                                CreatedTime = a.CreatedTime,
                                DomainName = a.DomainName,
                                ModifiedBy = a.ModifiedBy,
                                ModifiedTime = a.ModifiedTime,
                                ServiceSign = a.ServiceNumber,
                                PropeMoveID = a.PropeMoveID
                            }).ToList();

            return new PageResult<PropellingMovementManagerDto>(queryDto, query.PageIndex, query.PageSize, query.TotalCount);
        }

        public static PropellingMovementManagerDto ToDto(this PropellingMovementManager entity)
        {
            PropellingMovementManagerDto dto = null;
            if (entity != null)
            {
                dto = new PropellingMovementManagerDto()
                {
                    ID = entity.ID,
                    ServiceNumber = entity.ServiceNumber,
                    ClientSecret = entity.ClientSecret,
                    IsEnable = entity.IsEnable > 0,
                    CreatedBy = entity.CreatedBy,
                    CreatedTime = entity.CreatedTime,
                    DomainName = entity.DomainName,
                    ModifiedBy = entity.ModifiedBy,
                    ModifiedTime = entity.ModifiedTime,
                    ServiceSign = entity.ServiceNumber,
                    PropeMoveID = entity.PropeMoveID
                };
            }
            return dto;
        }

        public static PropellingMovementManager ToEntity(this PropellingMovementManagerDto dto)
        {
            PropellingMovementManager entity = null;
            if (dto != null)
            {
                entity = new PropellingMovementManager()
                {
                    ID = dto.ID,
                    ServiceNumber = dto.ServiceNumber,
                    ClientSecret = dto.ClientSecret,
                    IsEnable = (byte)(dto.IsEnable ? 1 : 0),
                    CreatedBy = dto.CreatedBy,
                    CreatedTime = dto.CreatedTime,
                    DomainName = dto.DomainName,
                    ModifiedBy = dto.ModifiedBy,
                    ModifiedTime = dto.ModifiedTime,
                    ServiceSign = dto.ServiceNumber,
                    PropeMoveID = dto.PropeMoveID
                };
            }
            return entity;
        }
    }
}
