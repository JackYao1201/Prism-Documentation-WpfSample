using Modularity.Infrastructure.Services;
using Modularity.Infrastructure.ViewModels;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modularity.AlternateViewA.ViewModels
{
	public sealed class AlternateViewModel : BaseViewModel
	{
		private ILooseStringService _looseStringService = null;


		public AlternateViewModel(IEventAggregator eventAggregator, ILooseStringService looseStringService)
			: base(eventAggregator)
		{
			// be careful with initializing in constructor
			// bad, virtual method in property setter:
			// TextValue = "Initial Value";
			// good:
			_textValue = "Initial Value";

			_looseStringService = looseStringService;
		}



		private string _textValue = null;
		public string TextValue
		{
			get => _textValue;
			set => SetProperty<string>(ref _textValue, value);
		}


		private DelegateCommand _commandUpdate = null;
		public DelegateCommand CommandUpdate =>
			_commandUpdate ?? (_commandUpdate = new DelegateCommand(CommandUpdateExecute));

		private void CommandUpdateExecute()
		{
			string s = _looseStringService.GetNextStringValue();
			TextValue = s;
			UpdateStatusBarMessage($"Loosely coupled at {DateTime.Now.ToLongTimeString()}");
		}
	}
}
