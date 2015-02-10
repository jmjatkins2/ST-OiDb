using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;


[assembly: OwinStartup(typeof(OceanInstruments.Web.Startup))]

namespace OceanInstruments.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
