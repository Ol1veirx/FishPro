using System.Runtime.CompilerServices;
using AutoMapper.Configuration.Annotations;
using FishPro.Application.Services.DTO;
using FishPro.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FishPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        private readonly ITeamServices _teamService;
        public TeamController(ITeamServices teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var teams = await _teamService.GetAllAsync();

                return Ok(teams);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{teamId}")]
        public async Task<ActionResult> GetById(int teamId)
        {
            try
            {
                var team = await _teamService.GetByIdAsync(teamId);

                if(team == null)
                {
                    return NotFound();
                }

                return Ok(team);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("newTeam")]
        public async Task<ActionResult> Create(TeamDTO teamDTO)
        {
            try
            {
                var newTeam = await _teamService.CreateAsync(teamDTO);

                return Ok(newTeam); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update/{teamId}")]
        public async Task<ActionResult> Update(int teamId, TeamDTO teamDTO)
        {
            if(teamId != teamDTO.Id)
            {
                return NotFound();
            }

            try
            {
                var updateTeam = await _teamService.UpdateAsync(teamDTO);

                return Ok(updateTeam);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{teamId}")]
        public async Task<ActionResult> Delete(int teamId)
        {
            try
            {
                var result = await _teamService.DeleteAsync(teamId);

                if(result == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
