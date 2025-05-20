using System.ComponentModel.DataAnnotations;

namespace SmartRun.Domain.BoundedContexts.AccountContext.Entities;

public class Account
{
    [Key]
    public Guid Id { get; set; }
}
