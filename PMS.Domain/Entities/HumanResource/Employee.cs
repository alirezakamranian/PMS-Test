using PMS.Domain.Entities.HumanResource.team;

namespace PMS.Domain.Entities.HumanResource;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Employee
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(50)]
    [Required]
    public string? Name { get; set; }

    [MaxLength(50)]
    [Required]
    public string? LastName { get; set; }

    [Required]
    public DateOnly BirthDate { get; set; }

    [Required]
    public DateOnly RecruitmentDate { get; set; }

    [MaxLength]
    [Required]
    public string? Role { get; set; }

    [MaxLength(300)]
    public string? Description { get; set; }

    public List<TeamMember> TeamMembers { get; set; }
}