
using System.Collections.Generic;
using EJumping.Core.Logging;
namespace EJumping.Api.ConfigurationOptions
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public LoggingOptions Logging { get; set; }
        
        public IdentityServerAuthentication IdentityServerAuthentication { get; set; }

        public string AllowedHosts { get; set; }

        public CORS CORS { get; set; }
        
        public Dictionary<string, string> SecurityHeaders { get; set; }
    }
}
