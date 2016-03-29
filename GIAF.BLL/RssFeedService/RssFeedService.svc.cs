using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GIAF.BLL.Contracts.RssFeedService;
using GIAF.BLL.Service.API.RssFeed;
using GIAF.DataAccess.Contracts.RssFeed;
using GIAF.DataAccess.RssFeed;

namespace GIAF.BLL.RssFeedService
{
    public class RssFeedService : IRSSFeedService
    {
        protected readonly IRssFeedRepository _rssFeedRepository;

        public RssFeedService()
        {
            _rssFeedRepository = new RssFeedRepository();
        }

        public RssFeedService(IRssFeedRepository rssFeedRepository)
        {
            this._rssFeedRepository = rssFeedRepository;
        }

        public IEnumerable<FeedResponse> GetFeed(FeedRequest request)
        {
            return _rssFeedRepository.GetFeedResponses(request);
        }
    }
}
