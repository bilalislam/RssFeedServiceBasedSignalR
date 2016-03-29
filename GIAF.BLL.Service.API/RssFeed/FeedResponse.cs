using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GIAF.BLL.Service.API.BaseRequestResponse;

namespace GIAF.BLL.Service.API.RssFeed
{
    public class FeedResponse : BaseResponse
    {
        public string Guid { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
