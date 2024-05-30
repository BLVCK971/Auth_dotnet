using Microsoft.OpenApi.Models;

namespace API.Services;

public static class Swagger
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.CustomSchemaIds(type => type.ToString());
            c.AddSecurityDefinition(
                "Bearer",
                new OpenApiSecurityScheme
                {
                    Description =
                      @"JWT Authorization header using the Bearer scheme.
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                }
            );

            c.AddSecurityRequirement(
                new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                }
            );

            c.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "API", });

            //c.OperationFilter<FileResultContentTypeOperationFilter>();
        });
        return services;
    }
}
