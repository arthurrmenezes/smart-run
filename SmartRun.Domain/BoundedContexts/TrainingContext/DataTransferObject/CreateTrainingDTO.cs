using System.ComponentModel.DataAnnotations;

namespace SmartRun.Domain.BoundedContexts.TrainingContext.DataTransferObject;

public sealed record CreateTrainingDTO
{
    [Required]
    public string Location { get; set; }
    [Required]
    public double Distance { get; set; }
    [Required]
    public TimeSpan Duration { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public Guid AccountId { get; set; }

    public CreateTrainingDTO(string location, double distance, TimeSpan duration, DateTime date, Guid accountId)
    {
        Location = location;
        Distance = distance;
        Duration = duration;
        Date = date;
        AccountId = accountId;
    }
}
