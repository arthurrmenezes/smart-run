using Microsoft.AspNetCore.Mvc;
using SmartRun.Application.Services.TrainingContext.DataTransferObject;
using SmartRun.Application.Services.TrainingContext.Interfaces;

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
        await _trainingService.CreateTrainingServiceAsync(
            accountId: Guid.NewGuid(),
            createTrainingDto: createTrainingDto);

        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpGet]
    [Route("{trainingId}")]
    public async Task<IActionResult> GetTrainingByIdAsync(
        [FromRoute] Guid trainingId)
    {
        var training = await _trainingService.GetTrainingByIdServiceAsync(trainingId);
        return Ok(training);
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAllTrainingsByAccountIdAsync(
        [FromQuery] Guid accountId)
    {
        var trainings = await _trainingService.GetAllTrainingsByAccountIdServiceAsync(accountId);
        return Ok(trainings);
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> RemoveTrainingAsync(
        [FromQuery] Guid trainingId)
    {
        await _trainingService.RemoveTrainingServiceAsync(trainingId);
        return NoContent();
    }

    [HttpPut]
    [Route("update/{trainingId}")]
    public async Task<IActionResult> UpdateTrainingAsync(
        [FromRoute] Guid trainingId,
        [FromBody] UpdateTrainingDTO updateTrainingDTO)
    {
        var training = await _trainingService.UpdateTrainingServiceAsync(trainingId, updateTrainingDTO);
        return Ok(training);
    }
}
