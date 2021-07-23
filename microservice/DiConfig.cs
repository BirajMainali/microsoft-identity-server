using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace microservice
{
    public static class DiConfig
    {
        public static void UseMicroServiceConfig(this IServiceCollection services)
        {
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.Authority = "https://localhost:5001";
                o.Audience = "api-source";
                o.RequireHttpsMetadata = false;
            });
            services.AddAuthorization(o =>
            {
                o.AddPolicy("PublicSecure", policy => policy.RequireClaim("client_id", "secret_client_id"));
            });
        }
    }
}