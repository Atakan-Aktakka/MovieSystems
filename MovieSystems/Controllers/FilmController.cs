using Microsoft.AspNetCore.Mvc;
using MovieSystems.Dtos.Requests;
using MovieSystems.Services.Concrete;

namespace MovieSystems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly FilmService _filmService;
        public FilmController(FilmService filmService)
        {
            _filmService = filmService;
        }
        [HttpPost("add")]
        public IActionResult Add([FromBody] CreateFilmRequestDto requestDto)
        {
            var response = _filmService.Add(requestDto);
            if(response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return Created("/", response);
            }
            return BadRequest(response);
        }
        [HttpPut("update")]
        public IActionResult Update([FromQuery] UpdateFilmRequestDto requestDto)
        {
            var response = _filmService.Update(requestDto);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(response);
            }

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound(response);
            }

            return BadRequest(response);
        }
        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] int id)
        {
            var response = _filmService.Delete(id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(response);
            }

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound(response);
            }

            return BadRequest(response);

        }
        [HttpGet("getbyid")]
        public IActionResult GetById([FromQuery] int id)
        {
            var response = _filmService.GetById(id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(response);
            }

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound(response);
            }

            return BadRequest(response);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var response = _filmService.GetList();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
