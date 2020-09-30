using bUtility.Logging;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;
using System.IdentityModel.Tokens;

[assembly: OwinStartup(typeof(bookstore.api.Startup))]

namespace bookstore.api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var cp = ConfigProfile.LoadConfigurationProfile();
            Logger.Current?.Info("Startup.Configuration invoked");
            JwtSecurityTokenHandler.InboundClaimTypeMap.Clear();

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions {
                Authority = cp.Authority,
                ClientId = cp.ApiResourceName,
                ClientSecret = cp.ApiResourceSecret,
                RequiredScopes = new[] { cp.RequiredScope, cp.RequiredAdminScope }
            });

        }
    }
}