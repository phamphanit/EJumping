using EJumping.Domain.Infrastructure.MessageBrokers;
using EJumping.Infrastructure.MessageBrokers.Kafka;
using EJumping.Infrastructure.MessageBrokers.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Text;

namespace EJumping.Infrastructure.MessageBrokers
{
    public static class MessageBrokersCollectionExtensions
    {
        public static IServiceCollection AddRabbitMQSender<T>(this IServiceCollection services, RabbitMQOptions options)
        {
            services.AddSingleton<IMessageSender<T>>(new RabbitMQSender<T>(new RabbitMQSenderOptions
            {
                HostName = options.HostName,
                UserName = options.UserName,
                ExchangeName = options.ExchangeName,
                Password = options.Password,
                RoutingKey = options.RoutingKeys[typeof(T).Name]
            }));
            return services;
        }
        public static IServiceCollection AddKafkaSender<T>(this IServiceCollection services, KafkaOptions options )
        {
            services.AddSingleton<IMessageSender<T>>(new KafkaSender<T>(options.BootstrapServers, options.Topics[typeof(T).Name]));
            return services;
        }
        public static IServiceCollection AddMessageBusSender<T>(this IServiceCollection services, MessageBrokerOptions options, IHealthChecksBuilder healthChecksBuilder = null, HashSet<string> checkDuplicated = null)
        {
            if (options.UsedRabbitMQ())
            {
                services.AddRabbitMQSender<T>(options.RabbitMQ);
                if (healthChecksBuilder != null)
                {
                    var name = "Message Broker (RabbitMQ)";

                    if (checkDuplicated == null || !checkDuplicated.Contains(name))
                    {
                        healthChecksBuilder.AddRabbitMQ(
                            rabbitConnectionString: options.RabbitMQ.ConnectionString,
                            name: name,
                            failureStatus: HealthStatus.Degraded);
                    }

                    checkDuplicated?.Add(name);
                }
            }
            else if(options.UsedKafka())
            {
                services.AddKafkaSender<T>(options.Kafka);
            }
            return services;
        }
    }
}
