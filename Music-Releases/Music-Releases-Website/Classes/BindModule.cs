using Ninject.Modules;
using Music_Releases.BL;
using Music_Releases.Repository;
using System.Configuration;
using Music_Releases.BL.Interfaces;

namespace Music_Releases_Website.Classes
{
    public class BindModule : NinjectModule
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
            Bind<IItunesItemRepository>().To<ItunesItemRepository>().WithConstructorArgument("affiliateId", creds.ItunesAffiliateId).WithConstructorArgument("requestUrl", creds.ItunesRequestUrl);
            Bind<IListofBandsRepo>().To<ListOfBandsRepo>();
        }
    }
}