using Infrastructure.Database.Abstractions.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repositories.Platform
{
	internal sealed class PlatformRepository : IPlatformRepository
	{
		#region Публичные методы
		public Task AddPlatformRepository(int picketId)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
