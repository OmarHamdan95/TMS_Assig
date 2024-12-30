using MediatR;
using Task = System.Threading.Tasks.Task;

namespace TMS.Database.Common;

public class NoMediator : IMediator
{
    public IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        return default;
    }

    public IAsyncEnumerable<object> CreateStream(object request, CancellationToken cancellationToken = default)
    {
        return default(IAsyncEnumerable<object>);
    }

    public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
    {
        return Task.CompletedTask;
    }

    public Task Publish(object notification, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }

    public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(default(TResponse));
    }

    public Task Send<TRequest>(TRequest request, CancellationToken cancellationToken = new CancellationToken()) where TRequest : IRequest
    {
        return Task.CompletedTask;
    }

    public Task<object> Send(object request, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(default(object));
    }

}
