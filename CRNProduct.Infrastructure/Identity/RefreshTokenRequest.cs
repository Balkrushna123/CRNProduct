namespace CRNProduct.Infrastructure.Identity
{
    public class RefreshTokenRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}