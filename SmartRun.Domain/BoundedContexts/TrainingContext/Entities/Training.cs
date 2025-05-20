using System.ComponentModel.DataAnnotations;

namespace SmartRun.Domain.BoundedContexts.TrainingContext.Entities;

public class Training
{
    [Key]
    public Guid TrainingId { get; set; }
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

    public Training(Guid id, string location, double distance, TimeSpan duration, DateTime date, Guid accountId)
    {
        Id = id;
        Location = location;
        Distance = distance;
        Duration = duration;
        Date = date;
        AccountId = accountId;
    }
}
