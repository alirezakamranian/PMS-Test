using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace PMS.Domain.Entities.HumanResource.team;

public class TeamMemberTask
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(500)]
    [Required]
    public string? Description { get; set; }

    [Required]
    public DateOnly StartDate { get; set; }

    [Required]
    public DateOnly EndDate { get; set; }

    [Required]
    public DateOnly DeadLine { get; set; }

    public TeamMember TeamMemberId { get; set; }
    [ForeignKey("TeamMemberId")]
    public TeamMember TeamMember { get; set; }
}