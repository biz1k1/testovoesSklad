using Domain.Model.Models.Input.Platform;
using Domain.Model.Models.Input.Picket;
using Domain.Model.Models.Input;

namespace WebApp.Model
{
    public class UpdateWarehouseModel
    {
        public UpdatePlatformInput updatePlatformInput { get; set; }
        public UpdatePicketInput updatePicketInput { get; set; }
    }
}
