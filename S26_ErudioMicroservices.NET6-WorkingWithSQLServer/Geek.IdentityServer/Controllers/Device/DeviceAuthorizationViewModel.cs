using GeekShop.IdentityServer.Controllers.Consent;

namespace GeekShop.IdentityServer.Controllers.Device
{
    public class DeviceAuthorizationViewModel : ConsentViewModel
    {
        public string UserCode { get; set; }
        public bool ConfirmUserCode { get; set; }
    }
}