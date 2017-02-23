[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PlusOne.WebForms.App_Start.NinjectWeb), "Start")]

namespace PlusOne.WebForms.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject.Web;

    public static class NinjectWeb 
    {
        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
        }
    }
}
