using Microsoft.AspNetCore.Mvc;
using ProvaAdmissionalCSharpApisul;

namespace ProjApisul.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ElevadorController : ControllerBase
    {
        private readonly IElevadorService _elevatorService;
        public ElevadorController(IElevadorService elevadorService)
        {
            _elevatorService = elevadorService;
        }               

        [HttpGet(Name = "ElevadorMaisFrequentado")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(IEnumerable<char>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ElevadorMaisFrequentado()
        {
            var resposta = _elevatorService.ElevadorMaisFrequentado();

            return Ok(resposta);
        }

        [HttpGet(Name = "ElevadorMenosFrequentado")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(IEnumerable<char>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ElevadorMenosFrequentado()
        {
            var resposta = _elevatorService.ElevadorMenosFrequentado();

            return Ok(resposta);
        }

        [HttpGet(Name = "PercentualDeUsoElevadorA")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(float), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PercentualDeUsoElevadorA()
        {
            var resposta = _elevatorService.PercentualDeUsoElevadorA();

            return Ok(resposta);
        }

        [HttpGet(Name = "PercentualDeUsoElevadorB")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(float), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PercentualDeUsoElevadorB()
        {
            var resposta = _elevatorService.PercentualDeUsoElevadorB();

            return Ok(resposta);
        }

        [HttpGet(Name = "PercentualDeUsoElevadorC")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(float), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PercentualDeUsoElevadorC()
        {
            var resposta = _elevatorService.PercentualDeUsoElevadorC();

            return Ok(resposta);
        }

        [HttpGet(Name = "PercentualDeUsoElevadorD")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(float), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PercentualDeUsoElevadorD()
        {
            var resposta = _elevatorService.PercentualDeUsoElevadorD();

            return Ok(resposta);
        }

        [HttpGet(Name = "PercentualDeUsoElevadorE")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(float), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PercentualDeUsoElevadorE()
        {
            var resposta = _elevatorService.PercentualDeUsoElevadorE();

            return Ok(resposta);
        }       
    }
}
