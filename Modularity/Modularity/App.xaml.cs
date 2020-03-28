using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Modularity
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : PrismApplication
	{
		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.Register<Infrastructure.Services.IStringService, Services.FirstStringService>();
		}

		protected override Window CreateShell()
		{
			var w = Container.Resolve<Views.MainWindow>();
			return w;
		}


		protected override IModuleCatalog CreateModuleCatalog()
		{
			ConfigurationModuleCatalog catalog = new ConfigurationModuleCatalog();
			return catalog;
		}

		protected override void InitializeModules()
		{
			base.InitializeModules();
		}
	}
}
