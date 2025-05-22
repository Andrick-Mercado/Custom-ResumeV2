using CustomResume.Library.Domain;
using CustomResume.Library.Infrastructure.Repo;

namespace CustomResume.Library.Infrastructure;

public interface IWebsiteRepo
{
    Configurations GetConfigurations();
    PersonalInformation GetPersonalInformation();
    WebsiteData GetWebsiteData();
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
            _websiteDatabaseData = _databaseService.GetWebsiteDatabaseDataAsync();
            _initialized = true;
    }

    public Configurations GetConfigurations()
    {
        EnsureInitializedAsync();
        return _websiteDatabaseData.Configurations;
    }

    public PersonalInformation GetPersonalInformation()
    {
        EnsureInitializedAsync();
        return _websiteDatabaseData.PersonalInformation;
    }

    public WebsiteData GetWebsiteData()
    {
        EnsureInitializedAsync();
        return _websiteDatabaseData.WebsiteData;
    }
}