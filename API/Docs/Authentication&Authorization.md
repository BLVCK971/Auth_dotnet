## Builder (Services)

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();
//builder
//    .Services.AddIdentityCore<MyUser>()
//    .AddEntityFrameworkStores<AuthDbContext>() //Ajoute une implémentation Entity Framework de magasins d’informations d’identité.

## Pipeline (Middleware)
app.UseAuthorization();
app.MapIdentityApi<MyUser>(); //Ajoute des points de terminaison pour l’inscription, la connexion et la déconnexion à l’aide de ASP.NET Core Identity.

app.MapGet("/", (ClaimsPrincipal user) => $"Hello {user.Identity!.Name} !")
    .RequireAuthorization();
