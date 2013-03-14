using System;
using System.Configuration;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using webTemplate.Global.Auth;
using webTemplate.Global.Config;
using webTemplate.Mappers;
using webTemplate.Model;
using webTemplate.Tools.Mail;


[assembly: WebActivator.PreApplicationStartMethod(typeof(webTemplate.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(webTemplate.App_Start.NinjectWebCommon), "Stop")]
namespace webTemplate.App_Start
{
   
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IMapper>().To<CommonMapper>();
            kernel.Bind<IConfig>().To<Config>();
            kernel.Bind<IMailSender>().To<MailSender>();
            kernel.Bind<webTemplateDbDataContext>().ToMethod(c => new webTemplateDbDataContext(kernel.Get<IConfig>().ConnectionStrings("ConnectionString")));
            kernel.Bind<IRepository>().To<SqlRepository>().InRequestScope();
            kernel.Bind<IAuthentication>().To<CustomAuthentication>().InRequestScope();
        }        
    }
}
