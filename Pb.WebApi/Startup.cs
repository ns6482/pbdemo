using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Pb.WebApi;

[assembly: OwinStartup("wizard", typeof (Startup))]

namespace Pb.WebApi
{
    /// <summary>
    /// Start for pbdemo webpi
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configurations the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            ConfigureOauth(app);
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            //on the same server but the authentication server could quite easily be decoupled. At which will need to configure this for security.
            app.UseWebApi(config);
        }

        /// <summary>
        /// Configures the oauth.
        /// </summary>
        /// <param name="app">The application.</param>
        public void ConfigureOauth(IAppBuilder app)
        {
            // Token Generation
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}