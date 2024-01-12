using AgaiUI;
using AgaiUI.Data;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using AgaiUI.Core.Assets;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        // Add services to the container.        

        builder.RootComponents.Add<App>("app");

        builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        builder.Services.AddSingleton<IAssetsResolver, AssetsResolver>();
        builder.Services.AddSingleton<IAssetLoader<Sprite>, SpriteAssetLoader>();
        builder.Services.AddSingleton<IAssetLoaderFactory>(ctx =>
        {
            var factory = new AssetLoaderFactory();
            var spriteLoader = ctx.GetRequiredService<IAssetLoader<Sprite>>();
            factory.Register(spriteLoader);
            return factory;
        });

        #region session
        //builder.Services.AddDistributedMemoryCache();
        //
        //builder.Services.AddSession(options =>
        //{
        //    options.Cookie.Name = ".AdventureWorks.Session";
        //    options.IdleTimeout = TimeSpan.FromDays(365);
        //    options.Cookie.IsEssential = true;
        //});
        #endregion session

        var app = builder.Build();

        await app.RunAsync();
    }
}