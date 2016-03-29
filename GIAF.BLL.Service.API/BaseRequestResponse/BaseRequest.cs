using System;
using System.Runtime.Serialization;

namespace GIAF.BLL.Service.API.BaseRequestResponse
{
    [DataContract]
    public abstract class BaseRequest
    {
        public string ConnectionId { get; set; }

        public Nullable<int> UserId { get; set; }
    }
}
