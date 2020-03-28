using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modularity.Infrastructure
{
	public sealed class Module : IModule
	{
		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			// this is called first when module is loaded
		}

		public void OnInitialized(IContainerProvider containerProvider)
		{
			// this is called next when loaded
		}
	}
}
