using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace Music_Releases.Repository.Tests
{
    [TestClass]
    public class AmazonSearchTests
    {
        [TestMethod]
        public void AmazonSearchReturnsNotNull()
        {
            IKernel kernal = new StandardKernel(new BindModule());
            var amazonSearchRepo = kernal.Get<IAmazonSearchRepository>();

            var results = amazonSearchRepo.SearchAmazon("ride,the cure");

            Assert.IsNotNull(results);
        }

        [TestMethod]
        public void AmazonSearchReturnsexpectedArtistAsFirstResult()
        {
            IKernel kernal = new StandardKernel(new BindModule());
            var amazonSearchRepo = kernal.Get<IAmazonSearchRepository>();

            var results = amazonSearchRepo.SearchAmazon("ride,the cure");

            string expectedArtist = "Ride";

            Assert.AreEqual(expectedArtist, results[0].Artist, true);
        }
    }
}
