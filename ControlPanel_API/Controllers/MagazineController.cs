using Microsoft.AspNetCore.Mvc;
using ControlPanel_API.DTOs;
using ControlPanel_API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlPanel_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagazineController : ControllerBase
    {
        private readonly IMagazineService _magazineService;

        public MagazineController(IMagazineService magazineService)
        {
            _magazineService = magazineService;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewMagazine([FromForm] MagazineDTO magazineDTO)
        {
            try
            {
                await _magazineService.AddNewMagazine(magazineDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMagazine([FromForm] UpdateMagazineDTO magazineDTO)
        {
            try
            {
                await _magazineService.UpdateMagazine(magazineDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMagazines()
        {
            try
            {
                var magazines = await _magazineService.GetAllMagazines();
                return Ok(magazines);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMagazineById(int id)
        {
            try
            {
                var magazine = await _magazineService.GetMagazineById(id);
                return Ok(magazine);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMagazine(int id)
        {
            try
            {
                await _magazineService.DeleteMagazine(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("UpdateFile")]
        public async Task<IActionResult> UpdateMagazineFile([FromForm] MagazineDTO magazineDTO)
        {
            if (magazineDTO.File == null)
            {
                return BadRequest("The File field is required");
            }

            try
            {
                await _magazineService.UpdateMagazineFile(magazineDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetFile/{id}")]
        public async Task<IActionResult> GetMagazineFileById(int id)
        {
            try
            {
                var file = await _magazineService.GetMagazineFileById(id);
                return File(file, "application/pdf");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
