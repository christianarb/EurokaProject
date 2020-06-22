namespace Netcore.Infrastructure.Crosscutting
{
    public class JwtSettings
    {
        public string InternalSecretKey { get; set; }

        public string ExpirationTime { get; set; }
    }
}
