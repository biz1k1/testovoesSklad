namespace Domain.Entity.Entitys
{
    /// <summary>
    /// Класс сопоставляется с таблицей складов
    /// </summary>
    public class WareHouseEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// Номер склада
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Площадки в составе склада
        /// </summary>
        public ICollection<PlatformEntity> Platforms { get; set; }
    }
}
