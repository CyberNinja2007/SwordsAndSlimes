using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SwordsAndSlimes.DAL.Data;

namespace SwordsAndSlimes.DAL.Modules
{
    public class CourseachContextModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            // Register Entity Framework
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<CourseachContext>()
                .UseSqlServer(configuration.GetConnectionString("GameConnection"));

            builder.RegisterType<CourseachContext>()
                .WithParameter("options", dbContextOptionsBuilder.Options)
                .InstancePerLifetimeScope();
        }
    }
}