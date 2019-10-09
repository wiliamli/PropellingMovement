using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MessageReceiveClient.Controllers
{
    public class HomeController : Controller
    {
        //public event EventHandler<dynamic> OnDataReceived;
        //IHubProxy hubProxy;
        public ActionResult Index()
        {
            //OnDataReceived += HomeController_OnDataReceived;

            ////string message = string.Empty;
            //HubConnection signalRConnection = new HubConnection("http://localhost:53688");
            //IHubProxy hubProxy = signalRConnection.CreateHubProxy("broadcasthub");
            //signalRConnection.Start().Wait();
            ////hubProxy.Invoke<string>("broadCast",(message)=> {
            ////    string connect = message;
            ////});
            //hubProxy.On<string>("broadCast", (message) => {

            //    Response.Write(message);
            //});

            return View();
        }




        private void HomeController_OnDataReceived(object sender, dynamic e)
        {
            throw new NotImplementedException();
        }

        private void SignalRConnection_Received(string obj)
        {
            string message = obj;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            string name = Request["name"] != null ? Request["name"].ToString() : string.Empty;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}