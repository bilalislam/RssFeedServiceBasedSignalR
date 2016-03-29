using System.Web.Http.Controllers;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using GIAF.BLL.Bootsrapper;
using GIAF.UI.Plumbing;

namespace GIAF.UI
{
    public class HttpContextBase
    {
        private static IWindsorContainer CurrentContainer { get; set; }

        public static void SetCurrentContainer()
        {
            var bs = new ComponentsBootsrapper();
            CurrentContainer = bs.Intialize();

            CurrentContainer.Install(FromAssembly.This());

            var controllerFactory = new WindsorControllerFactory(CurrentContainer.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }

    public class HttpController : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient());            
        }
    }
}