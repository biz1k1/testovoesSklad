using Domain.Entity.Entitys;
using Domain.Model.Models.Output.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Models.Output.Warehouse
{
	/// <summary>
	/// Клас выходной модели для складов
	/// </summary>
	public record class WarehouseOutput
	{
		/// <summary>
		/// Номер склада
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Площадки в составе склада
		/// </summary>
		public ICollection<PlatformOutput> Platforms { get; set; } = [];
	}
}
