using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using Music_Releases.Repository;
using Music_Releases.BL;
using System.Configuration;

namespace Music_Releases_Console
{
    class BindModule : NinjectModule
    {
        ApiCreds creds = new ApiCreds
        {
            AmazonAccessId = ConfigurationManager.AppSettings["AmazonAccessId"],
            AmazonEndPoint = ConfigurationManager.AppSettings["AmazonEndPoint"],
            AmazonAssociateTag = ConfigurationManager.AppSettings["AmazonAssociateTag"],
            AmazonSecretKey = ConfigurationManager.AppSettings["AmazonSecretKey"],
            ItunesAffiliateId = ConfigurationManager.AppSettings["ItunesAffiliateId"],
            ItunesRequestUrl = ConfigurationManager.AppSettings["ItunesRequestUrl"]
        };

        public override void Load()
        {
            Bind<IAmazonSearchRepository>().To<AmazonSearchRepository>().WithConstructorArgument("accessId", creds.AmazonAccessId).WithConstructorArgument("requestEndPoint", creds.AmazonEndPoint).WithConstructorArgument("associateTag", creds.AmazonAssociateTag).WithConstructorArgument("secretKey", creds.AmazonSecretKey);
            Bind<IAmazonItemRepository>().To<AmazonItemRepository>().WithConstructorArgument("accessId", creds.AmazonAccessId).WithConstructorArgument("requestEndPoint", creds.AmazonEndPoint).WithConstructorArgument("associateTag", creds.AmazonAssociateTag).WithConstructorArgument("secretKey", creds.AmazonSecretKey);
        }
    }
}
