using System.Data.Entity;
using System.Net;
using System.ServiceModel.Description;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using GIAF.BLL.Contracts.RssFeedService;
using GIAF.DataAccess.RssFeed;
using GIAF.Entity;
using GIAF.InfraStructure.Repository;
using GIAF.InfraStructure.UnitOfWork;

namespace GIAF.BLL.Bootsrapper
{
    public class ComponentsBootsrapper
    {
        private IWindsorContainer _container;

        public IWindsorContainer Intialize()
        {
            _container = new WindsorContainer();

            var returnFaults = new ServiceDebugBehavior
            {
                IncludeExceptionDetailInFaults = true,
                HttpHelpPageEnabled = true
            };
            _container.Register(
                Component.For<IServiceBehavior>().Instance(returnFaults)
            );

            _container.Install(FromAssembly.This());

            return _container;
        }
    }

    public class BusinessInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {                        
            container.Register(Component.For<IRSSFeedService>().ImplementedBy<RssFeedService.RssFeedService>().Interceptors<UnitOfWorkInterceptor>().LifeStyle.Transient);            
        }
    }

    public class DataComponenentsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>().LifeStyle.PerWcfOperation());

            container.Register(
                    Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifeStyle.PerWcfOperation(),
                    Component.For<IUnitOfWorkFactory>().ImplementedBy<UnitOfWorkFactory>().LifeStyle.PerWcfSession());
            
            container.Register(Component.For(typeof(DbContext)).ImplementedBy(typeof(ModelContainerEntities)).LifeStyle.Transient);            
            container.Register(Types.FromAssemblyContaining<RssFeedRepository>().BasedOn(typeof(Repository<>)).WithService.DefaultInterfaces().LifestyleTransient());
        }
    }

    public class InterceptorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<UnitOfWorkInterceptor>().LifeStyle.Transient);
        }
    }
}
