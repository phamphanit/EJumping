using EJumping.Infrastructure.MessageBrokers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJumping.Core.Models.Configurations
{
    public class EJumpingWebConfiguration
    {
        public ConnectionStrings ConnectionStrings { get; set; }

        public IdentityServerAuthentication IdentityServerAuthentication { get; set; }

        public string AllowedHosts { get; set; }

        public CORS CORS { get; set; }

        public Dictionary<string, string> SecurityHeaders { get; set; }
        public MessageBrokerOptions MessageBroker { get; set; }
    }
    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
        public string Idsrv { get; set; }
    }
    public class IdentityServerAuthentication
    {
        public string Authority { get; set; }
        public string ApiName { get; set; }
        public bool RequireHttpsMetadata { get; set; }
    }
    public class CORS
    {
        public bool AllowAnyOrigin { get; set; }

        public string[] AllowedOrigins { get; set; }
    }


}
