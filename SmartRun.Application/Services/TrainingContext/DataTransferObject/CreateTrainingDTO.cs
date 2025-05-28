using SmartRun.Domain.BoundedContexts.TrainingContext.ENUMs;
using System.ComponentModel.DataAnnotations;

namespace SmartRun.Application.Services.TrainingContext.DataTransferObject;

public sealed record CreateTrainingDTO
{
    [Required]
    public LocationType Location { get; set; }
    [Required]
    public double Distance { get; set; }
    [Required]
    public TimeSpan Duration { get; set; }
    [Required]
    public DateTime Date { get; set; }

    public CreateTrainingDTO(LocationType location, double distance, TimeSpan duration, DateTime date)
    {
        Location = location;
        Distance = distance;
        Duration = duration;
        Date = date;
    }
}

