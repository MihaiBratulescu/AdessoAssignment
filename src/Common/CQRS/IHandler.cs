namespace Common
{
    public interface IHandler
    {
        Task<TResult> SendAsync<TResult>(IQuery<TResult> query);
        Task SendAsync(ICommand command);
    }

    public class Handler : IHandler
    {
        private readonly Dictionary<Type, Type> handlers;
        private readonly Func<Type, object> serviceResolver;

        public Handler(Func<Type, object> serviceResolver, Dictionary<Type, Type> handlers)
        {
            this.handlers = handlers;
            this.serviceResolver = serviceResolver;
        }

        public Task<TResult> SendAsync<TResult>(IQuery<TResult> query)
        {
            object handler = serviceResolver(handlers[query.GetType()]);

            return (Task<TResult>)Invoke(handler, query, nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync));
        }

        public Task SendAsync(ICommand command)
        {
            object handler = serviceResolver(handlers[command.GetType()]);

            return (Task)Invoke(handler, command, nameof(ICommandHandler<ICommand>.HandleAsync));
        }

        private static object Invoke(object handler, object parameter, string methodName)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return handler
                !.GetType()
                !.GetMethod(methodName)
                !.Invoke(handler, new[] { parameter });
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
