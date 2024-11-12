using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.Entitys
{
    /// <summary>
    /// Класс сопоставляется с таблицей пикетов
    /// </summary>
    public class PicketEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// Номер пикета
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Площадка, на которой находится пикет
        /// </summary>
        public ICollection<PlatformEntity> Platforms { get; set; }
    }
}
