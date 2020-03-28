using Modularity.Infrastructure;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modularity.AlternateViewA
{
	public sealed class Module : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			var regionManager = containerProvider.Resolve<IRegionManager>();
			regionManager.RegisterViewWithRegion(Regions.AlternateA, typeof(Views.AlternateView));
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
		}
	}
}
