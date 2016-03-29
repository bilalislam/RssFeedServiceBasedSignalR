using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GIAF.BLL.Service.API.RssFeed;

namespace GIAF.DataAccess.Contracts.RssFeed
{
    public interface IRssFeedRepository
    {
        IEnumerable<FeedResponse> GetFeedResponses(FeedRequest request);        
    }
}
