using backend_stage_one.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_stage_one.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        private readonly IJsonResponseService service;

        public testController(IJsonResponseService service  )
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            string slack_name = HttpContext.Request.Query["slack_name"];
            string track = HttpContext.Request.Query["track"];

            var res = service.GetResponseAsync(slack_name, track);
            return Ok(res);
        }
    }
}
