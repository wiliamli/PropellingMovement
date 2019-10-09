using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Application.Services
{
    public interface IHubConfiguration
    {
        string HubURL { get; set; }


        string HubName { get; set; }

        string Group { get; set; }


        bool IsHubListeningEnabled { get; set; }
    }
}
