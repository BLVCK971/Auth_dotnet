using System.Security.Claims;
using Api.Filters;
using Api.Identity;
using Api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Api;

public static class StartupExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
		builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwagger();
        builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
        builder.Services.AddAuthorizationBuilder();

        builder.Services.AddDbContext<AuthDbContext>(x =>
            x.UseSqlite("DataSource=app.db")
                //UseSqlServer(UserSecrets.Read("SqlServerConnectionString"))
                //UseNpgsql(UserSecrets.Read("PostGresConnectionString"))
                //UseCosmos("https://localhost:8081", UserSecrets.Read("CosmosKey"), "Customers")
                //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                //.UseLazyLoadingProxies()
                .EnableSensitiveDataLogging()
                //.EnableDetailedErrors()
                //.EnableServiceProviderCaching()
                .LogTo(Console.WriteLine, LogLevel.Information)
        );

        builder
            .Services.AddIdentityCore<MyUser>()
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddApiEndpoints();

        builder.Services.AddControllers(opt =>
        {
        opt.Filters.Add<MyLogging>();
        //  opt.Filters.Add(new MyLogging());
        });

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseRouting();
        app.UseAuthorization();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
        });
        app.MapIdentityApi<MyUser>();

        // EndPoint Example
        app.MapGet("/", (ClaimsPrincipal user) => $"Hello {user.Identity!.Name} !")
            .RequireAuthorization();
        

		//app.UseEndpoints(endpoints => endpoints.MapControllers());
        app.MapControllers();
		return app;
    }
}
