using Modularity.Infrastructure.Services;
using Modularity.Infrastructure.ViewModels;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modularity.ViewModels
{
	public sealed class MainWindowViewModel : BaseViewModel
	{
		private IStringService _stringService = null;


		public MainWindowViewModel(IEventAggregator eventAggregator, IStringService stringService)
			: base(eventAggregator)
		{
			_stringService = stringService;

			// if you initialize in your constructor
			// don't call the property: it calls a virtual method
			// use the field instead
			_sampleStringProperty = "my sample string value";
			_statusMessage = "ready";


			InitializeEventAggregatorHandling();
		}


		private void InitializeEventAggregatorHandling()
		{
			var statusBarEvent = EventAggregator.GetEvent<Infrastructure.Messages.StatusBarMessage>();
			// get the token for later unsubscription and we can just use a lambda to update our property
			SubscriptionToken statusBarToken = statusBarEvent.Subscribe((string message) => StatusMessage = message);
		}


		private string _sampleStringProperty = null;
		public string SampleStringProperty
		{
			get => _sampleStringProperty;
			set => SetProperty<string>(ref _sampleStringProperty, value);
		}


		private string _statusMessage = null;
		public string StatusMessage
		{
			get => _statusMessage;
			set => SetProperty<string>(ref _statusMessage, value);
		}


		private DelegateCommand _commandUpdateSample = null;
		public DelegateCommand CommandUpdateSample =>
			_commandUpdateSample ?? (_commandUpdateSample = new DelegateCommand(CommandUpdateSampleExecute));

		private void CommandUpdateSampleExecute()
		{
			var s = _stringService.GetNewString();
			SampleStringProperty = s;

			UpdateStatusBarMessage($"Updated on {DateTime.Now.ToLongTimeString()}");
		}
	}
}
