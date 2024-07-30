using Microsoft.AspNetCore.Mvc;
using Biblioteca.BL.Interfaces;
using Biblioteca.Entities.DTO;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {

        private readonly ILibroService service;

        public LibroController(ILibroService service)
        {
            this.service = service;
        }


        // GET: api/<AutorController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LibroDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<LibroDto> result = (IEnumerable<LibroDto>)await this.service.GetLibrosAsync();
            return (result != null && result.Any()) ? (IActionResult)this.Ok(result) : (IActionResult)this.NoContent();
        }

        // GET api/<AutorController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LibroDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get(int id)
        {
            LibroDto obj = (LibroDto)await this.service.GetLibroByIdAsync(id);
            return (obj != null) ? (IActionResult)this.Ok(obj) : (IActionResult)this.NoContent();
        }

        // POST api/<AutorController>
        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(LibroDto model)
        {
            if (model == null)
            {
                return (IActionResult)this.BadRequest();
            }
            int result = await this.service.InsertLibroAsync(model);
            Console.WriteLine(result);
            return (result >= 0) ? (IActionResult)this.CreatedAtAction("Post", result) : (IActionResult)this.BadRequest();
        }

        // PUT api/<AutorController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(LibroDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Put(int id, LibroDto model)
        {
            if (model == null)
            {
                return (IActionResult)this.BadRequest();
            }
            LibroDto result = await this.service.UpdateLibroAsync(model);
            return (result != null) ? (IActionResult)this.Ok(result) : (IActionResult)this.BadRequest();
        }

        // DELETE api/<AutorController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await this.service.DeleteLibroAsync(id);
            return (result) ? (IActionResult)this.Ok(result) : (IActionResult)this.BadRequest();
        }
    }
}
