using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jwell.Application.Services.Dtos;
using Jwell.Repository.Repositories;

namespace Jwell.Application.Services
{
    public class PropellingMovementService : IPropellingMovementService
    {
        private IPropellingMovementInterfaceRepository PropellingMovementInterfaceRepository { get; set; }

        private IPropellingMovementManagerRepository PropellingMovementManagerRepository { get; set; }

        public PropellingMovementService(IPropellingMovementInterfaceRepository propellingMovementInterfaceRepository,
            IPropellingMovementManagerRepository propellingMovementManagerRepository)
            {
            this.PropellingMovementInterfaceRepository = propellingMovementInterfaceRepository;
            this.PropellingMovementManagerRepository = propellingMovementManagerRepository;
        }

        public PropellingMovementDto GetPropellingMovementDto(string serviceNumber, string group, string evn)
        {
            PropellingMovementDto propelling = null;
            var query=GetPropellingMovementDtos(serviceNumber,group);
            if (query != null)
            {
                propelling = query.FirstOrDefault(m=>m.Environment==evn);
            }

            return propelling;
        }

        public IEnumerable<PropellingMovementDto> GetPropellingMovementDtos(string serviceNumber, string channel)
        {
            var query = GetPropellingMovementDtos(serviceNumber);
            IEnumerable<PropellingMovementDto> result = null;
            if (query != null && query.Count() > 0)
            {
                result = query.Where(m => m.Channel == channel);
            }

            return result;
        }

        public IEnumerable<PropellingMovementDto> GetPropellingMovementDtos(string serviceNumber)
        {
            var query = (from a in PropellingMovementManagerRepository.Queryable()
                         join b in PropellingMovementInterfaceRepository.Queryable() on a.PropeMoveID equals b.PropeMoveID into temp
                         from t in temp.DefaultIfEmpty()
                         where a.ServiceNumber == serviceNumber
                         select new PropellingMovementDto()
                         {
                             ServiceSign = a.ServiceSign,
                             Environment = t != null ? t.Environment : string.Empty,
                             Channel = t != null ? t.Channel : string.Empty,
                             InterfaceUrl = t != null ? t.InterfaceUrl : string.Empty,
                             ServiceNumber = a.ServiceNumber
                         }).ToList();

            return query;

        }

        public bool IsExist(string serviceNumber)
        {
            //TODO：需要获取服务缓存对比
            throw new NotImplementedException();
        }
    }
}
