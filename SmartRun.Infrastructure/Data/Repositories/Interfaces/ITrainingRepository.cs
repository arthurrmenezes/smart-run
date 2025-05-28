using SmartRun.Domain.BoundedContexts.TrainingContext.Entities;

namespace SmartRun.Infrastructure.Data.Repositories.Interfaces;

public interface ITrainingRepository
{
    public Task CreateTrainingAsync(Training createTreinoDto);

    public Task<Training> GetTrainingByIdAsync(Guid trainingId);

    public Task<Training[]> GetAllTrainingsByAccountIdAsync(Guid accountId);
}
