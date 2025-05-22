using CustomResume.Library.Domain;
using CustomResume.Library.Infrastructure;
using CustomResumeBlazor.Domain;
using Microsoft.AspNetCore.Components;

namespace CustomResume.Library.Application.Components;

public partial class SideBarPage
{
    [Inject] private IWebsiteRepo WebsiteRepo { get; set; } = default!;

    private bool hasLoaded = false;
    private WebsiteData websiteData;
    private IOrderedEnumerable<OtherPages> sortedOtherPages;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (hasLoaded) return;

        websiteData =  WebsiteRepo.GetWebsiteData();
        hasLoaded = websiteData is not null;
        sortedOtherPages = websiteData?.OtherPages?.OrderBy(x => x.SortOrder);
        StateHasChanged();
    }
}