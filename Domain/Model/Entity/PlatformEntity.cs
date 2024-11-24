namespace Domain.Entity.Entitys
{
    /// <summary>
    /// Класс сопоставляется с таблицей площадок
    /// </summary>
    public class PlatformEntity
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
        /// Склад, на которой находится платформа
        /// </summary>
        public WareHouseEntity WareHouse { get; set; } 

        public ICollection<PicketEntity> Pickets { get; set; } = [];

        /// <summary>
        /// Дата объединения пикетов в площадку
        /// </summary>
        public string? Date { get; set; }

        /// <summary>
        /// Объединенная площадка это или нет
        /// </summary>
        public bool IsMerge { get; set; }
    }
}
