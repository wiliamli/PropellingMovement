using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Application.Services.Dtos
{
    public class BroadCastEventArgs
    {

        public MessageRequest MessageRequest { get; private set; }


        public BroadCastEventArgs(MessageRequest messageRequest)
        {
            MessageRequest = messageRequest ?? new MessageRequest();
        }
    }
}
