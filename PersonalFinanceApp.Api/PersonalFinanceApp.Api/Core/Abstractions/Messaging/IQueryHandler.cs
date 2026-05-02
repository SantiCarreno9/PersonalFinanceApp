using PersonalFinanceApp.Api.Core.Endpoints;

namespace PersonalFinanceApp.Api.Core.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResponse>
{
    Task<Result<TResponse>> Handle(TQuery query, CancellationToken cancellationToken);
}
