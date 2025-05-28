using System.ComponentModel.DataAnnotations;

namespace SmartRun.Domain.BoundedContexts.AccountContext.Models;

public class LoginRequest
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}
