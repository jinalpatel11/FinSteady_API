using FinSteady_API.Infrastructure;
using FinSteady_API.Models;
using FinSteady_API.Models.Request;
using FinSteady_API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FinSteady_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavingGoalController : ControllerBase
    {
        private readonly ISavingGoalRepository _savingGoalRepository;
        protected APIResponse _response;

        public SavingGoalController(ISavingGoalRepository savingGoalRepository)
        {
            _savingGoalRepository = savingGoalRepository;
            _response = new();
        }

        [HttpGet("{id:int}", Name = "GetSavingGoal")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetSavingGoal(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var savingGoal = await _savingGoalRepository.GetSavingGoalById(id);
                if (savingGoal == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = savingGoal;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetSavingGoals()
        {
            try
            {
                IEnumerable<SavingGoal> savingGoalList = await _savingGoalRepository.GetSavingGoals();
                _response.Result = savingGoalList;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteSavingGoal")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteSavingGoal(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var savingGoal = await _savingGoalRepository.GetSavingGoalById(id);
                if (savingGoal == null)
                {
                    return NotFound();
                }
                await _savingGoalRepository.DeleteSavingGoal(savingGoal);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("{id:int}", Name = "UpdateSavingGoal")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateSavingGoal(int id, [FromBody] SavingGoalRequestModel updateDTO)
        {
            try
            {
                if (updateDTO == null)
                {
                    return BadRequest();
                }
                SavingGoal dbSavingGoal = await _savingGoalRepository.GetSavingGoalById(id);
                SavingGoal model = updateDTO.ToEntity();

                await _savingGoalRepository.UpdateSavingGoal(dbSavingGoal, model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

        [HttpPost("createSavingGoal")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateSavingGoal([FromBody] SavingGoalRequestModel createDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                SavingGoal savingGoal = createDTO.ToEntity();

                savingGoal = await _savingGoalRepository.AddSavingGoal(savingGoal);
                _response.Result = savingGoal;
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetSavingGoal", new { id = savingGoal.GoalId }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
    }
}
