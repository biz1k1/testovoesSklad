namespace Web.Model
{
    public class UpdateWarehouseModel
    {
        public int WarehouseId { get; set; }
        public int PlatformID { get; set; }
        public double? Cargo { get; set; }
        public int? PicketId { get; set; }
    }
}
