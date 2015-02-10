using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using System.Web.Http.Routing;
using System.Web.Http.ExceptionHandling;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace OceanInstruments.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Add global exception logger
            config.Services.Add(typeof(IExceptionLogger), new TraceExceptionLogger());

            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            MediaTypeFormatterCollection formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); // Use camel case for JSON data.
            formatters.Remove(formatters.XmlFormatter); // only want JSON

            // By default all webapi controllers require admin authentication
            // then override on specific methods, if required
            config.Filters.Add(new AuthorizeAttribute() { Roles = "Admin" });

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Stop self referencing loops (when using EF)
            formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
                = ReferenceLoopHandling.Ignore;
        }
    }

    /// <summary>
    /// A basic exception logger that just outputs info into trace. Azure automatically writes this into log files.
    /// TODO: Need to be emailing errors as well
    /// </summary>
    public class TraceExceptionLogger : IExceptionLogger
    {
        public Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            Trace.TraceError(context.ExceptionContext.Exception.ToString());
            return Task.FromResult(0);
        }
    }
}
