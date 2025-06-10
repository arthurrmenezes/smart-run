using SmartRun.Application.Services.TrainingContext.DataTransferObject;
using SmartRun.Application.Services.TrainingContext.Interfaces;
using SmartRun.Domain.BoundedContexts.TrainingContext.Entities;
using SmartRun.Domain.ValueObjects;
using SmartRun.Infrastructure.Data.Repositories.Interfaces;

namespace SmartRun.Application.Services.TrainingContext;

public sealed class TrainingService : ITrainingService
{
    private readonly ITrainingRepository _trainingRepository;
    private readonly IAccountRepository _accountRepository;

    public TrainingService(ITrainingRepository trainingRepository, IAccountRepository accountRepository)
    {
        _trainingRepository = trainingRepository;
        _accountRepository = accountRepository;
    }

    public async Task<GetTrainingDTO> CreateTrainingServiceAsync(IdValueObject accountId, CreateTrainingDTO createTrainingDto)
    {
        //var account = await _accountRepository;
        //if (!account)
        //    throw new InvalidOperationException($"Account with ID '{accountId}' not found.");

        var training = Training.Factory(
            location: createTrainingDto.Location,
            distance: createTrainingDto.Distance,
            duration: createTrainingDto.Duration,
            date: createTrainingDto.Date,
            accountId: accountId);

        await _trainingRepository.CreateTrainingAsync(training);

        return new GetTrainingDTO(
            id: training.Id,
            location: training.Location,
            distance: training.Distance,
            duration: training.Duration,
            date: training.Date,
            createdAt: training.CreatedAt,
            accountId: training.AccountId);
    }

    public async Task<GetTrainingDTO> GetTrainingByIdServiceAsync(IdValueObject trainingId)
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
            createdAt: training.CreatedAt,
            accountId: training.AccountId);

        return trainingDto;
    }

    public async Task<GetTrainingDTO[]> GetAllTrainingsByAccountIdServiceAsync(IdValueObject accountId)
    {
        var training = await _trainingRepository.GetAllTrainingsByAccountIdAsync(accountId);

        if (training is null || training.Length == 0)
            throw new KeyNotFoundException($"No training found for account ID {accountId}.");

        var trainingDto = training.Select(t => new GetTrainingDTO(
            id: t.Id,
            location: t.Location,
            distance: t.Distance,
            duration: t.Duration,
            date: t.Date,
            createdAt: t.CreatedAt,
            accountId: t.AccountId)).ToArray();

        return trainingDto;
    }

    public async Task RemoveTrainingByIdServiceAsync(IdValueObject trainingId)
    {
        var training = await _trainingRepository.GetTrainingByIdAsync(trainingId);

        if (training is null)
            throw new KeyNotFoundException($"No training with ID {trainingId} was found.");

        await _trainingRepository.RemoveTrainingAsync(training);
    }

    public async Task<GetTrainingDTO> UpdateTrainingByIdServiceAsync(IdValueObject trainingId, UpdateTrainingDTO updateTrainingDTO)
    {   //verificar se o training pertence a conta que está tentando atualizar
        var training = await _trainingRepository.GetTrainingByIdAsync(trainingId);

        if (training is null)
            throw new KeyNotFoundException($"No training with ID {trainingId} was found.");

        training.Location = updateTrainingDTO.Location;
        training.Distance = updateTrainingDTO.Distance;
        training.Duration = updateTrainingDTO.Duration;
        training.Date = updateTrainingDTO.Date;

        await _trainingRepository.UpdateTrainingAsync(training);

        return new GetTrainingDTO(
            id: training.Id,
            location: training.Location,
            distance: training.Distance,
            duration: training.Duration,
            date: training.Date,
            createdAt: training.CreatedAt,
            accountId: training.AccountId);
    }
}
