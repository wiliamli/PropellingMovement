using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jwell.Application.Services.Dtos;
using Jwell.Framework.Application.Service;
using Jwell.Framework.Domain.Uow;
using Jwell.Repository.Repositories;

namespace Jwell.Application.Services
{
    public class PropellingMovementManagerService : ApplicationService, IPropellingMovementManagerService
    {

        private IPropellingMovementManagerRepository PropellingMovementManagerRepository { get; set; }

        private IPropellingMovementInterfaceRepository PropellingMovementInterfaceRepository { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="propellingMovementManagerRepository"></param>
        public PropellingMovementManagerService(IPropellingMovementManagerRepository propellingMovementManagerRepository,
            IPropellingMovementInterfaceRepository propellingMovementInterfaceRepository)
        {
            this.PropellingMovementManagerRepository = propellingMovementManagerRepository;
            this.PropellingMovementInterfaceRepository = propellingMovementInterfaceRepository;
        }

        [UnitOfWork(UseTransaction = true)]
        public bool Add(PropellingMovementManagerDto propellingMovementManagerDto)
        {
            bool success = false;

            success = PropellingMovementManagerRepository.Add(propellingMovementManagerDto.ToEntity()) > 0;
            if (success)
            {
                success = PropellingMovementInterfaceRepository.Add(new Domain.Entities.PropellingMovementInterface()
                {
                    Environment = Modules.SetupConfig.SetupConfig.Enviroment,
                    Channel = propellingMovementManagerDto.Channel,
                    InterfaceUrl = Modules.Configure.JwellConfig.GetAppSetting("BroadCastUrl"),
                    PropeMoveID = propellingMovementManagerDto.PropeMoveID
                }) > 0;
            }

            return success;
        }
    }
}
