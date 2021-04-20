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
    [Route("actors")]
    public class ActorController : Controller
    {
        private readonly IActorService _actorService;
        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActors()
        {   
            var actors = await Task.Run(() => _actorService.GetAllActors());
            return actors != null ? Ok(actors) : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetActorById(int Id)
        {
            var actor = await Task.Run(()=>_actorService.GetActorById(Id));
            return actor!= null ? Ok(actor) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddActor([FromBody] ActorRequest actor)
        { 
             await Task.Run(()=> _actorService.AddActor(actor));
             return StatusCode(StatusCodes.Status201Created); 
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateActor(int Id, [FromBody]ActorRequest actor)
        {
            await Task.Run(()=>_actorService.UpdateActor(Id, actor));
            return Ok("Actor record with given Id updated Successfully");
            
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteActor(int Id) {
            await Task.Run(()=>_actorService.DeleteActor(Id));
            return Ok("Actor record with given Id removed Successfully");
        }

    }
}
