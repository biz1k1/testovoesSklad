namespace Web.Model
{
    public class MergePlatformModel
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
