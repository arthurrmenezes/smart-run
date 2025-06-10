using SmartRun.Domain.BoundedContexts.TrainingContext.ENUMs;
using SmartRun.Domain.ValueObjects;

namespace SmartRun.Application.Services.TrainingContext.DataTransferObject;

public sealed record GetTrainingDTO
{
    public IdValueObject Id { get; init; }
    public LocationType Location { get; init; }    
    public double Distance { get; init; }
    public TimeSpan Duration { get; init; }
    public DateTime Date { get; init; }
    public DateTime CreatedAt { get; init; }
    public IdValueObject AccountId { get; init; }

    public GetTrainingDTO(IdValueObject id, LocationType location, double distance, TimeSpan duration, DateTime date, DateTime createdAt, IdValueObject accountId)
    {
        Id = id;
        Location = location;
        Distance = distance;
        Duration = duration;
        Date = date;
        CreatedAt = createdAt;
        AccountId = accountId;
    }
}
