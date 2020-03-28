using Modularity.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modularity.Services
{
	public sealed class FirstStringService : IStringService
	{
		private int _count = 0;

		public string GetNewString()
		{
			_count++;
			return $"FirstStringServiceImplementation {_count}";
		}
	}
}
