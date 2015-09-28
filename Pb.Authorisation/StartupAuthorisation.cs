using System;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using PbDemo.Authorisation;
using PbDemo.Authorisation.Providers;

[assembly: OwinStartup(typeof (StartupAuthorisation))]

namespace PbDemo.Authorisation
{
    /// <summary>
    /// Startup oauth server
    /// </summary>
    public class StartupAuthorisation
    {
        /// <summary>
        /// Configurations the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public void Configuration(IAppBuilder app)
        {


            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            ConfigureOauth(app);

            //very important, don't screw the order up 
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
            var oAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new PbAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}