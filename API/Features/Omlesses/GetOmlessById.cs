
using Carter;
using MediatR;
using Microsoft.EntityFrameworkCore;
using API.Contracts;
using API.Database;
using API.Shared;

namespace Api.Features.Omlesses;

public static class GetOmlessById
{
    public class Query : IRequest<Result<OmlessResponse>>
    {
        public Guid Id { get; set; }
    }

    internal sealed class Handler : IRequestHandler<Query, Result<OmlessResponse>>
    {
        private readonly AuthDbContext _dbContext;

        public Handler(AuthDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<OmlessResponse>> Handle(Query request, CancellationToken cancellationToken)
        {
            var omlessResponse = await _dbContext
                .Omlesses
                .AsNoTracking()
                .Where(omless => omless.Id == request.Id)
                .Select(omless => new OmlessResponse
                {
                    Id = omless.Id,
                    Name = omless.Name,
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (omlessResponse is null)
            {
                return Result.Failure<OmlessResponse>(new Error(
                    "GetOmless.Null",
                    "The omless with the specified ID was not found"));
            }

            return omlessResponse;
        }
    }
}

public class GetOmlessByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/omlesss/{id}", async (Guid id, ISender sender) =>
        {
            var query = new GetOmlessById.Query { Id = id };

            var result = await sender.Send(query);

            if (result.IsFailure)
            {
                return Results.NotFound(result.Error);
            }

            return Results.Ok(result.Value);
        });
    }
}
