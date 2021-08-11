using GeekShopping.Web.Utils;
using System;
using System.Threading.Tasks;

namespace GeekShopping.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        Task<T> SendAsync<T>(ApiRequest request);
    }
}
