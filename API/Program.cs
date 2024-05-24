using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

builder.Services.AddDbContext<AuthDbContext>(x =>
    x.UseSqlite("DataSource=authapp.db")
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

var app = builder.Build();

app.MapIdentityApi<MyUser>();

app.MapGet("/", (ClaimsPrincipal user) => $"Hello {user.Identity!.Name} !")
    .RequireAuthorization();

app.Run();

class MyUser : IdentityUser { }

class AuthDbContext : IdentityDbContext<MyUser>
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options) { }
}
