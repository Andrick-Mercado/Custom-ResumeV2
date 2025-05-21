using CustomResume.Library.Domain;

namespace CustomResume.Library.Infrastructure.Repo;

public interface IDatabaseService
{
    WebsiteDatabaseData GetWebsiteDatabaseDataAsync();
}