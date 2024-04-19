using Microsoft.AspNetCore.Mvc;
using SIGPA.Models;
using SIGPA.Services;


namespace SIGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ResultadoController(IResultadoService resultadoService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetResultados()
        {
            IEnumerable<Resultado> resultados = await resultadoService.GetResultados();
            return Ok(resultados);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetResultado(int id)
        {
            Resultado? resultado = await resultadoService.GetResultado(id);
            if (resultado == null)
            {
                return NotFound();
            }
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> CreateResultado(
          string NombreResultado
         )
        {
            var resultado= await resultadoService.CreateResultado(NombreResultado);
            return CreatedAtAction(nameof(GetResultado), new { id = resultado.IdResultado }, resultado);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateResultado(
           int IdResultado,
           string? NombreResultado
         )
        {
            var resultado = await resultadoService.UpdateResultado(IdResultado, NombreResultado);
            return Ok(resultado);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteResultado(int id)
        {
            var deletedResultado = await resultadoService.DeleteResultado(id);
            if (deletedResultado == null) return NotFound();
            return Ok(deletedResultado);
        }
    }
}
