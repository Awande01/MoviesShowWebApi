using BL.DTO;
using BL.Interface;
using DAL.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesShowWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : Controller
    {
        private readonly IShowService _showService;
        public ShowController(IShowService showService)
        {
            _showService = showService;
        }

        // GET api/<ShowController>/
        [HttpGet("{profileId}/List")]
        public async Task<IActionResult> GetShows([FromRoute] int profileId)
        {
            try
            {
                var result = await _showService.GetShowByProfileId(profileId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ShowController>/5
        [HttpGet("{imdbId}")]
        public async Task<IActionResult> GetShow([FromRoute]string imdbId)
        {
            try
            {
              var result =  await _showService.GetShowByImdbId(imdbId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ShowController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShowInformationDTO showInformationDTO)
        {
            try
            {
                if (showInformationDTO == null) return BadRequest();
                await _showService.SaveShow(showInformationDTO);
                return Ok("Show saved successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ShowController>
        [HttpPut]
        public async Task<IActionResult> Put([FromQuery] int showId, [FromQuery] bool isWatched)
        {
            try
            {
                var result = await _showService.UpdateShow(showId, isWatched);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ShowController>/
        [HttpDelete("{showId}")]
        public async Task<IActionResult> Delete([FromRoute]int showId)
        {
            try
            {
                var result = await _showService.DeleteShow(showId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
    }
}
