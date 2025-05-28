using SmartRun.Domain.BoundedContexts.TrainingContext.ENUMs;

namespace SmartRun.Application.Services.TrainingContext.DataTransferObject;

public sealed record GetTrainingDTO
{
    public Guid Id { get; set; }
    public LocationType Location { get; set; }    
    public double Distance { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime Date { get; set; }
    public Guid AccountId { get; set; }

    public GetTrainingDTO(Guid id, LocationType location, double distance, TimeSpan duration, DateTime date, Guid accountId)
    {
        Id = id;
        Location = location;
        Distance = distance;
        Duration = duration;
        Date = date;
        AccountId = accountId;
    }
}
