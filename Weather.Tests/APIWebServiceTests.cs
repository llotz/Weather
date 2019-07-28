using NUnit.Framework;
using System;
using Weather;

namespace Tests
{
    public class APIWebServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Execute_GiveValidUrl_DownloadWorks()
        {
            APIWebService webService = new APIWebService("https://threema.ch/");
            Assert.IsTrue(webService.Execute());
        }

        [Test]
        public void Execute_GiveInvalidUrl_DownloadDoesntWork()
        {
            APIWebService webService = new APIWebService("https://HappyLittleBugs.what/");
            Assert.IsFalse(webService.Execute());
        }

        [Test]
        public void GetPageContent_DontDownloadFirst_ThrowsException()
        {
            APIWebService webService = new APIWebService("https://threema.ch");
            Assert.Throws<InvalidOperationException>(() => webService.GetPageContent());
        }

        [Test]
        public void GetPageContent_DownloadValidPage_ResultStringNotEmpty()
        {
            APIWebService webService = new APIWebService("https://threema.ch");
            Assert.IsTrue(webService.Execute());
            Assert.IsNotEmpty(webService.GetPageContent());
        }
    }
}