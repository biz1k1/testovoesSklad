

namespace Domain.Model.Models.Output
{
	/// <summary>
	/// Класс выходной модели для пикетов
	/// </summary>
	public record class PicketOutput
	{
        public int Id { get; set; }
        /// <summary>
        /// Номер пикета
        /// </summary>
        public int Number { get; set; }
	}
}
