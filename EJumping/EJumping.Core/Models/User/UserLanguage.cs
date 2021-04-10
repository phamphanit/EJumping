using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EJumping.Core.Models.User
{
    public enum UserLanguage
    {
        [JsonProperty("ko")]
        Korean = 0,
        [JsonProperty("en")]
        English = 1
    }
}
