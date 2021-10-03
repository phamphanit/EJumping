using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EJumping.Domain.Infrastructure.MessageBrokers
{
    public interface IMessageSender<T>
    {
        Task SendAsync(T message, MetaData metaData = null, CancellationToken cancellationToken = default);

    }
}
