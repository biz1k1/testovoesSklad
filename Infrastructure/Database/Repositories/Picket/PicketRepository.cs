using Infrastructure.Database.Abstractions.Picket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repositories.Picket
{
	internal sealed class PicketRepository : IPicketRepository
	{
		#region Публичные методы
		public Task AddPicketAsync(int warehouseId)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
