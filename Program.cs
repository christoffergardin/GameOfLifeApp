using GameOfLifeApp.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;



namespace GameOfLifeApp;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        
        // Registering the Game of Life rules as a service
        builder.Services.AddSingleton<IGameRules, GameOfLifeRules>();

        await builder.Build().RunAsync();
    }
}