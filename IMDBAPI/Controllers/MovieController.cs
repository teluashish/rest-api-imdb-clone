using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBAPI.Models.Request;
using IMDBAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Firebase.Storage;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMDBAPI.Controllers
{
    [ApiController]
    [Route("movies")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await Task.Run(() => _movieService.GetAllMovies());
            return movies != null ? Ok(movies) : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetMovieById(int Id)
        {
            var movie = await Task.Run(()=> _movieService.GetMovieById(Id));
            return movie != null ? Ok(movie) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] MovieRequest movie)
        {
            await Task.Run(() => _movieService.AddMovie(movie));
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateMovie(int Id, [FromBody] MovieRequest movie)
        {
            await Task.Run(() => _movieService.UpdateMovie(Id, movie));
            return Ok("Movie record with given Id updated Successfully");

        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteMovie(int Id)
        {
            await Task.Run(() => _movieService.DeleteMovie(Id));
            return Ok("Movie record with given Id removed Successfully");
        }


        //[HttpPost("upload")]
        //public async Task<IActionResult> UploadFile(IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //        return Content("file not selected");
        //    var task = await new FirebaseStorage("YOUR_ACCOUNT_KEY")
        //            .Child("DIRECTORY_IF_ANY")
        //            .Child(Guid.NewGuid().ToString() + ".jpg")
        //            .PutAsync(file.OpenReadStream());
        //    return Ok(task);
        //}



    }
}
