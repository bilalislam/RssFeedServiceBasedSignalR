using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GIAF.BLL.Service.API;
using GIAF.BLL.Service.API.RssFeed;

namespace GIAF.BLL.Contracts.RssFeedService
{
    [ServiceContract]
    public interface IRSSFeedService
    {
        [OperationContract]
        [NonTransactional]
        IEnumerable<FeedResponse> GetFeed(FeedRequest request);        
    }
}
