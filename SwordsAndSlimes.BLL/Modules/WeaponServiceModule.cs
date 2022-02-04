using Autofac;
using SwordsAndSlimes.BLL.Abstraction;
using SwordsAndSlimes.BLL.Models;
using SwordsAndSlimes.BLL.Services;
using SwordsAndSlimes.DAL.Abstraction;

namespace SwordsAndSlimes.BLL.Modules
{
    public class WeaponServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new WeaponService(c.Resolve<IUnitOfWork>()))
                .As<IService<WeaponDTO>>()
                .InstancePerLifetimeScope();
        }
    }
}