namespace EJumping.Api.ConfigurationOptions
{
    public class IdentityServerAuthentication
    {
        public string Authority { get; set; }

        public string ApiName { get; set; }

        public bool RequireHttpsMetadata { get; set; }
    }
}
