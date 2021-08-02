using ControlPanel.Services;
using Repository.GenericRepo;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ControlPanel
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<DropDownLists, DropDownLists>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}