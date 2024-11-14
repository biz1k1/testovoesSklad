using Domain.Entity.Entitys;
using Domain.Model.Models.Output.Picket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Models.Output.Platform
{
	/// <summary>
	/// Класс выходной модели для площадок
	/// </summary>
	public record class PlatformOutput
	{
		/// <summary>
		/// Номер Площадки
		/// </summary>
		public int Number { get; set; }

		/// <summary>
		/// Груз на площадке(т)
		/// </summary>
		public double Cargo { get; set; }
		public ICollection<PicketOutput> Pickets { get; set; } = [];
	}
}
