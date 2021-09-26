using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace EJumping.WebMVC.ConfigurationOptions
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public Dictionary<string, string> SecurityHeaders { get; set; }

    }
}
