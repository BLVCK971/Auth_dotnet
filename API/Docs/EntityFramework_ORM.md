### Services (builder)
```cs
builder.Services.AddDbContext<AuthDbContext>(x =>
            x.UseSqlite("DataSource=app.db")
                //UseSqlServer(UserSecrets.Read("SqlServerConnectionString"))
                //UseNpgsql(UserSecrets.Read("PostGresConnectionString"))
                //UseCosmos("https://localhost:8081", UserSecrets.Read("CosmosKey"), "Customers")
#### DbContextOptionsBuilder
                //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                //.UseLazyLoadingProxies()
                .EnableSensitiveDataLogging()
                //.EnableDetailedErrors()
                //.EnableServiceProviderCaching()
                .LogTo(Console.WriteLine, LogLevel.Information)
        );
```
