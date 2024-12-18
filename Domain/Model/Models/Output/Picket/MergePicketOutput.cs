﻿namespace Domain.Model.Models.Output.Picket
{
    /// <summary>
    /// Входная модель для объединения пикетов в площадки
    /// </summary>
    public class MergePicketOutput
    {
        /// <summary>
        /// Id склада
        /// </summary>
        public int WarehouseId { get; set; }
        /// <summary>
        /// Id пикетов
        /// </summary>
        public IEnumerable<int> picketIds { get; set; }
    }
}
