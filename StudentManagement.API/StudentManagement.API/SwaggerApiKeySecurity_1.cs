using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen; //Allows modifying swagger documentation settings

namespace StudentManagement.API
{
    public static class SwaggerApiKeySecurity_1
    {
        public static void AddSwaggerApiKeySecurity_1(this SwaggerGenOptions c) // Swagger config object passed as parameter 
        {
            c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme // Api key security definition
            {
                Description = "Api key must appear in header",
                Type = SecuritySchemeType.ApiKey,
                Name = "XApiKey",
                In = ParameterLocation.Header,
                Scheme = "ApiKeyScheme"
            });

            OpenApiSecurityScheme? key = new OpenApiSecurityScheme() // Security Requirement, Api key must be present in header
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                },
                In = ParameterLocation.Header
            };

            OpenApiSecurityRequirement? requirement = new OpenApiSecurityRequirement
             {
                 { key, new List<string>() }
             };

            c.AddSecurityRequirement(requirement); // Register the security requirement in swagger
        }
    }
}

// Tells swagger that all Api requests must include the given key definition in the header
// Ensures Security Definition
