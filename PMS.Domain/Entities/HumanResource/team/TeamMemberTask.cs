using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace PMS.Domain.Entities.HumanResource.team;

public class TeamMemberTask
{
    [Key]
    public int Id { get; set; }

    [MaxLength(500)]
    [Required]
    public string? Description { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public DateTime DeadLine { get; set; }

    public TeamMember TeamMemberId { get; set; }
    [ForeignKey("TeamMemberId")]
    public TeamMember TeamMember { get; set; }
}