using GIAF.BLL.Contracts.RssFeedService;
using GIAF.DataAccess.Contracts.RssFeed;
using Microsoft.AspNet.SignalR.Client;
using Moq;

namespace GIAF.Tests.Home
{
    public class TestableController
    {
        public Mock<IRSSFeedService> _feedService;
        public Mock<IRssFeedRepository> _feedRepository;

        public TestableController(Mock<IRSSFeedService> feedService,
            Mock<IRssFeedRepository> rssFeedRepository)
        {
            _feedService = feedService;
            _feedRepository = rssFeedRepository;
        }

        public static TestableController Create()
        {
            return new TestableController(new Mock<IRSSFeedService>(),
                new Mock<IRssFeedRepository>());
        }
    }
}