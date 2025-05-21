using System.Net.Http.Json;
using CustomResume.Library.Domain;

namespace CustomResume.Library.Infrastructure.Repo;

public class WebDatabaseService : IDatabaseService
{
    private readonly HttpClient _httpClient;

    public WebDatabaseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public WebsiteDatabaseData GetWebsiteDatabaseDataAsync()
    {
        var getWebsiteDatabaseData = _httpClient
            .GetFromJsonAsync<WebsiteDatabaseData>("database/websiteData.json")
            .GetAwaiter().GetResult();

        return getWebsiteDatabaseData ?? throw new InvalidOperationException();
    }
}