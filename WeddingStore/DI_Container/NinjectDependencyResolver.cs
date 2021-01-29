using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using System.Web.Mvc;
using WeddingStore.Domain.Logic;
using WeddingStore.Domain.ConnectDb;
using System.Configuration;

namespace WeddingStore.DI_Container
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddDependency();
        }

        private void AddDependency()
        {
            kernel.Bind<IProduct>().To<RepositoryProduct>();

            Email email = new Email
            {
                File = bool.Parse(ConfigurationManager.AppSettings["Email.File"] ?? "false")
            };
            kernel.Bind<IProcessOrder>().To<OrderToEmail>().WithConstructorArgument("emailParam", email);
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}