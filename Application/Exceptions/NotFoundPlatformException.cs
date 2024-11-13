using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
	public class NotFoundPlatformException: InvalidOperationException
	{
		public NotFoundPlatformException(int platformId) : base($"Площадка с Id: {platformId} не найдена!")
		{
		}
	}
}
