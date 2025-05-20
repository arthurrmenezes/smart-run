namespace SmartRun.Domain.BoundedContexts.TrainingContext.DataTransferObject;

public sealed record GetTrainingDTO
{
    public Guid TrainingId { get; set; }
    public string Location { get; set; }    
    public double Distance { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime Date { get; set; }
    public Guid AccountId { get; set; }
}
