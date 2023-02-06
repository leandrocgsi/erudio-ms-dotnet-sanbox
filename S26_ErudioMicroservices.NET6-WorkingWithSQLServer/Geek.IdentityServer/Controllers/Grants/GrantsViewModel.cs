namespace GeekShop.IdentityServer.Controllers.Grants
{
    public class GrantsViewModel
    {
        public IEnumerable<GrantViewModel> Grants { get; set; }
    }
    public class GrantViewModel
    {
        public string ClientId { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public string ClientUrl { get; set; } = string.Empty;
        public string ClientLogoUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public DateTime? Expires { get; set; }
        public IEnumerable<string> IdentityGrantNames { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<string> ApiGrantNames { get; set; } = Enumerable.Empty<string>();
    }
}