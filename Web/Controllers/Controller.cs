using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OrderController : ControllerBase
	{

		[HttpGet]
		public async Task<ActionResult> GetAllOrders()
		{
			return Ok();
		}
	}
}
