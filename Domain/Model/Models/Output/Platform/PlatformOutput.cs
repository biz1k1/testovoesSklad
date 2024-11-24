
namespace Domain.Model.Models.Output
{
	/// <summary>
	/// Класс выходной модели для площадок
	/// </summary>
	public record class PlatformOutput
	{
        public int Id { get; set; }
        /// <summary>
        /// Номер Площадки
        /// </summary>
        public int Number { get; set; }

		/// <summary>
		/// Груз на площадке(т)
		/// </summary>
		public double Cargo { get; set; }

        /// <summary>
        /// Айди склада, в котором находится площадка
        /// </summary>
        public int WareHouseId { get; set; }

        /// <summary>
        /// Дата создания площадки
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Объединенная площадка это или нет
        /// </summary>
        public bool IsMerge { get; set; }

        public IEnumerable<PicketOutput> Pickets { get; set; } = [];
	}
}
