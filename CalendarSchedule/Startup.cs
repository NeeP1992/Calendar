using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CalendarSchedule.Startup))]
namespace CalendarSchedule
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
