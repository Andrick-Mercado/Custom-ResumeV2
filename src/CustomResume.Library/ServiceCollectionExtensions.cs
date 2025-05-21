using Blazored.LocalStorage;
using CustomResume.Library.Infrastructure;
using CustomResume.Library.Infrastructure.Repo;
using Microsoft.Extensions.DependencyInjection;

namespace CustomResume.Library;

public static class ServiceCollectionExtensions
{
    public static async Task<IServiceCollection> AddCustomResumeBlazorServicesAsync(this IServiceCollection services,
        string baseAddress)
    {
        var websiteRepo =
            new WebsiteRepo(new WebDatabaseService(new HttpClient { BaseAddress = new Uri(baseAddress) }));
        await websiteRepo.EnsureInitializedAsync().ConfigureAwait(false);
        services.AddSingleton<IWebsiteRepo>(websiteRepo);

        services.AddSingleton<IProfileService, ProfileService>();

        services.AddSingleton(new AppInfoRouter(AppInfoRouterType.Blazor));

        services.AddBlazoredLocalStorageAsSingleton();
        return services;
    }
}