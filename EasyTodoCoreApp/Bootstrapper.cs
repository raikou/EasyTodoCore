using System.Linq;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;
using EasyTodoCoreApp.Views;

namespace EasyTodoCoreApp
{
	class Bootstrapper : UnityBootstrapper
	{
		protected override DependencyObject CreateShell()
		{
			return this.Container.Resolve<Shell>();
		}

		protected override void InitializeShell()
		{
			((Window)this.Shell).Show();
		}

		protected override void ConfigureModuleCatalog()
		{
			base.ConfigureModuleCatalog();

			var catalog = (ModuleCatalog)this.ModuleCatalog;
			catalog.AddModule(typeof(EasyTodoCorePrism.EasyTodoCorePrismModule));

		}

	}
}
