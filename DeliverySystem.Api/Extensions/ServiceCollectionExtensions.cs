using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi;

namespace DeliverySystem.Extensions;

internal static  class ServiceCollectionExtensions
{
    internal static IServiceCollection AddSwaggerGenWithAuth(this IServiceCollection services)
    {
        services.AddSwaggerGen(o =>
        {
            o.CustomSchemaIds(id => id.FullName!.Replace("+", "-"));

            const string securitySchemeName = JwtBearerDefaults.AuthenticationScheme;

            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "Enter the JWT token without the 'Bearer' prefix.",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT"
            };
            
            o.AddSecurityDefinition(securitySchemeName, securityScheme);
            o.AddSecurityRequirement(document => new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference(securitySchemeName, document)] = []
            });
        });
        
        return services;
    }
}
