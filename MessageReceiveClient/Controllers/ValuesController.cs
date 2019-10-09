using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MessageReceiveClient.Controllers
{
    public class ValuesController: ApiController
    {
        // GET api/<controller>
        

        // GET api/<controller>/5
        public string Get(int id)
        {
 
            return "value";
        }
    }
}