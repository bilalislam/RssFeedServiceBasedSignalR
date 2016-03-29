namespace GIAF.BLL.Service.API.BaseRequestResponse
{
    public enum ResponseCode
    {
        SUCCESS = 0,
        GENERAL_ERROR = 1,
        SQL_ERROR = 2,
        INVALID_REQUEST = 3,
        WAITING = 4,
        UNSUCCESSFUL = 5,
        TIMEOUT = 6,

        //ORDER
        ORDER_NOT_FOUND = 100,

        //CUSTOMER
        CUSTOMER_NOT_FOUND = 200,

        //TEMPLATE
        TEMPLATE_NOT_FOUND = 900,
        CONTENT_NOT_FOUND = 901,

        //CAMPAIGN
        CAMPAIGN_NOT_FOUND = 300,
        INVALID_CAMPAIGN_CODE = 301,
        CAMPAIGN_CODE_ALREADY_USED = 302,
        INVALID_MSISDN = 303,
        CAMPAIGN_LIMIT_EXCEEDED = 304,

        //SMS
        USERNAME_PASSWORD_ERROR = 401,
        INSUFFICIENT_CREDITS = 402,
        ILLEGAL_CONTENT = 403,
        UNKNOWN_SMSTYPE = 404,
        WRONG_SENDERNAME = 405,
        EMPTY_MESSAGE_BODY = 406,
        LONG_MESSAGE_BODY = 407,
        UNKNOWN_GATEWAY = 408,
        INCORRECT_DATEFORMAT = 409,
        INVALID_TRACK_NO = 410,
        EMPTY_TRACK_NO = 411,
        UNSUCCESSFUL_DELIVERY = 412,
        NOT_EXIST_OR_NOW_SENDING = 413,
        NOT_EXIST = 414,
        CANCELED = 415,
        EMPTY_PHONE_NUMBER = 416
    }
}
