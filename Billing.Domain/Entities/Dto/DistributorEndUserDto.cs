using System.ComponentModel.DataAnnotations;

namespace Billing.Domain.Entities.Dto;

public class DistributorEndUserDto
{
    [Key]
    public int Id { get; set; }
    public int DistributorId { get; set; }
    public int EndUserId { get; set; }
}