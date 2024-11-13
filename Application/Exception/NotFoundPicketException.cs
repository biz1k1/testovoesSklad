using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exception
{
	public class NotFoundPicketException:InvalidOperationException
	{
		public NotFoundPicketException(int picketId) : base($"Пикет с Id: {picketId} не найден!")
		{
		}
	}
}
