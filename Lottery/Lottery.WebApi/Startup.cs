using Hangfire;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using System.Configuration;

[assembly: OwinStartup(typeof(Lottery.WebApi.Startup))]
namespace Lottery.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HubConfiguration();
            config.EnableJSONP = true;
            app.MapSignalR(config);

            GlobalConfiguration.Configuration.UseSqlServerStorage(ConfigurationManager.ConnectionStrings["Hangfire"].ConnectionString);

            app.UseHangfireServer();
            app.UseHangfireDashboard();
        }
    }
}