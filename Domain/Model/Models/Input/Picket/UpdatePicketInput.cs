using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Models.Input.Picket
{
	/// <summary>
	/// Входная модель для обновления пикетов
	/// </summary>
	public class UpdatePicketInput
	{
		/// <summary>
		/// Id площадки, к которой будут перенесены пикеты
		/// </summary>
		public int PlatformId { get; set; }

		/// <summary>
		/// Пикет, который обновятся
		/// </summary>
		public int PicketId { get; set; }
	}
}
