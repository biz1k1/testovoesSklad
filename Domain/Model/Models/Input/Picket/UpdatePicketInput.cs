
namespace Domain.Model.Models.Input
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
