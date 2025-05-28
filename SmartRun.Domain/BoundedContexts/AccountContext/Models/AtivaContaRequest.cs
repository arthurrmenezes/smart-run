using System.ComponentModel.DataAnnotations;

namespace SmartRun.Domain.BoundedContexts.AccountContext.Models;

public class AtivaContaRequest
{
    [Required]
    public int UserId { get; set; }
    [Required]
    public string CodigoDeAtivacao { get; set; }
}
