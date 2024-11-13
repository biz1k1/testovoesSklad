namespace Domain.Model.Models.Input
{
    /// <summary>
    /// Класс входной модели для обновления площадки
    /// </summary>
    public class UpdatePlatformInput
    {
        public int Id { get; set; }

        /// <summary>
        /// Груз на площадке (т)
        /// </summary>
        public double Cargo { get; set; }



	}
}
