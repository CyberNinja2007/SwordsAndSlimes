using Autofac;
using SwordsAndSlimes.DAL.Modules;

namespace SwordsAndSlimes.BLL.Modules
{
    public class LoadDALModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        { 
            builder.RegisterModule(new ApplicationDbContextModule());
            builder.RegisterModule(new CourseachContextModule());
            //builder.RegisterModule(new IdentityModule());
            builder.RegisterModule(new UnitOfWorkModule());
        }
    }
}