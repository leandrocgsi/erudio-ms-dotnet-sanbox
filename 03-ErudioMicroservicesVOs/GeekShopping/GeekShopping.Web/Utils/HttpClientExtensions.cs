using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekShopping.Web.Utils
{
    public class HttpClientExtensions
    {
        public static string ProductAPIBase {  get; set; }

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE,
            PATCH
        }
    }
}
