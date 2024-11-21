

namespace Domain.Model.Models.Output
{
	/// <summary>
	/// Клас выходной модели для складов
	/// </summary>
	public record class WarehouseOutput
	{
		public int Id { get; set; }
		/// <summary>
		/// Номер склада
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Площадки в составе склада
		/// </summary>
		public IEnumerable<PlatformOutput> Platforms { get; set; } = [];
	}
}
