using Domain.Model.Models.Output;
using Web.Model;

namespace Web.Services
{
    public class FlattenTreeService
    {
        public List<TableRowWarehouse> FlattenTreeWarehouse(IEnumerable<WarehouseOutput> warehouses)
        {
            var result = new List<TableRowWarehouse>();
            if (warehouses is not null)
            {

                foreach (var warehouse in warehouses)
                {
                    // Если склад имеет платформы
                    if (warehouse.Platforms != null && warehouse.Platforms.Any())
                    {
                        foreach (var platform in warehouse.Platforms)
                        {
                            // Добавляем запись для платформы
                            result.Add(new TableRowWarehouse
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
                                    result.Add(new TableRowWarehouse
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
                        result.Add(new TableRowWarehouse
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
        public List<TableRowPlatform> FlattenTreePlatform(IEnumerable<PlatformOutput> Platforms)
        {

            var result = new List<TableRowPlatform>();
            
            // Имеются платформы платформы
            if (Platforms != null && Platforms.Any())
            {
                foreach (var platform in Platforms)
                {
                    // Добавляем запись для платформы
                    if(platform.IsMerge is true)
                    {
                        result.Add(new TableRowPlatform
                        {
                            PlatformNumber = platform.Number,
                            PlatformCargo = platform.Cargo,
                            Date = platform.Date
                        });
                    }
                }
            }

            return result;
        }
    }


}


