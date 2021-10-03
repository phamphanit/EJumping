using System;
using System.Collections.Generic;
using System.Text;

namespace EJumping.Infrastructure.MessageBrokers.Kafka
{
    public class KafkaOptions
    {
        public string BootstrapServers { get; set; }

        public string GroupId { get; set; }

        public Dictionary<string, string> Topics { get; set; }
    }
}
