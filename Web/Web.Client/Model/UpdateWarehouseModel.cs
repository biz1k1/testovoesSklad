using Domain.Model.Models.Input.Picket;
using Domain.Model.Models.Input;

namespace Web.Model
{
    public class UpdateWarehouseModel
    {
        public UpdatePlatformInput updatePlatformInput { get; set; }
        public UpdatePicketInput updatePicketInput { get; set; }
    }
}
