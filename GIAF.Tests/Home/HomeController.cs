using System.Collections.Generic;
using GIAF.BLL.Service.API.RssFeed;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GIAF.Tests.Home
{
    [TestClass]
    public class HomeController
    {
        private TestableController _controller;

        public HomeController()
        {
            _controller = TestableController.Create();
        }

        [TestMethod]
        public void Should_Fill_Rss_Data()
        {
            _controller._feedService.Setup(x => x.GetFeed(It.IsAny<FeedRequest>()))
                .Returns(It.IsAny<IEnumerable<FeedResponse>>());

            _controller._feedRepository.Setup(x => x.GetFeedResponses(It.IsAny<FeedRequest>()))
                .Returns(It.IsAny<IEnumerable<FeedResponse>>());

            GIAF.UI.Controllers.HomeController controller = new GIAF.UI.Controllers.HomeController(_controller._feedService.Object);
            var data = controller.Read(string.Empty, string.Empty);

            Assert.IsNotNull(data);
            _controller._feedService.Verify(x => x.GetFeed(It.IsAny<FeedRequest>()), Times.Once);

        }
    }
}
