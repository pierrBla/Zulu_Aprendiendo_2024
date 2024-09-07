using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Zulu.Web;
using Zulu.Web.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
//vamos unir el  api  con proyecto web remplazar en la Uri builder.HostEnvironment.BaseAddress por puerto  de salida del  api
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7162/") });
//inyectar Repository
builder.Services.AddScoped<IRepository, Repository>();

await builder.Build().RunAsync();
