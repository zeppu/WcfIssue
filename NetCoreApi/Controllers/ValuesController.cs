using Microsoft.AspNetCore.Mvc;

namespace NetCoreApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		private readonly IService _service;

		public ValuesController(IService service)
		{
			_service = service;
		}

		[HttpGet]
		public IActionResult Get()
		{
			_service.GetNothing("empty");
			return Ok();
		}

		[HttpGet("{value}")]
		public ActionResult<string> Get(string value)
		{
			return _service.GetData(value);
		}
	}
}
