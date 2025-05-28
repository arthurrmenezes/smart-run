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
    [Route("all")]
    public async Task<IActionResult> GetAllTrainingsByAccountIdAsync([FromQuery] Guid accountId)
    {
        var trainings = await _trainingService.GetAllTrainingsByAccountIdServiceAsync(accountId);
        return Ok(trainings);
    }
}
