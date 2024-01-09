using DataAccessLayer;
using Mod;
using Ninject.Modules;

namespace BusinessLog
{
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Student>>().To<EntityFrameworkRepository<Student>>().InSingletonScope();
        }
    }
}