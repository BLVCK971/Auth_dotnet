# API Documentation : Swagger

## Usage 
At the root address, Add /swagger to access
Good with Nswag

## Featuring

Go look for Controllers (probably folder) and add them to the json file (/swagger/v1/swagger.json) then swaggerUI will show the documentation at /swagger/index.html.

Dont look if they are really used : Will provide a 404 error.

## Implementation

### Builder (Services)
builder.Services.AddSwagger(); // Example in Services/Swagger.cs

services.AddSwaggerGen();
services.AddSwaggerGen(c => {  
c.CustomSchemaIds(
type => type.ToString()); 
"Bearer", 
c.AddSecurityDefinition( 
new OpenApiSecurityScheme{
                    
Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below. \r\n\r\n Example: 'Bearer 12345abcdef'", 
Name = "Authorization",
In = ParameterLocation.Header, 
Type = SecuritySchemeType.ApiKey, 
Scheme = "Bearer" }
);
c.AddSecurityRequirement(
                new OpenApiSecurityRequirement() {
                    { new OpenApiSecurityScheme
                        { Reference = new OpenApiReference
                            { Type = ReferenceType.SecurityScheme,
                                Id = "Bearer" },
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
 

### Middleware (Pipeline)
app.UseSwaggerUI(c =>
app.UseSwagger();
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
});

