using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Music_Releases.Repository;
using Ninject;
using System.Configuration;

namespace Music_Releases.BL.Tests
{
    [TestClass]
    public class ITunesSearchTests
    {
        [TestMethod]
        public void ITunesSearchIsNull()
        {
            IKernel kernal = new StandardKernel(new BindModule());
            var amazonSearchRepo = kernal.Get<IAmazonSearchRepository>();
            var amazonItemRepo = kernal.Get<IAmazonItemRepository>();
            var iTunesRepo = kernal.Get<IItunesItemRepository>();

            var iTunesItemSearch = new ItunesItemSearch(iTunesRepo);
            var results = iTunesItemSearch.GetBySearchTerm("kjhkjhkj");

            Assert.IsNull(results);
        }
    }
}
