using Microsoft.AspNetCore.Mvc;
using backend.Models; // Assuming you have a Pessoa model
using backend.Service;
using backend.Models.Pessoa;
using backend.ViewModels; // Assuming you have a PessoaService

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PessoaController"/> class.
        /// </summary>
        /// <param name="pessoaService">An instance of <see cref="IPessoaService"/> to handle business logic related to Pessoa.</param>
        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        // GET: api/Pessoa
        /// <summary>
        /// Retrieves a list of all Pessoa entities.
        /// </summary>
        /// <returns>An ActionResult containing an IEnumerable of PessoaViewModel objects.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<PessoaViewModel>> Get()
        {
            // Calls the GetAll method from the IPessoaService interface to retrieve all Pessoa entities.
            // Returns an Ok result with the retrieved Pessoa entities.
            return Ok(_pessoaService.GetAll());
        }
        /// <summary>
        /// Retrieves a Pessoa entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the Pessoa entity to retrieve.</param>
        /// <returns>
        /// An ActionResult containing the PessoaViewModel object with the specified id.
        /// If the Pessoa entity with the given id is not found, returns a NotFound result.
        /// Otherwise, returns an Ok result with the retrieved Pessoa entity.
        /// </returns>
        [HttpGet("{id}")]
        public ActionResult<PessoaViewModel> Get(Guid id)
        {
            var pessoa = _pessoaService.GetById(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return Ok(pessoa);
        }
        /// <summary>
        /// Adds a new Pessoa entity to the database.
        /// </summary>
        /// <param name="pessoa">The PessoaViewModel object containing the details of the new Pessoa entity to be added.</param>
        /// <returns>An ActionResult containing the newly created PessoaViewModel object. The HTTP status code for this response is 201 Created.</returns>
        [HttpPost]
        public ActionResult<PessoaViewModel> Post(PessoaViewModel pessoa)
        {
            _pessoaService.Add(pessoa);
            return CreatedAtAction(nameof(Get), new { id = pessoa.Id }, pessoa);
        }

        // PUT: api/Pessoa/5
        /// <summary>
        /// Updates an existing Pessoa entity in the database.
        /// </summary>
        /// <param name="id">The unique identifier of the Pessoa entity to update.</param>
        /// <param name="pessoa">The PessoaViewModel object containing the updated details of the Pessoa entity.</param>
        /// <returns>
        /// An IActionResult indicating the outcome of the operation.
        /// If the id in the request body does not match the id in the route, returns a BadRequest result.
        /// Otherwise, calls the Update method of the IPessoaService interface to update the Pessoa entity in the database,
        /// and returns a NoContent result with an HTTP status code of 204.
        /// </returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, PessoaViewModel pessoa)
        {
            if (id != pessoa.Id)
            {
                return BadRequest();
            }

            _pessoaService.Update(pessoa);
            return NoContent();
        }
    }
}