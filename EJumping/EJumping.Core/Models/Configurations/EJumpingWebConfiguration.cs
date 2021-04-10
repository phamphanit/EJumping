using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJumping.Core.Models.Configurations
{
    public class EJumpingWebConfiguration
    {
        public string RootUrl { get; set; }
        public string WsUrl { get; set; }
        public string AmazonS3Root { get; set; }
        public string IdSrvUrl { get; set; }
        public string IdSrvConnectionString { get; set; }
    }

}
