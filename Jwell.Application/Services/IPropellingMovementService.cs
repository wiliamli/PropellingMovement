using Jwell.Application.Services.Dtos;
using Jwell.Framework.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Application.Services
{
    public interface IPropellingMovementService : IApplicationService
    {
        /// <summary>
        /// 根据服务编号与分组获取相关主推信息
        /// </summary>
        /// <param name="serviceNumber">服务编号</param>
        /// <param name="group">分组</param>
        /// <returns></returns>
        IEnumerable<PropellingMovementDto> GetPropellingMovementDtos(string serviceNumber,string group);

        /// <summary>
        /// 根据服务编号获取相关主推信息
        /// </summary>
        /// <param name="serviceNumber">服务编号</param>
        /// <returns></returns>
        IEnumerable<PropellingMovementDto> GetPropellingMovementDtos(string serviceNumber);

        /// <summary>
        /// 根据服务编号,环境与分组获取相关主推信息
        /// </summary>
        /// <param name="serviceNumber">服务编号</param>
        /// <param name="group">分组</param>
        /// <param name="evn">环境</param>
        /// <returns></returns>
        PropellingMovementDto GetPropellingMovementDto(string serviceNumber, string group, string evn);

        /// <summary>
        /// 该服务是否存在
        /// </summary>
        /// <param name="serviceNumber">服务编号</param>
        bool IsExist(string serviceNumber);
    }
}
