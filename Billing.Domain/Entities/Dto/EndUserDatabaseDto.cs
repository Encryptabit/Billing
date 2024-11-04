using System.ComponentModel.DataAnnotations;

namespace Billing.Domain.Entities.Dto;

public class EndUserDatabaseDto
{
    [Key]
    public int Id { get; set; }
    public int EndUserId { get; set; }
    public int DbId { get; set; }
}