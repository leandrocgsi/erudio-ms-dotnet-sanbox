using GeekShop.IdentityServer.Controllers.Consent;

namespace GeekShop.IdentityServer.Controllers.Device
{
    public class DeviceAuthorizationInputModel : ConsentInputModel
    {
        public string UserCode { get; set; }
    }
}