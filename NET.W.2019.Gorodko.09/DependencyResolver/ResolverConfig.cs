using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Fake.Repositories;
using DAL.Interface.Interfaces;
using Ninject;

namespace DependencyResolver
{
    /// <summary>
    /// Contains method for resolving dependences.
    /// </summary>
    public static class ResolverConfig
    {
        /// <summary>
        /// Configurates di container.
        /// </summary>
        /// <param name="kernel">Kernel.</param>
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IRepository>().To<FakeRepository>();
        }
    }
}
