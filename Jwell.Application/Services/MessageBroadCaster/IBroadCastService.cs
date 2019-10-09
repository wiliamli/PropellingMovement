using Jwell.Application.Services.Dtos;
using Jwell.Framework.Application.Service;
using Jwell.Framework.Domain.Uow;
using Jwell.Framework.Paging;
using System;

namespace Jwell.Application.Services
{
    public interface IBroadCastService
    {
        void BroadCast(MessageRequest messageRequest);

        event EventHandler<BroadCastEventArgs> MessageListened;
    }
}
