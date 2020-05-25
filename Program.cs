namespace CSharpMinifierDemo
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            var baseUrl = new Uri(builder.HostEnvironment.BaseAddress);
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = baseUrl });
            await builder.Build().RunAsync();
        }
    }
}
