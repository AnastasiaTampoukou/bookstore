using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;
using System.IdentityModel.Tokens;

[assembly: OwinStartup(typeof(bookstore.api.App_Start.Startup))]
namespace bookstore.api.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var cp = ConfigProfile.LoadConfigurationProfile();
            JwtSecurityTokenHandler.InboundClaimTypeMap.Clear();
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions {
                Authority = $@"https://{cp.Authority}",
                ClientId = cp.ApiResourceName,
                ClientSecret = cp.ApiResourceSecret,
                RequiredScopes = new[] { cp.RequiredScope }
            });

        }
    }
}