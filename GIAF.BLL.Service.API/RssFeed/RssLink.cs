using GIAF.BLL.Service.API.BaseRequestResponse;

namespace GIAF.BLL.Service.API.RssFeed
{
    public class RssLink : BaseResponse
    {
        public string LinkName { get; set; }
        public string Url { get; set; }
    }
}