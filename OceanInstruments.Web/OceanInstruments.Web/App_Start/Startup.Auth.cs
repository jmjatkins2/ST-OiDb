using System;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Jwt;
using System.Web.Http;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security;
using WebConfigurationManager = System.Web.Configuration.WebConfigurationManager;

namespace OceanInstruments.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // Uses Auth0 provider - roles hardcoded into that service for now. No need to go overboard at this point.
            // Can use MS Owin provider later if we really must, but requires more work on the front end to support, etc 

            var issuer = WebConfigurationManager.AppSettings["Auth0Domain"];
            var audience = WebConfigurationManager.AppSettings["Auth0ClientID"];
            var secret = TextEncodings.Base64Url.Decode(WebConfigurationManager.AppSettings["Auth0ClientSecret"]);

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audience },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
                    },
                });

            //can access user properties in controller methods like this:
            //string email = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Email).Value;
            //At present, just name, roles and email address are provided, but you can change this in App\Controllers\loginController.js
        }
    }
}
