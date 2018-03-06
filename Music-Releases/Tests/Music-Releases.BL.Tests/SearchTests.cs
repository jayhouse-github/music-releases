using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Music_Releases.Repository;
using Ninject;

namespace Music_Releases.BL.Tests
{
    [TestClass]
    public class SearchTests
    {
        [TestMethod]
        public void SearchFromASINIsNotNull()
        {
            ApiCreds creds = new ApiCreds
            {
                AmazonAccessId = "AKIAIU5OQJGAEPBSTBXA",
                AmazonEndPoint = "webservices.amazon.co.uk",
                AmazonAssociateTag = "etgsoftware-21",
                AmazonSecretKey = "NclX7m/JD7ET/A9pKjiWcUnt8PhLfeo/j+FMZOD4",
                ItunesAffiliateId = "1757335",
                ItunesRequestUrl = "http://ax.itunes.apple.com/WebObjects/MZStoreServices.woa/wa/wsSearch"
            };

            IKernel kernal = new StandardKernel(new BindModule());
            var amazonItemRepo = kernal.Get<IAmazonItemRepository>();
            var itunesItemRepo = kernal.Get<IItunesItemRepository>();

            var resultsObj = new ReleaseDetails(amazonItemRepo, itunesItemRepo).GetReleaseDetailsFromASIN("B06XSS46GQ");

            Assert.IsNotNull(resultsObj);
        }

        [TestMethod]
        public void SearchFromASINReturnsNoResults()
        {
            ApiCreds creds = new ApiCreds
            {
                AmazonAccessId = "AKIAIU5OQJGAEPBSTBXA",
                AmazonEndPoint = "webservices.amazon.co.uk",
                AmazonAssociateTag = "etgsoftware-21",
                AmazonSecretKey = "NclX7m/JD7ET/A9pKjiWcUnt8PhLfeo/j+FMZOD4",
                ItunesAffiliateId = "1757335",
                ItunesRequestUrl = "http://ax.itunes.apple.com/WebObjects/MZStoreServices.woa/wa/wsSearch"
            };

            IKernel kernal = new StandardKernel(new BindModule());
            var amazonItemRepo = kernal.Get<IAmazonItemRepository>();
            var itunesItemRepo = kernal.Get<IItunesItemRepository>();

            var resultsObj = new ReleaseDetails(amazonItemRepo, itunesItemRepo).GetReleaseDetailsFromASIN("sdasdasd");

            Assert.IsTrue(resultsObj.Items.Count == 0);
        }

        [TestMethod]
        public void AmazonItemSearchByASINIsNull()
        {
            ApiCreds creds = new ApiCreds
            {
                AmazonAccessId = "AKIAIU5OQJGAEPBSTBXA",
                AmazonEndPoint = "webservices.amazon.co.uk",
                AmazonAssociateTag = "etgsoftware-21",
                AmazonSecretKey = "NclX7m/JD7ET/A9pKjiWcUnt8PhLfeo/j+FMZOD4",
                ItunesAffiliateId = "1757335",
                ItunesRequestUrl = "http://ax.itunes.apple.com/WebObjects/MZStoreServices.woa/wa/wsSearch"
            };

            IKernel kernal = new StandardKernel(new BindModule());
            var amazonItemRepo = kernal.Get<IAmazonItemRepository>();

            var resultsObj = new AmazonItemSearch(amazonItemRepo).GetByASIN("asdjhgajsd");

            Assert.IsNull(resultsObj);
        }

        [TestMethod]
        public void AmazonItemSearchBySearchTermIsNull()
        {
            ApiCreds creds = new ApiCreds
            {
                AmazonAccessId = "AKIAIU5OQJGAEPBSTBXA",
                AmazonEndPoint = "webservices.amazon.co.uk",
                AmazonAssociateTag = "etgsoftware-21",
                AmazonSecretKey = "NclX7m/JD7ET/A9pKjiWcUnt8PhLfeo/j+FMZOD4",
                ItunesAffiliateId = "1757335",
                ItunesRequestUrl = "http://ax.itunes.apple.com/WebObjects/MZStoreServices.woa/wa/wsSearch"
            };

            IKernel kernal = new StandardKernel(new BindModule());
            var amazonItemRepo = kernal.Get<IAmazonItemRepository>();

            var resultsObj = new AmazonItemSearch(amazonItemRepo).GetBySearchTerm("asdjhgajsd", SearchIndex.CD);

            Assert.IsNull(resultsObj);
        }
    }
}
