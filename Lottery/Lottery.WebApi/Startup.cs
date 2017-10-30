using Hangfire;
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
            app.MapSignalR();

            GlobalConfiguration.Configuration.UseSqlServerStorage(ConfigurationManager.ConnectionStrings["Hangfire"].ConnectionString);

            app.UseHangfireServer();
            app.UseHangfireDashboard();
        }
    }
}