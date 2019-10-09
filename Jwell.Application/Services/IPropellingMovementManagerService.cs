using Jwell.Application.Services.Dtos;
using Jwell.Framework.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Application.Services
{
    public interface IPropellingMovementManagerService: IApplicationService
    {
        /// <summary>
        /// 新增主推
        /// </summary>
        /// <param name="propellingMovementManagerDto">主推实体</param>
        /// <returns></returns>
        bool Add(PropellingMovementManagerDto propellingMovementManagerDto);
    }
}
