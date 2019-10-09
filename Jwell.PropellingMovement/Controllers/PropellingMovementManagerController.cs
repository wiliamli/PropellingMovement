using Jwell.Application.Services;
using Jwell.Application.Services.Dtos;
using Jwell.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jwell.PropellingMovement.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class PropellingMovementManagerController : BaseApiController
    {
        private IPropellingMovementManagerService PropellingMovementManagerService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propellingMovementManagerService"></param>
        public PropellingMovementManagerController(IPropellingMovementManagerService propellingMovementManagerService)
        {
            this.PropellingMovementManagerService = propellingMovementManagerService;
        }

        /// <summary>
        /// 新增主推配置信息
        /// </summary>
        /// <param name="dto">配置信息</param>
        /// <returns></returns>
        [HttpPost]
        public StandardJsonResult<bool> Add(PropellingMovementManagerDto dto)
        {
            StandardJsonResult<bool> result =
                base.StandardAction<bool>(() =>
                {
                    return PropellingMovementManagerService.Add(dto);
                });

            return result;
        }

    }
}
