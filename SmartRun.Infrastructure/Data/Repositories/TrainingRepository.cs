using Microsoft.EntityFrameworkCore;
using SmartRun.Domain.BoundedContexts.TrainingContext.Entities;
using SmartRun.Domain.ValueObjects;
using SmartRun.Infrastructure.Data.Repositories.Interfaces;

namespace SmartRun.Infrastructure.Data.Repositories;

public sealed class TrainingRepository : ITrainingRepository
{
    private readonly DataContext _dataContext;

    public TrainingRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task CreateTrainingAsync(Training training)
    {
        await _dataContext.Trainings.AddAsync(training);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<Training> GetTrainingByIdAsync(IdValueObject trainingId)
    {
        return await _dataContext.Trainings
            .FirstOrDefaultAsync(t => t.Id.Equals(trainingId));
    }

    public async Task<Training[]> GetAllTrainingsByAccountIdAsync(Guid accountId)
    {
        return await _dataContext.Trainings
            .Where(t => t.AccountId == accountId)
            .ToArrayAsync();
    }

    public async Task RemoveTrainingAsync(Training training)
    {
        _dataContext.Trainings.Remove(training);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<Training> UpdateTrainingAsync(Training training)
    {
        _dataContext.Trainings.Update(training);
        await _dataContext.SaveChangesAsync();
        return training;
    }
}
