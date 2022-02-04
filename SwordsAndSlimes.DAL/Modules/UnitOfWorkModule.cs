using Autofac;
using SwordsAndSlimes.DAL.Abstraction;
using SwordsAndSlimes.DAL.Data;
using SwordsAndSlimes.DAL.Repositories;

namespace SwordsAndSlimes.DAL.Modules
{
    public class UnitOfWorkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new UnitOfWork(c.Resolve<CourseachContext>()))
                .As<IUnitOfWork>()
                .SingleInstance();
        }
    }
}