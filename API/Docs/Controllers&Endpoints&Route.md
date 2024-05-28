# Controllers VS Endpoints

## Controllers Implementation

### Builder (Services)

```cs
builder.Services.AddControllers();
```

### Middleware (Pipeline)
```cs
app.MapControllers();
app.MapControllerRoute();
app.MapAreaControllerRoute();
app.MapDefaultControllerRoute();
app.MapDynamicControllerRoute();
app.MapFallbackToController();
app.MapFallbackToAreaController();

```
# Endpoints

## Endpoints Implementation

### Builder (Services)
```cs
builder.Services.AddApiEndpoints();
### Middleware (Pipeline)
app.MapGet("/", (ClaimsPrincipal user) => $"Hello {user.Identity!.Name} !")
```

# Route
