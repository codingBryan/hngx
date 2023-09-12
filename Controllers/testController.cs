using backend_stage_one.Models;
using backend_stage_one.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend_stage_one.Controllers
{
    [Route("api/")]
    [ApiController]
    public class testController : ControllerBase
    {
        private readonly IJsonResponseService service;

        public testController(IJsonResponseService service)
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

        [HttpPost]
        public async Task<IActionResult> CreateUser(NewPersonDTO user)
        {
            var res = await service.CreateUser(user);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var res = await service.GetUserById(id);
            if(res.Id != 0)
            {
                return Ok(res);
            }
            return StatusCode(404, "User Not Found");
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var res = await service.DeleteUser(id);
            if (res.success == true)
            {
                return Ok(res);
            }
            return StatusCode(404, "User Not Found");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody]NewPersonDTO user)
        {
            
            var res = await service.UpdateUser(id,user);
            if (res.success == true)
            {
                return Ok(res);
            }
            return StatusCode(404, "User Not Found");
        }
    }
}
