﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using Music_Releases.BL;
using Music_Releases.Repository;
using System.Configuration;

namespace Music_Releases_Website.Classes
{
    public class BindModule : NinjectModule
    {
        ApiCreds creds = new ApiCreds
        {
            AmazonAccessId = ConfigurationSettings.AppSettings["AmazonAccessId"],
            AmazonEndPoint = ConfigurationSettings.AppSettings["AmazonEndPoint"],
            AmazonAssociateTag = ConfigurationSettings.AppSettings["AmazonAssociateTag"],
            AmazonSecretKey = ConfigurationSettings.AppSettings["AmazonSecretKey"],
            ItunesAffiliateId = ConfigurationSettings.AppSettings["ItunesAffiliateId"],
            ItunesRequestUrl = ConfigurationSettings.AppSettings["ItunesRequestUrl"]
        };

        public override void Load()
        {
            Bind<IAmazonSearchRepository>().To<AmazonSearchRepository>().WithConstructorArgument("accessId", creds.AmazonAccessId).WithConstructorArgument("requestEndPoint", creds.AmazonEndPoint).WithConstructorArgument("associateTag", creds.AmazonAssociateTag).WithConstructorArgument("secretKey", creds.AmazonSecretKey);
            Bind<IAmazonItemRepository>().To<AmazonItemRepository>().WithConstructorArgument("accessId", creds.AmazonAccessId).WithConstructorArgument("requestEndPoint", creds.AmazonEndPoint).WithConstructorArgument("associateTag", creds.AmazonAssociateTag).WithConstructorArgument("secretKey", creds.AmazonSecretKey);
            Bind<IItunesItemRepository>().To<ItunesItemRepository>().WithConstructorArgument("affiliateId", creds.ItunesAffiliateId).WithConstructorArgument("requestUrl", creds.ItunesRequestUrl);
        }
    }
}