using BL.DTO;
using BL.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesShowWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }


        // GET: api/<ProfileController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string username,[FromQuery] string password)
        {
            var result = await _profileService.GetUserProfile(username, password);
            if (result == null) return NotFound();

            return Ok(result);
        }

        // POST api/<ProfileController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
