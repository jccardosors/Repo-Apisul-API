using Microsoft.AspNetCore.Mvc;
using ProvaAdmissionalCSharpApisul;

namespace ProjApisul.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AndarController : ControllerBase
    {
        private readonly IElevadorService _elevatorService;
        public AndarController(IElevadorService elevadorService)
        {
            _elevatorService = elevadorService;
        }

        [HttpGet(Name = "AndarMenosUtilizado")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(IEnumerable<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AndarMenosUtilizado()
        {
            var resposta = _elevatorService.AndarMenosUtilizado();

            return Ok(resposta);
        }
    }
}
