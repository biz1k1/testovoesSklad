using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
	public class ServiceException:InvalidOperationException
	{
		public ServiceException(string messageError) : base($"Произошла непредвиденная ошибка {messageError}.")
		{
		}
	}
}
