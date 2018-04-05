using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using IdentityServer3.Core.Configuration;
using Microsoft.Owin;
using Owin;
using System.Configuration;

[assembly: OwinStartup(typeof(Music_Releases.OAuth.Startup))]

namespace Music_Releases.OAuth
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            var sig = Convert.FromBase64String(ConfigurationManager.AppSettings["sig2"]);
            var pass = ConfigurationManager.AppSettings["pass"];
            var inMemManager = new InMemoryManager();
            var fac = new IdentityServerServiceFactory()
                .UseInMemoryClients(inMemManager.GetClients())
                .UseInMemoryScopes(inMemManager.GetScopes())
                .UseInMemoryUsers(inMemManager.GetUsers());

            var options = new IdentityServerOptions
            {
                SigningCertificate = new X509Certificate2(sig,pass),
                RequireSsl = false,
                Factory = fac,
            };

            app.UseIdentityServer(options);
        }
    }
}
