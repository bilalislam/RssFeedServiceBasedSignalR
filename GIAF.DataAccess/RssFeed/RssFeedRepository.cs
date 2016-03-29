using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using GIAF.BLL.Service.API.RssFeed;
using GIAF.DataAccess.Contracts.RssFeed;
using GIAF.InfraStructure.Repository;

namespace GIAF.DataAccess.RssFeed
{
    public class RssFeedRepository : Repository<FeedResponse>, IRssFeedRepository
    {
        public IEnumerable<FeedResponse> GetFeedResponses(FeedRequest request)
        {
            XDocument feedXml = XDocument.Load(request.Url);
            var feeds = from feed in feedXml.Descendants("item")
                        select new FeedResponse()
                        {
                            Guid = feed.Element("guid").Value,
                            Title = feed.Element("title").Value,
                            Link = feed.Element("link").Value,
                            Description = feed.Element("description").Value
                        };          

            return feeds;
        }
    }
}
