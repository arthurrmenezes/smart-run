using System.ComponentModel.DataAnnotations;

namespace SmartRun.Domain.BoundedContexts.AccountContext.Entities;

public class Account
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string Surname { get; set; }
    [Required]
    public string Email { get; set; } //como fazer validacao de email? @...
    [Required]
    public DateTime CreatedAt { get; set; }
}
