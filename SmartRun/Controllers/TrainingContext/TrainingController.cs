using Microsoft.AspNetCore.Mvc;
using SmartRun.Application.Services.TrainingContext.DataTransferObject;
using SmartRun.Application.Services.TrainingContext.Interfaces;
using SmartRun.Domain.BoundedContexts.TrainingContext.Entities;

namespace SmartRun.WebApi.Controllers.TrainingContext;

[Route("api/v1/training")]
[ApiController]
public sealed class TrainingController : ControllerBase
{
    private readonly ITrainingService _trainingService;

    public TrainingController(ITrainingService trainingService)
    {
        _trainingService = trainingService;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateTrainingAsync(
        [FromBody] CreateTrainingDTO createTrainingDto)
    {
        //var accountIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        //if (accountIdClaim is null)
        //    return Unauthorized("User ID not found in token.");

        //var accountId = new Guid(accountIdClaim.Value);

        var accountId = Guid.NewGuid();

        var training = await _trainingService.CreateTrainingServiceAsync(
            accountId: accountId,
            createTrainingDto: createTrainingDto);
        if (training is null)
            return BadRequest("Failed to create training.");

        return CreatedAtAction(nameof(GetTrainingByIdAsync), new { trainingId = training.Id.GetId() }, training);
    }

    [HttpGet]
    [Route("{trainingId}")]
    public async Task<IActionResult> GetTrainingByIdAsync(
        [FromRoute] Guid trainingId)
    {
        var training = await _trainingService.GetTrainingByIdServiceAsync(trainingId);
        if (training is null)
            return NotFound();

        return Ok(training);
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAllTrainingsByAccountIdAsync(
        [FromRoute] Guid accountId)
    {
        var trainings = await _trainingService.GetAllTrainingsByAccountIdServiceAsync(accountId);
        if (trainings is null)
            return NotFound();

        return Ok(trainings);
    }

    [HttpDelete]
    [Route("delete/{trainingId}")]
    public async Task<IActionResult> RemoveTrainingAsync(
        [FromRoute] Guid trainingId)
    {
        await _trainingService.RemoveTrainingByIdServiceAsync(trainingId);
        return NoContent();
    }

    [HttpPut]
    [Route("update/{trainingId}")]
    public async Task<IActionResult> UpdateTrainingAsync(
        [FromRoute] Guid trainingId,
        [FromBody] UpdateTrainingDTO updateTrainingDTO)
    {
        var training = await _trainingService.UpdateTrainingByIdServiceAsync(trainingId, updateTrainingDTO);
        return Ok(training);
    }
}
