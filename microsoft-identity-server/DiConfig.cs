using Microsoft.Extensions.DependencyInjection;

namespace microsoft_identity_server
{
    public static class DiConfig
    {
        public static void UseConfiguration(this IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddOperationalStore(o =>
                {
                    o.EnableTokenCleanup = true;
                    o.TokenCleanupInterval = 20;
                }).AddInMemoryApiResources(IdentityConfig.GetApiResources())
                .AddInMemoryClients(IdentityConfig.GetClients());
        }
    }
}