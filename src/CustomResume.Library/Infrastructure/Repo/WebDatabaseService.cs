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
        WebsiteDatabaseData websiteDatabaseData;
        try
        {
            websiteDatabaseData = _httpClient
                .GetFromJsonAsync<WebsiteDatabaseData>("database/websiteData.json")
                .GetAwaiter().GetResult();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new InvalidOperationException($"BaseAddress: {_httpClient?.BaseAddress}  Failed to load website database data.");
        }

        return websiteDatabaseData ?? throw new InvalidOperationException("Failed to load website database data.");
    }
}