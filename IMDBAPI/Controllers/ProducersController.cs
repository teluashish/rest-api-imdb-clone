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
    [Route("producers")]
    public class ProducerController : Controller
    {
        private readonly IProducerService _producerService;
        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducers()
        {
            var producers = await Task.Run(() => _producerService.GetAllProducers());
            return producers != null ? Ok(producers) : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProducerById(int Id)
        {
            var producer = await Task.Run(()=>_producerService.GetProducerById(Id));
            return producer != null ? Ok(producer) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddProducer([FromBody] ProducerRequest producer)
        {
            await Task.Run(() => _producerService.AddProducer(producer));
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateProducer(int Id, [FromBody] ProducerRequest producer)
        {
            await Task.Run(() => _producerService.UpdateProducer(Id, producer));
            return Ok("Producer record with given Id updated Successfully");

        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProducer(int Id)
        {
            await Task.Run(() => _producerService.DeleteProducer(Id));
            return Ok("Producer record with given Id removed Successfully");
        }

    }
}
