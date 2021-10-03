using System;
using System.Collections.Generic;
using System.Text;

namespace EJumping.Domain.Infrastructure.MessageBrokers
{
    public class MetaData
    {
        public string MessageId { get; set; }
        public string MessageVersion { get; set; }
        public string CorrelationId { get; set; }
        public DateTimeOffset? CreationDateTime { get; set; }
        public DateTimeOffset? EnqueuedDateTime { get; set; }
        public string AccessToken { get; set; }
    }
}
