using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Music_Releases.BL;

namespace Music_Releases.BL.Tests
{
    [TestClass]
    public class SearchTests
    {
        [TestMethod]
        public void SearchFromASINIsNotNull()
        {
            IKernel kernal = new StandardKernel(new BindModule());
            var amazonItemRepo = kernal.Get<IAmazonItemRepository>();
            var itunesItemRepo = kernal.Get<IItunesItemRepository>();

            var resultsObj = new ReleaseDetails(amazonItemRepo, itunesItemRepo).GetReleaseDetailsFromASIN("B06XSS46GQ");

            Assert.IsNotNull(resultsObj);
        }

        [TestMethod]
        public void SearchFromASINReturnsNoResults()
        {
            IKernel kernal = new StandardKernel(new BindModule());
            var amazonItemRepo = kernal.Get<IAmazonItemRepository>();
            var itunesItemRepo = kernal.Get<IItunesItemRepository>();

            var resultsObj = new ReleaseDetails(amazonItemRepo, itunesItemRepo).GetReleaseDetailsFromASIN("sdasdasd");

            Assert.IsTrue(resultsObj.Items.Count == 0);
        }

        [TestMethod]
        public void AmazonItemSearchByASINIsNull()
        {
            IKernel kernal = new StandardKernel(new BindModule());
            var amazonItemRepo = kernal.Get<IAmazonItemRepository>();

            var resultsObj = new AmazonItemSearch(amazonItemRepo).GetByASIN("asdjhgajsd");

            Assert.IsNull(resultsObj);
        }

        [TestMethod]
        public void AmazonItemSearchBySearchTermIsNull()
        {
            IKernel kernal = new StandardKernel(new BindModule());
            var amazonItemRepo = kernal.Get<IAmazonItemRepository>();

            var resultsObj = new AmazonItemSearch(amazonItemRepo).GetBySearchTerm("asdjhgajsd", SearchIndex.CD);

            Assert.IsNull(resultsObj);
        }
    }
}
