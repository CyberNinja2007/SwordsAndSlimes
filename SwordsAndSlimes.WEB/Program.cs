using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SwordsAndSlimes.WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var executionFolder = Path.GetDirectoryName(typeof(Program).Assembly.Location);
            AssemblyLoadContext.Default.Resolving += (AssemblyLoadContext context, AssemblyName assembly) 
                => context.LoadFromAssemblyPath(Path.Combine(executionFolder, $"{assembly.Name}.dll"));
            
            CreateHostBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webHostBuilder => {
                    webHostBuilder
                        //.UseContentRoot(Directory.GetCurrentDirectory())
                        .UseIISIntegration();
                })
                .Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}