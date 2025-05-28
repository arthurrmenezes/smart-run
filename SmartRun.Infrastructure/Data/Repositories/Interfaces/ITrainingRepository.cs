using SmartRun.Domain.BoundedContexts.TrainingContext.Entities;

namespace SmartRun.Infrastructure.Data.Repositories.Interfaces;

public interface ITrainingRepository
{
    public Task CreateTrainingAsync(Training training);

    public Task<Training> GetTrainingByIdAsync(Guid trainingId);

    public Task<Training[]> GetAllTrainingsByAccountIdAsync(Guid accountId);

    public Task RemoveTrainingAsync(Training training);

    public Task<Training> UpdateTrainingByIdAsync(Training training);
}
