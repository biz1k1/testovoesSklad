namespace Domain.Model.Models.Input
{
    /// <summary>
    /// Класс входной модели для обновления площадки
    /// </summary>
    public record class UpdatePlatformInput
    {
        /// <summary>
        /// Id склада, у которого изменится площадка
        /// </summary>
        public int WarehouseId { get; set; }
        /// <summary>
        /// Id площадки
        /// </summary>
        public int PlatformId { get; set; }

        /// <summary>
        /// Груз на площадке (т)
        /// </summary>
        public double? Cargo { get; set; }



	}
}
