﻿using Microsoft.AspNetCore.Mvc;
using SIGPA.Models;
using SIGPA.Services;

namespace SIGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodoControlController(IMetodoControlService metodoControlService) : ControllerBase
    {

        [HttpGet]
        
        public async Task<IActionResult> GetMetodosControl()
        {
            IEnumerable<MetodoControl> metodoControls = await metodoControlService.GetMetodosControl();
            return Ok(metodoControls);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMetodoControl(int id)
        {
            MetodoControl? metodoControl = await metodoControlService.GetMetodoControl(id);
            if (metodoControl == null)
            {
                return NotFound();
            }
            return Ok(metodoControl);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMetodoControl(
           string NombreMetodoControl,
           string DescripcionMetodoControl                                     
        )
        {
            var metodoControl= await metodoControlService.CreateMetodoControl(NombreMetodoControl, DescripcionMetodoControl);
            return CreatedAtAction(nameof(GetMetodoControl), new { id = metodoControl.IdMetodoControl }, metodoControl);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMetodoControl(
            int IdMetodoControl,
            string? NombreMetodoControl,
            string? DescripcionMetodoControl
         )
        {
            var metodoControl = await metodoControlService.UpdateMetodoControl(IdMetodoControl, NombreMetodoControl, DescripcionMetodoControl);
            return Ok(metodoControl);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMetodoControl(int id)
        {
            var deletedMetodoControl = await metodoControlService.DeleteMetodoControl(id);
            if (deletedMetodoControl == null) return NotFound();
            return Ok(deletedMetodoControl);
        }
    }
    
}