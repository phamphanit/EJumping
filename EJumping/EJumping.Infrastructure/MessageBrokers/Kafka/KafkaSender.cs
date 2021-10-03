using Confluent.Kafka;
using EJumping.Domain.Infrastructure.MessageBrokers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EJumping.Infrastructure.MessageBrokers.Kafka
{
    public class KafkaSender<T> : IMessageSender<T>
    {
        private readonly string _topic;
        private readonly IProducer<Null, string> _producer;
        public KafkaSender(string bootstrapServers,string topic)
        {
            _topic = topic;
            var config = new ProducerConfig { BootstrapServers = bootstrapServers };
            _producer = new ProducerBuilder<Null, string>(config).Build();

        }
        public void Dispose()
        {
            _producer.Flush(TimeSpan.FromSeconds(10));
            _producer.Dispose();
        }

        public Task SendAsync(T message, MetaData metaData = null, CancellationToken cancellationToken = default)
        {
            _ = await _producer.ProduceAsync(_topic, new Message<Null, string> { 
            Value = JsonConvert.SerializeObject(new Message<T> { 
            Data = message,
            MetaData = metaData
            })
            })
        }
    }
}
