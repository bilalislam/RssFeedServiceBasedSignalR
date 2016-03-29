using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using GIAF.BLL.Contracts.RssFeedService;
using GIAF.BLL.Service.API.RssFeed;
using Microsoft.AspNet.SignalR.Client;
using LongPollingTransport = Microsoft.AspNet.SignalR.Client.Transports.LongPollingTransport;

namespace GIAF.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRSSFeedService _rssFeedService;
        private const string URL = "http://www.radikal.com.tr/d/rss/Rss_120.xml";

        public HomeController(IRSSFeedService rssFeedService)
        {
            _rssFeedService = rssFeedService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task Change(string url)
        {
            /* 
                Anlık olarak sürekli connection açıldıgından IIS büyük ihtimalle şişecektir.
                O yuzden session'a atıyoruz
            */
            if (Session["hubProxy"] == null)
            {
                HubConnection hubConnection = new HubConnection("http://localhost/demo/");
                IHubProxy hubProxy = hubConnection.CreateHubProxy("RssFeed");
                Session.Add("hubProxy", hubProxy);
                await hubConnection.Start(new LongPollingTransport());
                await hubProxy.Invoke("Change", url);
            }
            else
            {
                await ((IHubProxy)Session["hubProxy"]).Invoke("Change", url);
            }
        }

        public ActionResult GetData()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Read(string connectionId, string url)
        {
            var request = new FeedRequest();
            request.Url = !string.IsNullOrEmpty(url) ? url : URL;
            FeedResponse[] data = _rssFeedService.GetFeed(request) != null ? _rssFeedService.GetFeed(request).ToArray()
                                                                           : new List<FeedResponse>().ToArray();

            return Json(new
            {
                Data = data,
                Total = data.Length
            });
        }
    }
}
