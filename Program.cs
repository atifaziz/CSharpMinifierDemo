namespace CSharpMinifierDemo
{
    using System.Linq;
    using Microsoft.AspNetCore.Blazor.Hosting;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Components.Builder;
    using Microsoft.Extensions.DependencyInjection;

    static class Program
    {
        public static void Main(string[] args) =>
            CreateHostBuilder(args).Build().Run();

        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
            BlazorWebAssemblyHost
                .CreateDefaultBuilder()
                .UseBlazorStartup<Startup>();
    }

    public sealed class Startup
    {
        public void ConfigureServices(IServiceCollection services) =>
            services.AddResponseCompression(options =>
                options.MimeTypes.Append("application/octet-stream")
                                 .Append("application/wasm"));

        public void Configure(IComponentsApplicationBuilder app) =>
            app.AddComponent<App>("app");
    }
}
