namespace Domain.Model.Models.Input.Platform
{
	/// <summary>
	/// Входная модель для добавления площадки
	/// </summary>
	public class AddPlatformInput
	{
		/// <summary>
		/// Id склада, в который добавится площадка
		/// </summary>
		public int WarehouseId { get; set; }
		
		/// <summary>
		/// Груз на площадке (т)
		/// </summary>
		public double Cargo { get; set; }


	}
}
