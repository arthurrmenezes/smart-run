using SmartRun.Domain.BoundedContexts.TrainingContext.Entities;
using SmartRun.Domain.ValueObjects;

namespace SmartRun.Infrastructure.Data.Repositories.Interfaces;

public interface ITrainingRepository
{
    public Task CreateTrainingAsync(Training training);

    public Task<Training> GetTrainingByIdAsync(IdValueObject trainingId);

    public Task<Training[]> GetAllTrainingsByAccountIdAsync(Guid accountId);

    public Task RemoveTrainingAsync(Training training);

    public Task<Training> UpdateTrainingAsync(Training training);
}
