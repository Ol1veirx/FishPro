using AutoMapper;
using FishPro.Application.Services.DTO;
using FishPro.Application.Services.Interfaces;
using FishPro.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FishPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentController : Controller
    {
        private readonly ITournamentService _tournamentService;
        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var tournaments = await _tournamentService.GetAllAsync();

                return Ok(tournaments);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{tournamentId}")]
        public async Task<ActionResult> GetById(int tournamentId)
        {
            try
            {
                var tournament = await _tournamentService.GetByIdAsync(tournamentId);

                return Ok(tournament);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create(TournamentDTO tournamentDTO)
        {
            try
            {
                var newTournament = await _tournamentService.CreateAsync(tournamentDTO);

                return Ok(newTournament);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update/{tournamentId}")]
        public async Task<ActionResult> Update(int tournamentId, TournamentDTO tournamentDTO)
        {
            if(tournamentId != tournamentDTO.Id)
            {
                return NotFound();
            }

            try
            {
                var updateTournament = await _tournamentService.UpdateAsync(tournamentDTO);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{tournamentId}")]
        public async Task<ActionResult> Delete(int tournamentId)
        {
            try
            {
                var deleteTournament = await _tournamentService.DeleteAsync(tournamentId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
