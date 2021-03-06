using Autofac;
using SwordsAndSlimes.BLL.Abstraction;
using SwordsAndSlimes.BLL.Models;
using SwordsAndSlimes.BLL.Services;
using SwordsAndSlimes.DAL.Abstraction;

namespace SwordsAndSlimes.BLL.Modules
{
    public class MonsterServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new MonsterService(c.Resolve<IUnitOfWork>()))
                .As<IService<MonsterDTO>>()
                .InstancePerLifetimeScope();
        }
    }
}