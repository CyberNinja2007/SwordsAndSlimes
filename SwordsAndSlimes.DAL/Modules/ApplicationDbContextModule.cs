using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SwordsAndSlimes.DAL.Data;

namespace SwordsAndSlimes.DAL.Modules
{
    public class ApplicationDbContextModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            // Register Entity Framework
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(configuration.GetConnectionString("DefaultConnection"));

            builder.RegisterType<ApplicationDbContext>()
                .WithParameter("options", dbContextOptionsBuilder.Options)
                .InstancePerLifetimeScope();
        }
    }
}