[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ArquiteturaDDD.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ArquiteturaDDD.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace ArquiteturaDDD.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Application.Interface;
    using Application;
    using Domain.Interfaces.Services;
    using Domain.Services;
    using Domain.Interfaces;
    using Infra.Data.Repositories;
    using Infra.Data.Context;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
           // DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
           // DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
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
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IClientAppService>().To<ClientAppService>();
            kernel.Bind<IProductAppService>().To<ProductAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(IServiceBase<>));
            kernel.Bind<IClientService>().To<ClientService>();
            kernel.Bind<IProductService>().To<ProductService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(ArquiteturaDDDContext<>));
            kernel.Bind<IClientRepository>().To<ClientRepository>();
            kernel.Bind<IProductRepository>().To<ProductRepository>();

        }        
    }
}
