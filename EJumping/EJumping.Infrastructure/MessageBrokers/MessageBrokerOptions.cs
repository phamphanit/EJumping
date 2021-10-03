using EJumping.Infrastructure.MessageBrokers.Kafka;
using EJumping.Infrastructure.MessageBrokers.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace EJumping.Infrastructure.MessageBrokers
{
    public class MessageBrokerOptions
    {
        public string Provider { get; set; }
        public RabbitMQOptions RabbitMQ { get; set; }
        public KafkaOptions Kafka { get; set; }
        public bool UsedRabbitMQ()
        {
            return Provider == "RabbitMQ";
        }
        public bool UsedKafka()
        {
            return Provider == "Kafka";
        }

    }
}
