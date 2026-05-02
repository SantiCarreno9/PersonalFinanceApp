using PersonalFinanceApp.Api.Core.Endpoints;

namespace PersonalFinanceApp.Api.Core.Abstractions.Messaging;

public interface ICommand : ICommand<Result>;

public interface ICommand<TResponse> : IBaseCommand;

public interface IBaseCommand;
