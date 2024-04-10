using FishPro.Application.Services.DTO;
using FishPro.Application.Services.Interfaces;
using FishPro.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FishPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StageController : Controller
    {
        private readonly IStageServices _stageServices;
        public StageController(IStageServices stageServices)
        {
            _stageServices = stageServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var tournaments = await _stageServices.GetAllAsync();

                return Ok(tournaments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{stageId}")]
        public async Task<ActionResult> GetById(int stageId)
        {
            try
            {
                var tournament = await _stageServices.GetByIdAsync(stageId);

                return Ok(tournament);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(StageDTO stageDTO)
        {
            try
            {
                var newTournament = await _stageServices.CreateAsync(stageDTO);

                return Ok(newTournament);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update/{stageId}")]
        public async Task<ActionResult> Update(int stageId, StageDTO stageDTO)
        {
            if(stageId != stageDTO.Id)
            {
                return NotFound();
            }

            try
            {
                var updateStage = await _stageServices.UpdateAsync(stageDTO);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{stageId}")]
        public async Task<ActionResult> Delete(int stageId)
        {
            try
            {
                var deleteStage = await _stageServices.DeleteAsync(stageId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
