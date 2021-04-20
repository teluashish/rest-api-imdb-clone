using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBAPI.Models.Request;
using IMDBAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMDBAPI.Controllers
{
    [ApiController]
    [Route("genres")]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await Task.Run(() => _genreService.GetAllGenres());
            return genres != null ? Ok(genres) : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetGenreById(int Id)
        {
            var genre = await Task.Run(()=>_genreService.GetGenreById(Id));
            return genre != null ? Ok(genre) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddGenre([FromBody] GenreRequest genre)
        {
            await Task.Run(() => _genreService.AddGenre(genre));
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateGenre(int Id, [FromBody] GenreRequest genre)
        {
            await Task.Run(() => _genreService.UpdateGenre(Id, genre));
            return Ok("Genre record with given Id updated Successfully");

        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteGenre(int Id)
        {
            await Task.Run(() => _genreService.DeleteGenre(Id));
            return Ok("Genre record with given Id removed Successfully");
        }

    }
}
