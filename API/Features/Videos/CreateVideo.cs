using API.Contracts;
using API.Database;
using API.Entities;
using API.Shared;
using Carter;
using FluentValidation;
using Mapster;
using MediatR;

namespace API.Features.Videos;

public static class CreateVideo
{
    public class Command : IRequest<Result<Guid>>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string OmlessId { get; set; } = string.Empty;
    }

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(c => c.Title).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
        }
    }

    internal sealed class Handler : IRequestHandler<Command, Result<Guid>>
    {
        private readonly AuthDbContext _dbContext;
        private readonly IValidator<Command> _validator;

        public Handler(AuthDbContext dbContext, IValidator<Command> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public async Task<Result<Guid>> Handle(Command request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return Result.Failure<Guid>(
                    new Error("CreateVideo.Validation", validationResult.ToString())
                );
            }

            var video = new Video
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Url = request.Url,
                OmlessId = Guid.Parse(request.OmlessId),
            };

            _dbContext.Add(video);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return video.Id;
        }
    }
}

public class CreateVideoEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(
            "api/videos",
            async (CreateVideoRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateVideo.Command>();

                var result = await sender.Send(command);

                if (result.IsFailure)
                {
                    return Results.BadRequest(result.Error);
                }

                return Results.Ok(result.Value);
            }
        );
    }
}
