using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Music_Releases.BL;

namespace Music_Releases.Repository.Tests
{
    [TestClass]
    public class ItunesItemRetrieveTests
    {
        [TestMethod]
        public void ItunesItemRetrieveIsNotNull()
        {
            IKernel kernal = new StandardKernel(new BindModule());
            var iTunesRepo = kernal.Get<IItunesItemRepository>();

            var actual = iTunesRepo.GetInfo("ride weather diaries");

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void ItunesItemRetrieveIsNull()
        {
            IKernel kernal = new StandardKernel(new BindModule());
            var iTunesRepo = kernal.Get<IItunesItemRepository>();

            var actual = iTunesRepo.GetInfo("sdfsdfsdfsdf");

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void ItunesItemRetrieveReturnsExpectedArtist()
        {
            IKernel kernal = new StandardKernel(new BindModule());
            var iTunesRepo = kernal.Get<IItunesItemRepository>();

            var actual = iTunesRepo.GetInfo("ride weather diaries");

            var expectedArtist = "Ride";

            Assert.AreEqual(expectedArtist, actual.Artist, true);
        }
    }
}
