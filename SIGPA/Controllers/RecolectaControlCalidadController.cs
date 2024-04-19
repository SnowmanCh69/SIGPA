﻿
using Microsoft.AspNetCore.Mvc;
using SIGPA.Models;
using SIGPA.Services;


namespace SIGPA.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class RecolectaControlCalidadController (IRecolectaControlCalidadService recolectaControlCalidadService) : ControllerBase
    {


        [HttpGet]
        public async Task <IActionResult> GetRecolectaControlesCalidad()
        {
            IEnumerable<RecolectaControlCalidad> recolectaControlCalidad = await recolectaControlCalidadService.GetRecolectasControlesCalidad();
            return Ok(recolectaControlCalidad);
        }

        [HttpGet("{id:int}")]
        public async Task <IActionResult> GetRecolectaControlCalidad(int id)
        {
            RecolectaControlCalidad? recolectaControlCalidad = await recolectaControlCalidadService.GetRecolectaControlCalidad(id);
            if (recolectaControlCalidad == null) return NotFound();
            return Ok(recolectaControlCalidad);
        }

        [HttpPost]
        public async Task <IActionResult> CreateRecolectaControlCalidad(
           int IdControlCalidad,
           int IdResultado,
           string Observaciones
         )
        {
           var recolectaControlCalidad = await recolectaControlCalidadService.CreateRecolectaControlCalidad(IdControlCalidad, IdResultado, Observaciones);
            return Ok(recolectaControlCalidad);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRecolectaControlCalidad(
           int IdRecolectaControlCalidad,
           int? IdControlCalidad,
           int? IdResultado,
            string? Observaciones
                    )
        {
            var recolectaControlCalidad = await recolectaControlCalidadService.UpdateRecolectaControlCalidad(IdRecolectaControlCalidad, IdControlCalidad, IdResultado, Observaciones);
            return Ok(recolectaControlCalidad);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRecolectaControlCalidad(int id)
        {
            RecolectaControlCalidad? recolectaControlCalidad = await recolectaControlCalidadService.DeleteRecolectaControlCalidad(id);
            if (recolectaControlCalidad == null) return NotFound();
            return Ok(recolectaControlCalidad);
        }
    }
}