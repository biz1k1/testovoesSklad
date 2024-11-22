using Domain.Model.Models.Output;
using Web.Model;

namespace Web.Services
{
    public class FlattenTreeService
    {
        public List<TableRow> FlattenTree(IEnumerable<WarehouseOutput> warehouses)
        {
            var result = new List<TableRow>();
            if(warehouses is not null)
            {

            foreach (var warehouse in warehouses)
            {
                // Если склад имеет платформы
                if (warehouse.Platforms != null && warehouse.Platforms.Any())
                {
                    foreach (var platform in warehouse.Platforms)
                    {
                        // Добавляем запись для платформы
                        result.Add(new TableRow
                        {
                            WarehouseName = warehouse.Name,
                            PlatformNumber = platform.Number,
                            PlatformCargo = platform.Cargo,
                            PicketNumber = null
                        });

                        // Если на платформе есть пикеты
                        if (platform.Pickets != null && platform.Pickets.Any())
                        {
                            foreach (var picket in platform.Pickets)
                            {
                                result.Add(new TableRow
                                {
                                    WarehouseName = warehouse.Name,
                                    PlatformNumber = platform.Number,
                                    PlatformCargo = null, // Пикет не имеет груза
                                    PicketNumber = picket.Number
                                });
                            }
                        }
                    }
                }
                else
                {
                    // Если у склада нет платформ, добавляем только склад без платформ и пикетов
                    result.Add(new TableRow
                    {
                        WarehouseName = warehouse.Name,
                        PlatformNumber = null,
                        PlatformCargo = null,
                        PicketNumber = null
                    });
                }
            }
            }

            return result;
        }
    }
}
