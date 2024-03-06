using Microsoft.AspNetCore.Mvc;
using ProvaAdmissionalCSharpApisul;

namespace ProjApisul.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TurnoController : ControllerBase
    {
        private readonly IElevadorService _elevatorService;
        public TurnoController(IElevadorService elevadorService)
        {
            _elevatorService = elevadorService;
        }

        [HttpGet(Name = "PeriodoMaiorFluxoElevadorMaisFrequentado")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(IEnumerable<char>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PeriodoMaiorFluxoElevadorMaisFrequentado()
        {
            var resposta = _elevatorService.PeriodoMaiorFluxoElevadorMaisFrequentado();

            return Ok(resposta);
        }

        [HttpGet(Name = "PeriodoMaiorUtilizacaoConjuntoElevadores")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(IEnumerable<char>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PeriodoMaiorUtilizacaoConjuntoElevadores()
        {
            var resposta = _elevatorService.PeriodoMaiorUtilizacaoConjuntoElevadores();

            return Ok(resposta);
        }

        [HttpGet(Name = "PeriodoMenorFluxoElevadorMenosFrequentado")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(IEnumerable<char>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PeriodoMenorFluxoElevadorMenosFrequentado()
        {
            var resposta = _elevatorService.PeriodoMenorFluxoElevadorMenosFrequentado();

            return Ok(resposta);
        }
    }
}
