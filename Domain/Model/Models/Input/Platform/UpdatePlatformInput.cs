namespace Domain.Model.Models.Input
{
    /// <summary>
    /// Класс входной модели для обновления площадки
    /// </summary>
    public record class UpdatePlatformInput
    {
        /// <summary>
        /// Id платформы, у которой обновится груз
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Груз на площадке (т)
        /// </summary>
        public double Cargo { get; set; }



	}
}
