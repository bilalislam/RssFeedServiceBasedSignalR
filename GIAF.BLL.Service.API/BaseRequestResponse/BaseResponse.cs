using System.Runtime.Serialization;

namespace GIAF.BLL.Service.API.BaseRequestResponse
{
    [DataContract]
    public abstract class BaseResponse
    {
        protected BaseResponse()
        {
            this.ResponseCode = ResponseCode.SUCCESS;
        }

        [DataMember]
        public ResponseCode ResponseCode { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}
