using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Music_Releases.Repository;
using Ninject;

namespace Music_Releases.BL.Tests
{
    [TestClass]
    public class AmazonSearchTests
    {
        [TestMethod]
        public void AmazonSearchIsNotNull()
        {
            IKernel kernal = new StandardKernel(new BindModule());
            var amazonSearchRepo = kernal.Get<IAmazonSearchRepository>();

            AmazonSearch amazonSearch = new AmazonSearch(amazonSearchRepo);
            var results = amazonSearch.SearchFromCommaSeparatedList("ride,the cure");

            Assert.IsNotNull(results);
        }

        [TestMethod]
        public void AmazonSearchFindsNothing()
        {
            IKernel kernal = new StandardKernel(new BindModule());
            var amazonSearchRepo = kernal.Get<IAmazonSearchRepository>();

            AmazonSearch amazonSearch = new AmazonSearch(amazonSearchRepo);
            var results = amazonSearch.SearchFromCommaSeparatedList("asdasdasd");

            Assert.IsTrue(results.Count == 0);
        }
    }
}
