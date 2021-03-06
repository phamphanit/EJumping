using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EJumping.Core.Common
{
    public class Dispatcher
    {
        private readonly IServiceProvider _provider;

        public Dispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public void Dispatch(ICommand command)
        {
            DispatchAsync(command).GetAwaiter().GetResult();
        }

        public async Task DispatchAsync(ICommand command, CancellationToken cancellationToken = default)
        {
            Type type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            await handler.HandleAsync((dynamic)command, cancellationToken);
        }

        public T Dispatch<T>(IQuery<T> query)
        {
            return DispatchAsync(query).GetAwaiter().GetResult();
        }

        public async Task<T> DispatchAsync<T>(IQuery<T> query, CancellationToken cancellationToken = default)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            Task<T> result = handler.HandleAsync((dynamic)query, cancellationToken);

            return await result;
        }
    }

    public interface ICommandHandler<TCommand>
       where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, CancellationToken cancellationToken = default);
    }
    public interface IQuery<TResult>
    {
    }
    public interface IQueryHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
    }
}