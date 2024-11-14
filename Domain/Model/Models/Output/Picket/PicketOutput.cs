using Domain.Entity.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Models.Output.Picket
{
	/// <summary>
	/// Класс выходной модели для пикетов
	/// </summary>
	public record class PicketOutput
	{
		/// <summary>
		/// Номер пикета
		/// </summary>
		public int Number { get; set; }
	}
}
