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

        if (training is null)
            throw new ArgumentNullException(nameof(training), "Training cannot be null.");

        await _trainingRepository.CreateTrainingAsync(training);
    }

    public async Task<GetTrainingDTO> GetTrainingByIdServiceAsync(Guid trainingId)
    {
        var training = await _trainingRepository.GetTrainingByIdAsync(trainingId);

        if (training is null)
            throw new KeyNotFoundException($"No training with ID {trainingId} was found.");

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

        if (training is null || training.Length == 0)
            throw new KeyNotFoundException($"No trainings found for account ID {accountId}.");

        var trainingDto = training.Select(t => new GetTrainingDTO(
            id: t.Id,
            location: t.Location,
            distance: t.Distance,
            duration: t.Duration,
            date: t.Date,
            accountId: t.AccountId)).ToArray();

        return trainingDto;
    }

    public async Task RemoveTrainingServiceAsync(Guid trainingId)
    {
        var training = await _trainingRepository.GetTrainingByIdAsync(trainingId);
        
        if (training is null)
            throw new KeyNotFoundException($"No training with ID {trainingId} was found.");

        await _trainingRepository.RemoveTrainingAsync(training);
    }

    public async Task<GetTrainingDTO> UpdateTrainingServiceAsync(Guid trainingId, UpdateTrainingDTO updateTrainingDTO)
    { //verificar se o training pertence a conta que está tentando atualizar
        var training = await _trainingRepository.GetTrainingByIdAsync(trainingId);

        if (training is null)
            throw new KeyNotFoundException($"No training with ID {trainingId} was found.");

        training.Location = updateTrainingDTO.Location;
        training.Distance = updateTrainingDTO.Distance;
        training.Duration = updateTrainingDTO.Duration;
        training.Date = updateTrainingDTO.Date;
        training.AccountId = Guid.Parse("C938804B-9417-427C-948F-36F7D621373A");

        await _trainingRepository.UpdateTrainingByIdAsync(training);

        return new GetTrainingDTO(
            id: training.Id,
            location: training.Location,
            distance: training.Distance,
            duration: training.Duration,
            date: training.Date,
            accountId: training.AccountId);
    }
}
