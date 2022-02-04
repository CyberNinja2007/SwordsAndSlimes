using Autofac;
using SwordsAndSlimes.BLL.Abstraction;
using SwordsAndSlimes.BLL.Models;
using SwordsAndSlimes.BLL.Services;
using SwordsAndSlimes.DAL.Abstraction;

namespace SwordsAndSlimes.BLL.Modules
{
    public class CharacterServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new CharacterService(c.Resolve<IUnitOfWork>()))
                .As<IService<CharacterDTO>>()
                .InstancePerLifetimeScope();
        }
    }
}