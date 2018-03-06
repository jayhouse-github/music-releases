using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace Music_Releases.Repository.Tests
{
    [TestClass]
    public class AmazonItemRetrieveTests
    {
        [TestMethod]
        public void LookupASINReturnsNotNull()
        {
            IKernel kernal = new StandardKernel(new BindModule());
            var amazonItemRepo = kernal.Get<IAmazonItemRepository>();
            ICatalogueExtendedInfo actual = amazonItemRepo.LookupASIN("B06XSS46GQ");

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void LookupASINReturnsExpectedArtist()
        {
            IKernel kernal = new StandardKernel(new BindModule());
            var amazonItemRepo = kernal.Get<IAmazonItemRepository>();

            ICatalogueExtendedInfo actual = amazonItemRepo.LookupASIN("B06XSS46GQ");

            string expectedArtist = "Ride";

            Console.WriteLine(expectedArtist);

            Assert.AreEqual(expectedArtist, actual.Artist, true);
        }

        [TestMethod]
        public void LookupSearchStringReturnsExpectedArtist()
        {
            IKernel kernal = new StandardKernel(new BindModule());
            var amazonItemRepo = kernal.Get<IAmazonItemRepository>();

            ICatalogueExtendedInfo actual = amazonItemRepo.LookupSearchString("Ride Weather Diaries", SearchIndex.MP3);

            string expectedArtist = "Ride";

            Assert.AreEqual(expectedArtist, actual.Artist, true);
        }
    }
}
