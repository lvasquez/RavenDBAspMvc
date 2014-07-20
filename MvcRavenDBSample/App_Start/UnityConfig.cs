using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using MvcRavenDBSample.Data.Repository;
using MvcRavenDBSample.Data.Service;

namespace MvcRavenDBSample
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ICustomerService, CustomerServices>(new InjectionConstructor("http://localhost:8080/"));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}