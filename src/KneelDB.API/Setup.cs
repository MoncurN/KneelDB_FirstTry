using Microsoft.Extensions.DependencyInjection;
using KneelDB.Library;

namespace KneelDB.API;

public static class Setup
{
    public static IServiceCollection AddKneelDbServices(this IServiceCollection services)
    {
        services.AddSingleton<IApi, Api>();

        services.AddSingleton<IDatabase, Database>();
        services.AddSingleton<IStorage, Storage>();

        return services;
    }
}
