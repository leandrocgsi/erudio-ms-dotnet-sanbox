using static GeekShopping.Web.Utils.HttpClientExtensions;

namespace GeekShopping.Web.Utils
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
