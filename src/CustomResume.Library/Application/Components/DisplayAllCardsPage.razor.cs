using CustomResume.Library.Domain;
using CustomResume.Library.Infrastructure;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CustomResume.Library.Application.Components;

public partial class DisplayAllCardsPage
{
    [Parameter] public string ClientRouteName { get; set; } = default!;
    [Inject] private IWebsiteRepo WebsiteRepo { get; set; } = default!;
    [Inject] private AppInfoRouter AppInfoRouter { get; set; } = default!;

    private bool _hasLoaded = false;
    private WebsiteData _websiteDatabaseData;
    private OtherPages _currentPage;


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (_hasLoaded && ClientRouteName == _currentPage?.Endpoint)
            return;

        _websiteDatabaseData = WebsiteRepo.GetWebsiteData();
        _currentPage = _websiteDatabaseData.OtherPages.FirstOrDefault(x => x.Endpoint == ClientRouteName);

        _hasLoaded = _currentPage is not null;
        StateHasChanged();
    }

    protected override async Task OnParametersSetAsync()
    {
        if (_websiteDatabaseData is null)
        {
            _websiteDatabaseData = WebsiteRepo.GetWebsiteData();
            _currentPage = _websiteDatabaseData.OtherPages.FirstOrDefault(x => x.Endpoint == ClientRouteName);
        }
        else if (_currentPage is not null && ClientRouteName != _currentPage.Endpoint)
        {
            _currentPage = _websiteDatabaseData.OtherPages.FirstOrDefault(x => x.Endpoint == ClientRouteName);
        }
        else
        {
            _currentPage ??= _websiteDatabaseData.OtherPages.FirstOrDefault(x => x.Endpoint == ClientRouteName);
        }

        _hasLoaded = _currentPage is not null;
        StateHasChanged();
    }

    private IEnumerable<IGrouping<string, Card>> GetCardsGroupedByCardName()
    {
        return _currentPage?.Cards.GroupBy(x => x.Name) ?? Array.Empty<IGrouping<string, Card>>();
    }
}