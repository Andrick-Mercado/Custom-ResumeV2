using CustomResume.Blazor;
using CustomResume.Library;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

ConfigureServices(builder.Services, builder.HostEnvironment.BaseAddress);

await builder.Build().RunAsync();
static void ConfigureServices(IServiceCollection services, string baseAddress)
{
    services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(baseAddress) });
    services.AddMudServices();
    services.AddCustomResumeBlazorServicesAsync(baseAddress).GetAwaiter().GetResult();
}