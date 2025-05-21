using CustomResume.Library.Domain;
using CustomResume.Library.Infrastructure.Repo;

namespace CustomResume.Library.Infrastructure;

public interface IWebsiteRepo
{
    Task<Configurations> GetConfigurations();
    Task<PersonalInformation> GetPersonalInformation();
    Task<WebsiteData> GetWebsiteData();
}

public class WebsiteRepo : IWebsiteRepo
{
    private readonly IDatabaseService _databaseService;
    private WebsiteDatabaseData _websiteDatabaseData = default!;
    private bool _initialized = false;

    public WebsiteRepo(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public void EnsureInitializedAsync()
    {
        if (_initialized is false)
        {
            _websiteDatabaseData = _databaseService.GetWebsiteDatabaseDataAsync();
            _initialized = true;
        }
    }

    public async Task<Configurations> GetConfigurations()
    {
        await Task.CompletedTask;
        EnsureInitializedAsync();
        return _websiteDatabaseData.Configurations;
    }

    public async Task<PersonalInformation> GetPersonalInformation()
    {
        await Task.CompletedTask;
        EnsureInitializedAsync();
        return _websiteDatabaseData.PersonalInformation;
    }

    public async Task<WebsiteData> GetWebsiteData()
    {
        await Task.CompletedTask;
        EnsureInitializedAsync();
        return _websiteDatabaseData.WebsiteData;
    }
}