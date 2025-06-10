using SmartRun.Domain.BoundedContexts.TrainingContext.ENUMs;
using SmartRun.Domain.ValueObjects;

namespace SmartRun.Domain.BoundedContexts.TrainingContext.Entities;

public class Training
{
    public IdValueObject Id { get; set; }
    public LocationType Location { get; set; }
    public double Distance { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime Date { get; set; }
    public DateTime CreatedAt { get; set; }
    public IdValueObject AccountId { get; set; }

    private Training(LocationType location, double distance, TimeSpan duration, DateTime date, IdValueObject accountId)
    {
        Id = IdValueObject.New();
        Location = location;
        Distance = distance;
        Duration = duration;
        Date = date;
        CreatedAt = DateTime.UtcNow;
        AccountId = accountId;
    }

    public static Training Factory(LocationType location, double distance, TimeSpan duration, DateTime date, IdValueObject accountId)
        => new Training(location, distance, duration, date, accountId);
}
