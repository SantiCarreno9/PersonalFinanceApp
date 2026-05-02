using Microsoft.AspNetCore.Routing;

namespace PersonalFinanceApp.Api.Core.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
