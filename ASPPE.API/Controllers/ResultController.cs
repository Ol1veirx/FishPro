using FishPro.Application.Services.DTO;
using FishPro.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FishPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultController : Controller
    {
        private readonly IResultServices _resultServices;
        public ResultController(IResultServices resultServices)
        {
            _resultServices = resultServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var results = await _resultServices.GetAllAsync();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("result/{resultId}")]
        public async Task<ActionResult> GetById(int resultId)
        {
            try
            {
                var result = await _resultServices.GetByIdAsync(resultId);

                if(result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("newresult")]
        public async Task<ActionResult> Create(ResultDTO resultDTO)
        {
            try
            {
                var newResult = await _resultServices.CreateAsync(resultDTO);

                return Ok(newResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("updateresult/{resultId}")]
        public async Task<ActionResult> Update(int resultId, ResultDTO resultDTO)
        {
            if(resultId != resultDTO.Id)
            {
                return NotFound();
            }

            try
            {
                var updateResult = await _resultServices.UpdateAsync(resultDTO);

                return Ok(updateResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deleteresult/{resultId}")]
        public async Task<ActionResult> Delete(int resultId)
        {
            try
            {
                var delelteResult = await _resultServices.DeleteAsync(resultId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
