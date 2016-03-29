using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GIAF.BLL.Service.API.BaseRequestResponse;

namespace GIAF.BLL.Service.API.RssFeed
{
    public class FeedRequest : BaseRequest
    {
        public string Url { get; set; }
    }
}
