using System.ComponentModel.DataAnnotations;

namespace Billing.Domain.Entities.Dto;

public class OrganizationDto
{
    [Key]
    public int OrganizationID { get; set; }
    public string? SSOOrganizationID { get; set; }
    public bool? Enabled { get; set; }
}