using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modularity.Infrastructure.ViewModels
{
	public abstract class BaseViewModel : BindableBase
	{
		// put your common app specific view model logic in here
		// in this case, I use the EventAggregator in most of my components
		// and want to update the status message from various components
		protected IEventAggregator EventAggregator { get; private set; }


		public BaseViewModel(IEventAggregator eventAggregator)
		{
			EventAggregator = eventAggregator;
		}

		private Messages.StatusBarMessage _statusBarMessage = null;
		protected void UpdateStatusBarMessage(string message)
		{
			if (_statusBarMessage == null)
				_statusBarMessage = EventAggregator.GetEvent<Messages.StatusBarMessage>();
			_statusBarMessage.Publish(message);
		}
	}
}
