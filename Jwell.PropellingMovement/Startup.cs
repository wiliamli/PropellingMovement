using Jwell.Application;
using Jwell.Application.Services;
using Jwell.PropellingMovement.DependencyContainer;
using Jwell.PropellingMovement.SignalRHubs;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR.Infrastructure;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Ninject;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(Jwell.PropellingMovement.Startup))]

namespace Jwell.PropellingMovement
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888

            var kernel = new StandardKernel();

            // SignalR Hub DP resolver
            var signalRDependencyResolver = new NInjectSignalRDependencyResolver(kernel);

            // Register hub connection context
            kernel.Bind(typeof(IHubConnectionContext<dynamic>)).
                  ToMethod(context =>
                  signalRDependencyResolver.Resolve<IConnectionManager>().
                  GetHubContext<BroadCastHub>().Clients).
                  WhenInjectedInto<IBroadCastService>();

            // Register message broadcaster class
            kernel.Bind<IBroadCastService>().
                ToConstant<BroadCastService>(new BroadCastService());

            // IBroadcast DP resolver
            GlobalConfiguration.Configuration.DependencyResolver = new NInjectDependencyResolver(kernel);

            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                map.RunSignalR(new HubConfiguration()
                {
                    EnableDetailedErrors = true,
                    EnableJavaScriptProxies = false,
                    Resolver = signalRDependencyResolver
                });
            });
        }
    }
}
