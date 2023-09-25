using BL.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesShowWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindShowController : Controller
    {
        private readonly IIMDBApiService _iMDBApiService;
        public FindShowController(IIMDBApiService iMDBApiService)
        {
            _iMDBApiService = iMDBApiService;
        }

        // GET api/<FindShowController>/5
        [HttpGet("{searchKey}")]
        public async Task<IActionResult> Get([FromRoute]string searchKey)
        {
            try
            {
                if(string.IsNullOrEmpty(searchKey)) return Ok(null);

                var results = await _iMDBApiService.GetShowsAsync(searchKey);

                return Json(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
