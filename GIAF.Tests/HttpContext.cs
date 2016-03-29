using Castle.Windsor;
using GIAF.Tests.Init;

namespace GIAF.Tests
{
    public class HttpContext
    {
        private static IWindsorContainer Current { get; set; }

        public static IWindsorContainer CurrentContainer()
        {
            var bs = new TestBootstrapper();
            bs.Intialize();

            Current = bs.container;

            return Current;
        }
    }
}
