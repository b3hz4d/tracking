using Microsoft.AspNetCore.Builder;
using Tracking;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();

builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("Tracking.Web.csproj");
await builder.RunAbpModuleAsync<TrackingWebTestModule>(applicationName: "Tracking.Web" );

public partial class Program
{
}
