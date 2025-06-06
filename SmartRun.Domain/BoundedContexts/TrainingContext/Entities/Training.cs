﻿using SmartRun.Domain.BoundedContexts.TrainingContext.ENUMs;
using System.ComponentModel.DataAnnotations;

namespace SmartRun.Domain.BoundedContexts.TrainingContext.Entities;

public class Training
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public LocationType Location { get; set; }
    [Required]
    public double Distance { get; set; }
    [Required]
    public TimeSpan Duration { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public Guid AccountId { get; set; }

    public Training(LocationType location, double distance, TimeSpan duration, DateTime date, Guid accountId)
    {
        Location = location;
        Distance = distance;
        Duration = duration;
        Date = date;
        AccountId = accountId;
    }
}
