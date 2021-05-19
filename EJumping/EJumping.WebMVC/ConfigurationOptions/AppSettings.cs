using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace ClassifiedAds.WebMVC.ConfigurationOptions
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public Dictionary<string, string> SecurityHeaders { get; set; }

    }
}
