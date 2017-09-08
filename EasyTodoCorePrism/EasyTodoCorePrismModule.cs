using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using EasyTodoCorePrism.Models;
using EasyTodoCorePrism.Views;

namespace EasyTodoCorePrism
{
	public class EasyTodoCorePrismModule : IModule
	{
		[Dependency]
		public IUnityContainer Container { get; set; }

		[Dependency]
		public IRegionManager RegionManager { get; set; }

		public void Initialize()
		{
			this.Container.RegisterType<ToDoList>(new ContainerControlledLifetimeManager());
			this.Container.RegisterType<object, ToDoListControlView>(nameof(ToDoListControlView));
			this.Container.RegisterType<object, ToDoDetailControlView>(nameof(ToDoDetailControlView));

			this.RegionManager.RequestNavigate("MainRegion", nameof(ToDoListControlView));
		}
	}
}