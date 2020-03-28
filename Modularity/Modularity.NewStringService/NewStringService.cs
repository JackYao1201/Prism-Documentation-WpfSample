using Modularity.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modularity.NewStringService
{
	public sealed class NewStringService : ILooseStringService
	{
		public string GetNextStringValue()
		{
			return $"NEW LOOSELY COUPLED SERVICE: {DateTime.Now.ToLongTimeString()}";
		}
	}
}
