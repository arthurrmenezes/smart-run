using SmartRun.Application.Services.TrainingContext.DataTransferObject;
using SmartRun.Application.Services.TrainingContext.Interfaces;
using SmartRun.Domain.BoundedContexts.TrainingContext.Entities;
using SmartRun.Infrastructure.Data.Repositories.Interfaces;

namespace SmartRun.Application.Services.TrainingContext;

public sealed class TrainingService : ITrainingService
{
    private readonly ITrainingRepository _trainingRepository;

    public TrainingService(ITrainingRepository trainingRepository)
    {
        _trainingRepository = trainingRepository;
    }

    public async Task CreateTrainingServiceAsync(Guid accountId, CreateTrainingDTO createTreinoDto)
    {
        var training = new Training(
            location: createTreinoDto.Location,
            distance: createTreinoDto.Distance,
            duration: createTreinoDto.Duration,
            date: createTreinoDto.Date,
            accountId: accountId);

        await _trainingRepository.CreateTrainingAsync(training);
    }

    public async Task<GetTrainingDTO> GetTrainingByIdServiceAsync(Guid trainingId)
    {
        var training = await _trainingRepository.GetTrainingByIdAsync(trainingId);

        var trainingDto = new GetTrainingDTO(
            id: training.Id,
            location: training.Location,
            distance: training.Distance,
            duration: training.Duration,
            date: training.Date,
            accountId: training.AccountId);

        return trainingDto;
    }

    public async Task<GetTrainingDTO[]> GetAllTrainingsByAccountIdServiceAsync(Guid accountId)
    {
        var training = await _trainingRepository.GetAllTrainingsByAccountIdAsync(accountId);

        var trainingDto = training.Select(t => new GetTrainingDTO(
            id: t.Id,
            location: t.Location,
            distance: t.Distance,
            duration: t.Duration,
            date: t.Date,
            accountId: t.AccountId)).ToArray();

        return trainingDto;
    }
}
