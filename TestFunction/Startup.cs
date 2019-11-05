using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.ObjectPool;
using System.Diagnostics;
using System.IO;
using System.Reflection;

[assembly: FunctionsStartup(typeof(TestFunction.Startup))]

namespace TestFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            ConfigureTest1(builder);
        }

        private void ConfigureTest1(IFunctionsHostBuilder builder)
        {
            builder.Services.AddMvcCore();
        }

        private void ConfigureTest2(IFunctionsHostBuilder builder)
        {
            builder.Services.AddOptions();
            builder.Services.AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();
            builder.Services.AddSingleton<DiagnosticSource>(new DiagnosticListener("Microsoft.AspNetCore"));
            builder.Services.AddLogging();
            builder.Services.AddMvcCore(); // This line can
        }
    }
}
