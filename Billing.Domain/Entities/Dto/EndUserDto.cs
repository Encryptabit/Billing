using System.ComponentModel.DataAnnotations;

namespace Billing.Domain.Entities.Dto;

public class EndUserDto
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int? OrganizationID { get; set; }
}