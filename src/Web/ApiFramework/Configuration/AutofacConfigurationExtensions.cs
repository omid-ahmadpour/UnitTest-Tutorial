using Autofac;
using UnitTestTutorial.Common;
using UnitTestTutorial.Common.General;
using UnitTestTutorial.Domain.Entities;
using UnitTestTutorial.Domain.IRepositories;
using UnitTestTutorial.Persistence.Db;
using UnitTestTutorial.Persistence.Jwt;
using UnitTestTutorial.Persistence.Repositories;

namespace UnitTestTutorial.ApiFramework.Configuration
{
    public static class AutofacConfigurationExtensions
    {
        public static void RegisterServices(this ContainerBuilder containerBuilder)
        {
            //RegisterType > As > Liftetime
            containerBuilder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            containerBuilder.RegisterGeneric(typeof(EfReadOnlyRepository<>)).As(typeof(IReanOnlyRepository<>)).InstancePerLifetimeScope();

            var commonAssembly = typeof(SiteSettings).Assembly;
            var entitiesAssembly = typeof(IEntity).Assembly;
            var dataAssembly = typeof(AppDbContext).Assembly;
            var servicesAssembly = typeof(JwtService).Assembly;

            containerBuilder.RegisterAssemblyTypes(commonAssembly, entitiesAssembly, dataAssembly, servicesAssembly)
                .AssignableTo<IScopedDependency>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterAssemblyTypes(commonAssembly, entitiesAssembly, dataAssembly, servicesAssembly)
                .AssignableTo<ITransientDependency>()
                .AsImplementedInterfaces()
                .InstancePerDependency();

            containerBuilder.RegisterAssemblyTypes(commonAssembly, entitiesAssembly, dataAssembly, servicesAssembly)
                .AssignableTo<ISingletonDependency>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}
