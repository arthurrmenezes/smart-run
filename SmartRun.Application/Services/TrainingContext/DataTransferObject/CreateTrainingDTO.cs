using SmartRun.Domain.BoundedContexts.TrainingContext.ENUMs;
using System.ComponentModel.DataAnnotations;

namespace SmartRun.Application.Services.TrainingContext.DataTransferObject;

public sealed record CreateTrainingDTO
{
    [Required]
    public LocationType Location { get; init; }
    [Required]
    public double Distance { get; init; }
    [Required]
    public TimeSpan Duration { get; init; }
    [Required]
    public DateTime Date { get; init; }

    public CreateTrainingDTO(LocationType location, double distance, TimeSpan duration, DateTime date)
    {
        Location = location;
        Distance = distance;
        Duration = duration;
        Date = date;
    }
}
